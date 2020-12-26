using CLIClassLibrary.RoleHandlers;
using EAPI.CLI.Lib.DataClasses;
using Newtonsoft.Json;
using Plossum.CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YP.SassyMQ.Lib.RabbitMQ;

namespace SSoTme.Default.Lib.CLIHandler
{

    public partial class EAPICLIHandler
    {
        public static string C_PROJECT_NAME = "effortlessapi";
        private RoleHandlerBase _roleHandler;

        public EAPICLIHandler(string[] args)
        {
            this.amqps = $"amqps://smqPublic:smqPublic@effortlessapi-rmq.ssot.me/{C_PROJECT_NAME}";
            var list = args.ToList();
            list.Insert(0, "cli");
            this.Parser = new CommandLineParser(this);
            this.Parser.Parse(list.ToArray());
        }

        internal static string GetMostRecentUser()
        {
            var di = new DirectoryInfo(ProjectRootPath);
            if (!di.Exists) di.Create();
            var lastModified = di.GetFiles().OrderByDescending(fi => fi.LastWriteTime).FirstOrDefault();
            if (lastModified is null) return "Guest";
            else
            {
                var lastName = Path.GetFileNameWithoutExtension(lastModified.Name);
                return lastName;
            }
        }

        internal static string GetToken(string runas)
        {
            var root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var fileInfo = new FileInfo(Path.Combine(ProjectRootPath, $"{runas}.token"));
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
            if (!fileInfo.Exists) return String.Empty;
            else
            {
                var accessToken = File.ReadAllText(fileInfo.FullName);
                File.WriteAllText(fileInfo.FullName, accessToken);
                return accessToken;
            }
        }

        public string ProcessRequest()
        {
            this.SetDefaultCLIParameters();
            if (this.help) return this.ShowHelp();
            else if (this.reloadCache) return EAPICLIHandler.ReloadCacheNow(this);
            else if (!String.IsNullOrEmpty(this.authenticate)) return this.Authenticate();
            else if (!String.IsNullOrEmpty(this.invoke)) return this.Invoke();
            else throw new Exception($"Sytnax error: cli -invoke <action> -bodyData {{...}} -as Admin");
        }

        private static string ReloadCacheNow(EAPICLIHandler eapiHandler)
        {
            if (!EffortlessAPIServicesFileInfo.Directory.Exists)
            {
                EffortlessAPIServicesFileInfo.Directory.Create();
            }

            var guest = new SMQGuest(eapiHandler.amqps);

            guest.GetEffortlessAPIServices((reply, bdea) =>
            {
                File.WriteAllText(EffortlessAPIServicesFileInfo.FullName, JsonConvert.SerializeObject(reply.EffortlessAPIServices, Formatting.Indented));
            }).Wait(30000);

            guest.GetServiceHostEndpoints((reply, bdea) =>
            {
                File.WriteAllText(ServiceHostEndpointsFileInfo.FullName, JsonConvert.SerializeObject(reply.ServiceHostEndpoints, Formatting.Indented));
            }).Wait(30000);
            return "{\"Success\":true}";
        }

        public static DirectoryInfo RootFileInfo
        {
            get { return new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".eapi")); }
        }

        public static FileInfo EffortlessAPIServicesFileInfo
        {
            get { return new FileInfo(Path.Combine(RootFileInfo.FullName, "EffortlessapiServices.json")); }
        }

        public static FileInfo ServiceHostEndpointsFileInfo
        {
            get { return new FileInfo(Path.Combine(RootFileInfo.FullName, "ServiceHostEndpoints.json")); }
        }

        public static List<EffortlessAPIService> EffortlessAPIServices
        {
            get
            {
                if (!EffortlessAPIServicesFileInfo.Exists) throw new Exception("> eapi -reloadCache required");
                string json = File.ReadAllText(EffortlessAPIServicesFileInfo.FullName);
                var services = JsonConvert.DeserializeObject<List<EffortlessAPIService>>(json);
                return services;
            }
        }

        private string ShowHelp()
        {
            var sbHelpBuilder = new StringBuilder();
            var helpTerm = this.Parser.RemainingArguments.FirstOrDefault();
            if (String.IsNullOrEmpty(helpTerm)) helpTerm = "general";
            this.RoleHandler.AddHelp(sbHelpBuilder, helpTerm);
            if (helpTerm == "general")
            {
                sbHelpBuilder.AppendLine();
                sbHelpBuilder.AppendLine();
                sbHelpBuilder.AppendLine($"Syntax:");
                sbHelpBuilder.AppendLine(this.Parser.UsageInfo.ToString());
                sbHelpBuilder.AppendLine();
                sbHelpBuilder.AppendLine($"Available Roles:");
                RoleHandlerFactory.ListRoles(sbHelpBuilder);
            }
            return sbHelpBuilder.ToString();
        }

        private void SetDefaultCLIParameters()
        {
            var firstArgument = this.Parser.RemainingArguments.FirstOrDefault();
            if (!this.reloadCache && !this.Parser.RemainingArguments.Any()) this.help = true;
            else if (String.Equals(firstArgument, "help", StringComparison.OrdinalIgnoreCase))
            {
                this.help = true;
                this.Parser.RemainingArguments.RemoveAt(0);
            }

            else if (String.IsNullOrEmpty(this.invoke) && !String.IsNullOrEmpty(firstArgument))
            {
                this.invoke = firstArgument;
            }
        }

        private string Invoke()
        {
            if (!String.IsNullOrEmpty(this.bodyFile))
            {
                var fileInfo = new FileInfo(this.bodyFile);
                if (!fileInfo.Exists) throw new Exception($"-bodyFile {fileInfo.FullName} does not exists.");
                else if (String.IsNullOrEmpty(this.bodyData)) this.bodyData = File.ReadAllText(fileInfo.FullName);
            }
            var result = this.RoleHandler.Handle(this.invoke, this.bodyData, this.where);
            if (!String.IsNullOrEmpty(this.output)) File.WriteAllText(this.output, result);
            return result;
        }

        public string Authenticate()
        {
            var smqGuest = new SMQGuest(this.amqps);
            var authPayload = smqGuest.CreatePayload();
            authPayload.EmailAddress = this.authenticate;
            authPayload.DemoPassword = this.demoPassword;
            var result = "";
            smqGuest.ValidateTemporaryAccessToken(authPayload, (reply, bdea) =>
            {
                if (reply.HasNoErrors(bdea))
                {
                    this.SaveAuth(reply.AccessToken);
                }
                result = JsonConvert.SerializeObject(reply, Formatting.Indented, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }).Wait(30000);
            return result;
        }

        private void SaveAuth(string accessToken)
        {
            var fileInfo = new FileInfo(Path.Combine(ProjectRootPath, $"{this.runas}.token"));
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
            File.WriteAllText(fileInfo.FullName, accessToken);
        }

        public CommandLineParser Parser { get; }
        internal RoleHandlerBase RoleHandler
        {
            get
            {
                if (_roleHandler is null)
                {
                    _roleHandler = RoleHandlerFactory.CreateHandler(this.runas, this.amqps);
                }
                return _roleHandler;
            }
            private set => _roleHandler = value;
        }

        public static string RootPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); } }

        public static string ProjectRootPath { get { return Path.Combine(RootPath, ".eapi", $"{C_PROJECT_NAME}"); } }

        public static void HandleRequest(string[] args)
        {
            var handler = new EAPICLIHandler(args);
            Console.WriteLine(handler.ProcessRequest());
        }
    }
}
