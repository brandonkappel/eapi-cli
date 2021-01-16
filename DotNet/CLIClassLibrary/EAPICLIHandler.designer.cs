using Plossum.CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSoTme.Default.Lib.CLIHandler
{

    [CommandLineManager(ApplicationName = "SSOT.me Command Line Request",
                        Copyright = "Copyright (c) EJ Alexandra, CODEiverse.com",
                        Description = @"
SYNTAX: ssotme {command} [...{additional_args}] [options]

Options
")]
    public partial class EAPICLIHandler
    {
        
        [CommandLineOption(Description = "Authenticate as a user", MinOccurs = 0, Aliases = "")]
        public string authenticate { get; set; }
        
        [CommandLineOption(Description = "Check who you are currently operating as", MinOccurs = 0, Aliases = "")]
        public bool whoami { get; set; }
        
        [CommandLineOption(Description = "the user's password", MinOccurs = 0, Aliases = "")]
        public string demoPassword { get; set; }
        
        [CommandLineOption(Description = "Invoke a method", MinOccurs = 0, Aliases = "")]
        public string invoke { get; set; }
        
        [CommandLineOption(Description = "Raw data provided", MinOccurs = 0, Aliases = "")]
        public string bodyData { get; set; }
        
        [CommandLineOption(Description = "Path to file to use", MinOccurs = 0, Aliases = "")]
        public string bodyFile { get; set; }
        
        [CommandLineOption(Description = "Who to run as", MinOccurs = 0, Aliases = "as")]
        public string runas { get; set; }
        
        [CommandLineOption(Description = "AMQPS Connection String", MinOccurs = 0, Aliases = "")]
        public string amqps { get; set; }
        
        [CommandLineOption(Description = "Limit the where clause", MinOccurs = 0, Aliases = "")]
        public string where { get; set; }
        
        [CommandLineOption(Description = "Output file name", MinOccurs = 0, Aliases = "")]
        public string output { get; set; }
        
        [CommandLineOption(Description = "Get help on a given topic", MinOccurs = 0, Aliases = "")]
        public bool help { get; set; }
        
        [CommandLineOption(Description = "Reload cache of project types, plans and such", MinOccurs = 0, Aliases = "")]
        public bool reloadCache { get; set; }
        
        [CommandLineOption(Description = "Create an EffortlessAPI for Airtable Project based on an airtable.json application.", MinOccurs = 0, Aliases = "")]
        public string createAirtableProject { get; set; }
        
        [CommandLineOption(Description = "Name for the new project.", MinOccurs = 0, Aliases = "")]
        public string name { get; set; }
        
        [CommandLineOption(Description = "application.id of the airtable project to add.", MinOccurs = 0, Aliases = "")]
        public string appId { get; set; }
        
        [CommandLineOption(Description = "List all available seeds", MinOccurs = 0, Aliases = "")]
        public bool listSeeds { get; set; }
        
        [CommandLineOption(Description = "Clone the given seed", MinOccurs = 0, Aliases = "")]
        public string cloneEAPISeed { get; set; }
        
        [CommandLineOption(Description = "Override the default URL specified bythe seed repository", MinOccurs = 0, Aliases = "")]
        public string repoUrl { get; set; }
        
    }
}
