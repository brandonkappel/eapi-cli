using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace EAPI.CLI.Lib.DataClasses
{                            
    public partial class ServiceHostType
    {
        private void InitPoco()
        {
        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ServiceHostTypeId")]
        public String ServiceHostTypeId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Attachments")]
        public AirtableAttachment[] Attachments { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Notes")]
        public String Notes { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ServiceHostEndpoints")]
        [RemoteIsCollection]
        public String[] ServiceHostEndpoints { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsEAPIEndpoint")]
        public Nullable<Boolean> IsEAPIEndpoint { get; set; }
    

        

        
        
        private static string CreateServiceHostTypeWhere(IEnumerable<ServiceHostType> serviceHostTypes, String forignKeyFieldName = "ServiceHostTypeId")
        {
            if (!serviceHostTypes.Any()) return "1=1";
            else 
            {
                var idList = serviceHostTypes.Select(selectServiceHostType => String.Format("'{0}'", selectServiceHostType.ServiceHostTypeId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}
