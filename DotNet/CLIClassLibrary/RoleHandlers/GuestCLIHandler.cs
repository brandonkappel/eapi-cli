using Newtonsoft.Json;
using EAPI.CLI.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;
using System.Text;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class GuestCLIHandler : RoleHandlerBase<SMQGuest>
    {

        public GuestCLIHandler(string amqps, string accessToken)
            : base(amqps, accessToken)
        {
        }

        public override string Handle(string invoke, string data, string where, int maxPages = 5)
        {
            if (string.IsNullOrEmpty(data)) data = "{}";
            string result = HandlerFactory(invoke, data, where);
            return result;
        }
    }
}