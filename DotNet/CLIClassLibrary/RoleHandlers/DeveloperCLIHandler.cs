using Newtonsoft.Json;
using EAPI.CLI.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;
using System.Text;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class DeveloperCLIHandler : RoleHandlerBase<SMQDeveloper>
    {

        public DeveloperCLIHandler(string amqps, string accessToken)
            : base(amqps, accessToken)
        {
            this.GetEffortlessAPIProjectsHandler = this.SMQActor.GetEffortlessAPIProjects;
        }

        public override string Handle(string invoke, string data, string where)
        {
            if (string.IsNullOrEmpty(data)) data = "{}";
            string result = HandlerFactory(invoke, data, where);
            return result;
        }
    }
}