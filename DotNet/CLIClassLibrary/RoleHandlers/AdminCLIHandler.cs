using Newtonsoft.Json;
using EAPI.CLI.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;
using System.Text;
using System.Linq;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class AdminCLIHandler : RoleHandlerBase<SMQAdmin>
    {

        public AdminCLIHandler(string amqps, string accessToken)
            : base(amqps, accessToken)
        {
            this.GetEffortlessAPIProjectsHandler = this.SMQActor.GetEffortlessAPIProjects;
        }

        public override string Handle(string invoke, string data, string where, int maxPages = 5)
        {
            if (string.IsNullOrEmpty(data)) data = "{}";
            string result = HandlerFactory(invoke, data, where, maxPages);
            return result;
        }
    }
}