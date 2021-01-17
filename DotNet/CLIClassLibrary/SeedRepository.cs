using System;

namespace SSoTme.Default.Lib.CLIHandler
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
        public string SeedReplacementsText { get; set; }
        public string PrivateRepositoryUrl { get; set; }

        public override string ToString()
        {
            return this.ShortName;
        }
    }
}
