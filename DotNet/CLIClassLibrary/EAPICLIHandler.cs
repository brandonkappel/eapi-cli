using CLIClassLibrary.RoleHandlers;
using EAPI.CLI.Lib.DataClasses;
using Newtonsoft.Json;
using Plossum.CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YP.SassyMQ.Lib.RabbitMQ;

namespace SSoTme.Default.Lib.CLIHandler
{

    public partial class EAPICLIHandler
    {
        public static string C_PROJECT_NAME = "effortlessapi";
        private RoleHandlerBase _roleHandler;
        private EffortlessAPIAccount _effortlessAPIAccount;
        private static List<SeedRepository> _seedRepositories;

        static EAPICLIHandler()
        {
            Payload payload = new Payload();
            var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CLIClassLibrary.SeedRepos.SeedRepos.json");
            using (var sr = new StreamReader(resourceStream))
            {
                var json = sr.ReadToEnd();
                json = json.Replace(": \"checked\"", ": true");
                payload = JsonConvert.DeserializeObject<Payload>(json);
                File.WriteAllText(SeedRepositoriesFileInfo.FullName, JsonConvert.SerializeObject(payload.SeedRepositories, Formatting.Indented));
            }

        }

        public EAPICLIHandler(string[] args)
        {
            this.amqps = $"amqps://smqPublic:smqPublic@effortlessapi-rmq.ssot.me/{C_PROJECT_NAME}";
            this.Parser = new CommandLineParser(this);
            this.Parser.Parse(args, false);
            if (this.Parser.Errors.Any())
            {
                throw new Exception($"SYNTAX ERRORS: {JsonConvert.SerializeObject(Parser.Errors)}.");
            }
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
            else if (this.whoami) return this.CheckWhoIAmNow();
            else if (this.listSeeds) return this.ListSeedRepositoriesNow();
            else if (!String.IsNullOrEmpty(this.cloneEAPISeed)) return this.CloneEAPISeed();
            else if (!String.IsNullOrEmpty(this.authenticate)) return this.Authenticate();
            else if (!String.IsNullOrEmpty(this.createAirtableProject) || !String.IsNullOrEmpty(this.appId)) return this.CreateAirtableProjectNow();
            else if (!String.IsNullOrEmpty(this.invoke)) return this.Invoke();
            else throw new Exception($"Sytnax error: cli -invoke <action> -bodyData {{...}} -as Admin");
        }

        private string CloneEAPISeed()
        {
            if (this.Parser.RemainingArguments.Count < 2) throw new Exception("Syntax: eapi -cloneEAPISeed {project-seed-short-name} ./project-folder {eapi-project-alias}");
            else
            {
                var folderName = this.Parser.RemainingArguments.FirstOrDefault();
                var folder = new DirectoryInfo(folderName);
                var eapiProjectAlias = Parser.RemainingArguments.Skip(1).First();
                var eapiProject = this.RoleHandler.GetProjectByAlias(eapiProjectAlias);
                var matchingSeed = EAPICLIHandler.SeedRepositories.FirstOrDefault(seedRepo => String.Equals(seedRepo.ShortName, this.cloneEAPISeed, StringComparison.OrdinalIgnoreCase));
                
                if (eapiProject is null) throw new Exception($"Can't load the EAPI project requested: {eapiProjectAlias}");

                this.CloneRepo(folder, matchingSeed);
                this.UpdateFiles(folder, eapiProject, matchingSeed);
                this.DeleteDotGitFolder(folder);
                this.InvokeSSoTmeBuild(folder);
                this.StartSlnIfPresent(folder);
                return $"CLONED EAPI SEED: {this.cloneEAPISeed} into folder ./{folder.Name}, linking it to EAPI Project {eapiProjectAlias}.";
            }

        }

        private void StartSlnIfPresent(DirectoryInfo folder)
        {
            var slnFile = folder.GetFiles().FirstOrDefault(fi => Path.GetExtension(fi.Name) == ".sln");
            if (slnFile.Exists)
            {
                Console.WriteLine($"SOLUTION: {slnFile.FullName}");
                // Process.Start(slnFile.FullName);
            }
        }

        private void InvokeSSoTmeBuild(DirectoryInfo folder)
        {
            var ssotmeProjectFile = new FileInfo(Path.Combine(folder.FullName, "SSoTmeProject.json"));
            if (ssotmeProjectFile.Exists)
            {
                var psi = new ProcessStartInfo("ssotme");
                psi.WorkingDirectory = folder.FullName;
                psi.Arguments = "-build";
                using (var process = Process.Start(psi))
                {
                    process.WaitForExit();
                    process.Close();
                }
            }

        }

        private void UpdateFiles(DirectoryInfo folder, EffortlessAPIProject eapiProject, SeedRepository matchingSeed)
        {
            var eapiProjectAlias = eapiProject.Alias.SafeToString();
            var replacements = matchingSeed.SeedReplacementsText.Split(",");
            replacements.ToList().ForEach(replacement =>
            {
                var replaceParts = replacement.SafeToString().Split("_WITH_");
                if (replaceParts.Length == 2)
                {
                    var find = replaceParts[0].Trim().Replace("REPLACE_", "").Trim();
                    var replace = replaceParts[1].SafeToString();
                    replace = replace.Replace("$EffortlessAPIProject.Alias$", eapiProjectAlias);
                    replace = replace.Replace("$EffortlessAPIProject.AliasToken$", eapiProjectAlias.SafeToString().Replace(" ", "").Replace("-", ""));
                    replace = replace.Replace("$EffortlessAPIProject.UserTable$", eapiProject.UserTable);
                    replace = replace.Replace("$EffortlessAPIProject.UserTablePlural$", $"{eapiProject.UserTable}s");
                    replace = replace.Replace("$EffortlessAPIProject.AirtableId$", eapiProject.AirtableId);
                    this.SearchAndReplace(folder, find, replace);
                }
            });
            object o = -1;
        }

        private void SearchAndReplace(DirectoryInfo folder, string find, string replace)
        {
            if (folder.Name.StartsWith(".")) return;
            foreach (var fi in folder.GetFiles())
            {
                this.SearchAndReplace(fi, find, replace);
            }
            foreach (var di in folder.GetDirectories())
            {
                this.SearchAndReplace(di, find, replace);
            }
        }

        private void SearchAndReplace(FileInfo fi, string find, string replace)
        {
            if (fi.Exists)
            {
                if (fi.Name.Contains(find))
                {
                    var newName = Path.Combine(fi.Directory.FullName, fi.Name.Replace(find, replace));
                    fi.MoveTo(newName);
                    fi = new FileInfo(newName);
                }
                var contents = File.ReadAllText(fi.FullName);
                if (contents.Contains(find))
                {
                    contents = contents.Replace(find, replace);
                    File.WriteAllText(fi.FullName, contents);
                }
            }
        }

        private void DeleteDotGitFolder(DirectoryInfo folder)
        {
            var gitFolder = new DirectoryInfo(Path.Combine(folder.FullName, ".git"));
            if (!gitFolder.Exists) throw new Exception("GIT CLONE Seems to have failed.  :(");
            else
            {
                gitFolder.MoveTo(Path.Combine(gitFolder.Parent.FullName, "REMOVED_GIT_FOLDER"));
            }
        }

        private void CloneRepo(DirectoryInfo folder, SeedRepository matchingSeed)
        {
            if (folder.Exists) throw new Exception($"Folder '{folder.FullName}' already exists.");
            else
            {
                if (String.IsNullOrEmpty(this.repoUrl)) this.repoUrl = matchingSeed.RepositoryUrl;
                var psi = new ProcessStartInfo("git");
                psi.Arguments = $"clone {this.repoUrl} {folder.FullName}";
                //              psi.UseShellExecute = true;
                using (var process = Process.Start(psi))
                {
                    process.WaitForExit();
                    process.Close();
                }
            }
        }

        private string ListSeedRepositoriesNow()
        {
            return File.ReadAllText(SeedRepositoriesFileInfo.FullName);
        }

        private string CheckWhoIAmNow()
        {
            if (!this.EffortlessAPIAccountFileInfo.Exists) throw new Exception($"Must must first authenticate as {runas}");
            else return File.ReadAllText(this.EffortlessAPIAccountFileInfo.FullName);
        }

        private string CreateAirtableProjectNow()
        {
            (string name, string appId) = GetAirtableNameAndId(this.name, this.appId);
            if (ProjectDetailsAreValid(name, appId))
            {
                SMQDeveloper dev = new SMQDeveloper(this.amqps);
                if (String.IsNullOrEmpty(runas)) runas = EAPICLIHandler.GetMostRecentUser();
                dev.AccessToken = EAPICLIHandler.GetToken(runas);
                EffortlessAPIProject existingProject = FindExistingEAPIProject(dev);

                if (existingProject is null)
                {
                    GenerateNewProjectFromScratch(dev, name, appId);
                    return $"CREATED AIRTABLE PROJECT {name}/{appId}";
                }
                else
                {
                    var msg = $"Project {name} already exists in your EffortlessAPI Acocunt.";
                    return msg;
                }
            }
            else return "Invalid syntax received.  Aborted.";
        }


        private EffortlessAPIProject FindExistingEAPIProject(SMQDeveloper dev)
        {
            var where = $"Name='{name}'";
            Console.WriteLine($"WHERE {where} with airtableId {appId}");

            var findProjPL = dev.CreatePayload();
            findProjPL.AirtableWhere = where;
            dev.GetEffortlessAPIProjects(findProjPL, (fpReply, fpBdea) =>
            {
                if (fpReply.HasNoErrors(fpBdea))
                {
                    findProjPL.EffortlessAPIProject = fpReply.EffortlessAPIProjects.FirstOrDefault();
                }
            }).Wait(30000);
            return findProjPL.EffortlessAPIProject;
        }

        private EffortlessAPIAccount EffortlessAPIAccount
        {
            get
            {
                if (_effortlessAPIAccount is null)
                {
                    if (!EffortlessAPIAccountFileInfo.Exists) throw new Exception("Must authenticate and check who-am-i before this will work.");

                    var accountJson = File.ReadAllText(EffortlessAPIAccountFileInfo.FullName);
                    _effortlessAPIAccount = JsonConvert.DeserializeObject<EffortlessAPIAccount>(accountJson);
                }
                return _effortlessAPIAccount;
            }
            set => _effortlessAPIAccount = value;
        }

        private bool ProjectDetailsAreValid(string name, string airtableId)
        {
            Console.WriteLine($"NAME: {name}");
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(airtableId))
            {
                throw new Exception("Syntax: CreateEAPIProject {name} {airtableId}");
            }
            else
            {
                return true;
            }
        }

        private void GenerateNewProjectFromScratch(SMQDeveloper dev, string name, string airtableId)
        {
            if (EffortlessAPIAccount is null) throw new Exception("Can't find EffortlessAPI Account - SaveiWhoAmI and eapi -reloadCache first.");

            var eapiProject = AddNewProject(dev, name, airtableId);

            this.AddProjectEmail(dev, eapiProject);

            var headStage = this.AddHeadStage(dev, eapiProject);

            eapiProject = this.UpdateHeadStage(dev, eapiProject, headStage);

            var projectVersion = this.AddProjectVersion(dev, eapiProject);

            this.UpdateHeadStageActiveVersion(dev, headStage, projectVersion);

            this.AddRole(dev, projectVersion, "Guest", false);
            this.AddRole(dev, projectVersion, "User", false);
            this.AddRole(dev, projectVersion, "Admin", true);
        }

        private ProjectRole AddRole(SMQDeveloper dev, ProjectVersion projectVersion, string roleName, bool isAdmin)
        {
            var newRole = default(ProjectRole);
            var addRolePL = dev.CreatePayload();
            addRolePL.ProjectRole = new ProjectRole()
            {
                ProjectVersion = projectVersion.ProjectVersionId,
                Name = roleName,
                DefaultHasAccess = isAdmin,
                CanCreateByDefault = isAdmin,
                CanReadByDefault = isAdmin,
                CanUpdateByDefault = isAdmin,
                CanDeleteByDefault = isAdmin
            };
            dev.AddProjectRole(addRolePL, (arReply, arBdea) =>
            {
                if (arReply.HasNoErrors(arBdea))
                {
                    newRole = arReply.ProjectRole;
                }
            }).Wait(30000);
            return newRole;
        }

        private ProjectStage UpdateHeadStageActiveVersion(SMQDeveloper dev, ProjectStage headStage, ProjectVersion projectVersion)
        {
            headStage.ActiveVersion = projectVersion.ProjectVersionId;
            var headStagePL = dev.CreatePayload();
            headStagePL.ProjectStage = headStage;
            dev.UpdateProjectStage(headStagePL, (hsReply, hsBdea) =>
            {
                if (hsReply.HasNoErrors(hsBdea))
                {
                    headStage = hsReply.ProjectStage;
                }
            }).Wait(30000);
            return headStage;
        }

        private ProjectVersion AddProjectVersion(SMQDeveloper dev, EffortlessAPIProject eapiProject)
        {
            var newVersionPL = dev.CreatePayload();
            newVersionPL.ProjectVersion = new ProjectVersion()
            {
                Project = eapiProject.EffortlessAPIProjectId,
            };
            dev.AddProjectVersion(newVersionPL, (vReply, vBdea) =>
            {
                if (vReply.HasNoErrors(vBdea))
                {
                    newVersionPL.ProjectVersion = vReply.ProjectVersion;
                };
            }).Wait(30000);
            return newVersionPL.ProjectVersion;
        }

        private EffortlessAPIProject UpdateHeadStage(SMQDeveloper dev, EffortlessAPIProject eapiProject, ProjectStage headStage)
        {
            eapiProject.HeadStage = headStage.ProjectStageId;
            var updateProjectPL = dev.CreatePayload();
            updateProjectPL.EffortlessAPIProject = eapiProject;
            dev.UpdateEffortlessAPIProject(updateProjectPL, (upReply, upBdea) =>
            {
                if (upReply.HasNoErrors(upBdea))
                {
                    eapiProject = upReply.EffortlessAPIProject;
                }
            }).Wait(30000);
            return eapiProject;
        }

        private ProjectStage AddHeadStage(SMQDeveloper dev, EffortlessAPIProject eapiProject)
        {
            var newProjectStagePL = dev.CreatePayload();
            var largeECSEndpointId = EAPICLIHandler.ServiceHostEndpoints.First(endpoint => endpoint.Name == "Large-EAPIEndpoint-EffortlessApi-EC2").ServiceHostEndpointId;
            if (String.IsNullOrEmpty(largeECSEndpointId)) throw new Exception("Large EC2 Endpoint not found... > eapi -reloadCache");
            newProjectStagePL.ProjectStage = new ProjectStage()
            {
                Project = eapiProject.EffortlessAPIProjectId,
                Stage = "develop",
                TemplateTaskEndpoint = largeECSEndpointId
            };
            dev.AddProjectStage(newProjectStagePL, (psReply, psBdea) =>
            {
                if (psReply.HasNoErrors(psBdea))
                {
                    newProjectStagePL.ProjectStage = psReply.ProjectStage;
                }
            }).Wait(30000);
            return newProjectStagePL.ProjectStage;
        }

        private void AddProjectEmail(SMQDeveloper dev, EffortlessAPIProject project)
        {
            var newProjectEmailPL = dev.CreatePayload();
            newProjectEmailPL.ProjectEmail = new ProjectEmail()
            {
                Project = project.EffortlessAPIProjectId,
                Account = EffortlessAPIAccount.EffortlessAPIAccountId
            };
            dev.AddProjectEmail(newProjectEmailPL, (peReply, peBdea) =>
            {
                if (peReply.HasNoErrors(peBdea))
                {
                    newProjectEmailPL.ProjectEmail = peReply.ProjectEmail;
                }
            }).Wait(30000);
        }

        private EffortlessAPIProject AddNewProject(SMQDeveloper dev, string name, string airtableId)
        {
            var newProjectPL = dev.CreatePayload();
            var airtableServiceId = EAPICLIHandler.EffortlessAPIServices.First(svc => svc.Name == "airtable").EffortlessAPIServiceId;
            if (String.IsNullOrEmpty(airtableServiceId)) throw new Exception("Airtable id required... > eapi -reloadCache");
            newProjectPL.EffortlessAPIProject = new EffortlessAPIProject()
            {
                Name = name,
                EffortlessApiService = airtableServiceId,
                Account = EffortlessAPIAccount.EffortlessAPIAccountId,
                AirtableId = airtableId,
                GuestRole = "Guest",
                AdminRole = "Admin",
                UserRole = "User",
                EntitiesTable = "Entities",
                RolesTable = "Roles",
                ProjectStage = "Development",
                ProjectType = "Commercial"
            };
            dev.AddEffortlessAPIProject(newProjectPL, (npReply, npBdea) =>
            {
                if (npReply.HasNoErrors(npBdea))
                {
                    newProjectPL.EffortlessAPIProject = npReply.EffortlessAPIProject;
                }
            }).Wait(30000);
            return newProjectPL.EffortlessAPIProject;
        }

        private (string name, string airtableId) GetAirtableNameAndId(string name, string airtableId)
        {
            if (String.IsNullOrEmpty(name)) name = this.createAirtableProject;

            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(airtableId)) return (name, airtableId);
            else
            {
                if (!this.AirtableApplicationFileInfo.Exists) throw new Exception($"Can't find airtable file {AirtableApplicationFileInfo.FullName}");
                else
                {
                    string json = File.ReadAllText(this.AirtableApplicationFileInfo.FullName);
                    dynamic jObject = JsonConvert.DeserializeObject(json);
                    if (String.IsNullOrEmpty(name)) name = jObject.name;
                    airtableId = String.IsNullOrEmpty(airtableId) ? jObject.id : airtableId;

                    Console.WriteLine("Would you like to rename?");
                    Console.Write($"New Name (press enter to leave unchanged) '{name}'");
                    var newName = Console.ReadLine();
                    if (String.IsNullOrEmpty(newName)) newName = name;
                    return (newName, airtableId);
                }
            }
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
            get
            {
                var di = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".eapi"));
                if (!di.Exists) di.Create();
                return di;
            }
        }

        public static FileInfo SeedRepositoriesFileInfo
        {
            get { return new FileInfo(Path.Combine(RootFileInfo.FullName, "SeedRepositories.json")); }
        }


        public static FileInfo EffortlessAPIServicesFileInfo
        {
            get { return new FileInfo(Path.Combine(RootFileInfo.FullName, "EffortlessapiServices.json")); }
        }

        public static FileInfo ServiceHostEndpointsFileInfo
        {
            get { return new FileInfo(Path.Combine(RootFileInfo.FullName, "ServiceHostEndpoints.json")); }
        }

        public static List<ServiceHostEndpoint> ServiceHostEndpoints
        {
            get
            {
                if (!ServiceHostEndpointsFileInfo.Exists) throw new Exception("> eapi -reloadCache required");
                string json = File.ReadAllText(ServiceHostEndpointsFileInfo.FullName);
                var endpoints = JsonConvert.DeserializeObject<List<ServiceHostEndpoint>>(json);
                return endpoints;
            }
        }

        internal FileInfo AirtableApplicationFileInfo
        {
            get
            {
                if (!String.IsNullOrEmpty(this.createAirtableProject)) return new FileInfo(this.createAirtableProject);
                else return default(FileInfo);
            }
        }

        internal FileInfo EffortlessAPIAccountFileInfo
        {
            get { return new FileInfo(Path.Combine(ProjectRootPath, $"{runas}.json")); }
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
            sbHelpBuilder.AppendLine($"CLI Help: {Assembly.GetExecutingAssembly().ImageRuntimeVersion.ToString()}.");
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

            if (String.Equals(firstArgument, "help", StringComparison.OrdinalIgnoreCase))
            {
                this.help = true;
                this.Parser.RemainingArguments.RemoveAt(0);
            }
            if (String.Equals(firstArgument, "reloadCache", StringComparison.OrdinalIgnoreCase))
            {
                this.reloadCache = true;
                this.Parser.RemainingArguments.RemoveAt(0);
            }

            if (String.IsNullOrEmpty(this.runas)) this.runas = GetMostRecentUser();
            if (String.IsNullOrEmpty(this.runas)) this.runas = "guest";
            this.runas = this.runas.ToLower();

            firstArgument = this.Parser.RemainingArguments.FirstOrDefault();
            if (!this.help &&
                !this.reloadCache &&
                !this.whoami &&
                !this.listSeeds &&
                String.IsNullOrEmpty(this.cloneEAPISeed) &&
                String.IsNullOrEmpty(this.authenticate) &&
                String.IsNullOrEmpty(this.invoke) &&
                !String.IsNullOrEmpty(firstArgument))
            {
                if (String.IsNullOrEmpty(firstArgument))
                {
                    this.help = true;
                }
                else this.invoke = firstArgument;
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
                    smqGuest.AccessToken = reply.AccessToken;
                    var whoAmIPL = smqGuest.CreatePayload();
                    smqGuest.WhoAmI(whoAmIPL, (whoAmIReply, whoAmIBDEA) =>
                    {
                        if (whoAmIReply.HasNoErrors(whoAmIBDEA))
                        {
                            var accountJSON = JsonConvert.SerializeObject(whoAmIReply.SingletonAppUser, Formatting.Indented);
                            File.WriteAllText(EffortlessAPIAccountFileInfo.FullName, accountJSON);
                        }
                    }).Wait(30000);
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

        public static string ProjectRootPath
        {
            get
            {
                var di = new DirectoryInfo(Path.Combine(RootPath, ".eapi", $"{C_PROJECT_NAME}"));
                if (!di.Exists) di.Create();
                return di.FullName;
            }
        }

        public static List<SeedRepository> SeedRepositories
        {
            get
            {
                if (_seedRepositories is null)
                {
                    var json = File.ReadAllText(SeedRepositoriesFileInfo.FullName);
                    var payload = JsonConvert.DeserializeObject<SeedRepositories>(json);
                    _seedRepositories = payload.SeedRepository;
                }
                return _seedRepositories;
            }
            set => _seedRepositories = value;
        }

        public static void HandleRequest(string[] args)
        {
            var handler = new EAPICLIHandler(args);
            Console.WriteLine(handler.ProcessRequest());
        }
    }
}
