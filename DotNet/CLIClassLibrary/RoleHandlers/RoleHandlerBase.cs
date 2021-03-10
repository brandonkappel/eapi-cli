using EAPI.CLI.Lib.DataClasses;
using Newtonsoft.Json;
using SSoTme.Default.Lib.CLIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public abstract class RoleHandlerBase
    {
        public abstract string Handle(string invoke, string data, string where, int maxPages = 5);

        protected string SerializePayload(StandardPayload reply)
        {
            return JsonConvert.SerializeObject(reply, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public abstract void AddHelp(StringBuilder sb, string helpTerm);

        public abstract EffortlessAPIProject GetProjectByAlias(string eapiProjectAlias);
    }

    public abstract class RoleHandlerBase<T> : RoleHandlerBase
        where T : SMQActorBase
    {
        private T _smqActor;

        public T SMQActor
        {
            get { 
                if (_smqActor is null)
                {
                    _smqActor = Activator.CreateInstance(typeof(T), this.AMQPS) as T;
                    this.SMQActor.AccessToken = this.AccessToken;
                }
                return _smqActor; }
        }

        public RoleHandlerBase(string amqps, string accessToken)
        {
            this.AMQPS = amqps;
            this.AccessToken = accessToken;
        }

        public string AMQPS { get; }
        public string AccessToken { get; }
        public delegate Task handler(StandardPayload payload, PayloadHandler handler, PayloadHandler errors = null, int timeout = 30000);
        public handler GetEffortlessAPIProjectsHandler { get; set; }

        public override EffortlessAPIProject GetProjectByAlias(string eapiProjectAlias)
        {
            var payload = this.SMQActor.CreatePayload();
            payload.AirtableWhere = string.Format($"Alias = '{eapiProjectAlias}'");
            var result = default(EffortlessAPIProject);
            this.GetEffortlessAPIProjectsHandler(payload, (reply, bdea) =>
            {
                if (reply.HasNoErrors(bdea) && !(reply.EffortlessAPIProjects is null))
                {
                    result = reply.EffortlessAPIProjects.FirstOrDefault();
                }
            }).Wait(30000);

            return result;
        }
    }


}
