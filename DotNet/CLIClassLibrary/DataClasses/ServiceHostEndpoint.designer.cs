using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace EAPI.CLI.Lib.DataClasses
{                            
    public partial class ServiceHostEndpoint
    {
        private void InitPoco()
        {
        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ServiceHostEndpointId")]
        public String ServiceHostEndpointId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Alias")]
        public String Alias { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AmqpsConnectionString")]
        [RemoteIsCollection]
        public String AmqpsConnectionString { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Attachments")]
        public AirtableAttachment[] Attachments { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AwsId")]
        public String AwsId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AwsRegion")]
        public String AwsRegion { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "BaseUrl")]
        public String BaseUrl { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ClusterAwsId")]
        [RemoteIsCollection]
        public String ClusterAwsId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ClusterAwsRegion")]
        [RemoteIsCollection]
        public String ClusterAwsRegion { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ClusterName")]
        [RemoteIsCollection]
        public String ClusterName { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultPassword")]
        public String DefaultPassword { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultUsername")]
        public String DefaultUsername { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DesiredCount")]
        public String DesiredCount { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "EndpointSize")]
        [RemoteIsCollection]
        public String EndpointSize { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsActive")]
        public Nullable<Boolean> IsActive { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsEC2")]
        public Nullable<Boolean> IsEC2 { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsFargate")]
        public Nullable<Boolean> IsFargate { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsSecure")]
        public Nullable<Boolean> IsSecure { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "MaxCPU")]
        public String MaxCPU { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "MaxMemory")]
        public String MaxMemory { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Notes")]
        public String Notes { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Profile")]
        public String Profile { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ProjectStages")]
        [RemoteIsCollection]
        public String[] ProjectStages { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ProjectTasks")]
        [RemoteIsCollection]
        public String[] ProjectTasks { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RabbitMQDefaultUsername")]
        [RemoteIsCollection]
        public String RabbitMQDefaultUsername { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RabbitMQEndpoint")]
        [RemoteIsCollection]
        public String RabbitMQEndpoint { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RabbitMQHost")]
        [RemoteIsCollection]
        public String RabbitMQHost { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RabbitMQHostUrl")]
        [RemoteIsCollection]
        public String RabbitMQHostUrl { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SecurityGroup")]
        public String SecurityGroup { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ServiceHostType")]
        [RemoteIsCollection]
        public String ServiceHostType { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ServiceName")]
        public String ServiceName { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Subnet")]
        public String Subnet { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TaskClusterEndpoint")]
        [RemoteIsCollection]
        public String TaskClusterEndpoint { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TaskDefinitionJsonLocation")]
        public String TaskDefinitionJsonLocation { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TaskExecutionRole")]
        public String TaskExecutionRole { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TaskRabbitMQAdminUsername")]
        [RemoteIsCollection]
        public String TaskRabbitMQAdminUsername { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TaskRabbitMQEndpoint")]
        [RemoteIsCollection]
        public String TaskRabbitMQEndpoint { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TaskSassyMQEndpoint")]
        [RemoteIsCollection]
        public String TaskSassyMQEndpoint { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RECORD_ID")]
        public String RECORD_ID { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsEAPIEndpoint")]
        [RemoteIsCollection]
        public Nullable<Boolean> IsEAPIEndpoint { get; set; }
    

        

        
        
        private static string CreateServiceHostEndpointWhere(IEnumerable<ServiceHostEndpoint> serviceHostEndpoints, String forignKeyFieldName = "ServiceHostEndpointId")
        {
            if (!serviceHostEndpoints.Any()) return "1=1";
            else 
            {
                var idList = serviceHostEndpoints.Select(selectServiceHostEndpoint => String.Format("'{0}'", selectServiceHostEndpoint.ServiceHostEndpointId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}
