using System;

namespace SSoTme.Default.Lib.CLIHandler
{

    public partial class EAPICLIHandler
    {
        public class SeedRepository
        {
            public String Name { get; set; }
            public String ShortName { get; set; }
            public String DisplayName { get; set; }
            public String RepositoryUrl { get; set; }
            public String Notes { get; set; }
            public Boolean IsActive { get; set; }
            public Boolean IsAirtable { get; set; }
            public Boolean IsAkveo { get; set; }
            public Boolean IsAngular { get; set; }
            public Boolean IsWebApp { get; set; }
            public String AdditionalDeploymentCommands { get; set; }
        }
    }
}
