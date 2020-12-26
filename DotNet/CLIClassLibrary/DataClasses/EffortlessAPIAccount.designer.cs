using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace EAPI.CLI.Lib.DataClasses
{                            
    public partial class EffortlessAPIAccount
    {
        private void InitPoco()
        {
        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "EffortlessAPIAccountId")]
        public String EffortlessAPIAccountId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DemoPassword")]
        public String DemoPassword { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Attachments")]
        public AirtableAttachment[] Attachments { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DebugPassword")]
        public String DebugPassword { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "EmailAddress")]
        public String EmailAddress { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Notes")]
        public String Notes { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ProjectEmails")]
        [RemoteIsCollection]
        public String[] ProjectEmails { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Projects")]
        [RemoteIsCollection]
        public String[] Projects { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Role")]
        public String Role { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ServiceKeys")]
        [RemoteIsCollection]
        public String[] ServiceKeys { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "MonthlySubscriptionTotals")]
        [RemoteIsCollection]
        public Nullable<decimal> MonthlySubscriptionTotals { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AccountDiscount")]
        public Nullable<decimal> AccountDiscount { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultMaxPages")]
        public Nullable<Int32> DefaultMaxPages { get; set; }
    

        

        
        
        private static string CreateEffortlessAPIAccountWhere(IEnumerable<EffortlessAPIAccount> effortlessAPIAccounts, String forignKeyFieldName = "EffortlessAPIAccountId")
        {
            if (!effortlessAPIAccounts.Any()) return "1=1";
            else 
            {
                var idList = effortlessAPIAccounts.Select(selectEffortlessAPIAccount => String.Format("'{0}'", selectEffortlessAPIAccount.EffortlessAPIAccountId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}
