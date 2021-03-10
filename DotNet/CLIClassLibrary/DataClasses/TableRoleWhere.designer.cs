using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace EAPI.CLI.Lib.DataClasses
{                            
    public partial class TableRoleWhere
    {
        private void InitPoco()
        {
        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TableRoleWhereId")]
        public String TableRoleWhereId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CreatedAt")]
        public Nullable<DateTime> CreatedAt { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AirtableWhereClause")]
        public String AirtableWhereClause { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Attachments")]
        public AirtableAttachment[] Attachments { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CanCallCreate")]
        public Nullable<Boolean> CanCallCreate { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CanCallDelete")]
        public Nullable<Boolean> CanCallDelete { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CanCallRead")]
        public Nullable<Boolean> CanCallRead { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CanCallUpdate")]
        public Nullable<Boolean> CanCallUpdate { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CanCreateByDefault")]
        public Nullable<Boolean> CanCreateByDefault { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CanDeleteByDefault")]
        public Nullable<Boolean> CanDeleteByDefault { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CanReadByDefault")]
        public Nullable<Boolean> CanReadByDefault { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CanUpdateByDefault")]
        public Nullable<Boolean> CanUpdateByDefault { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ColumnRoleCRUDs")]
        public String ColumnRoleCRUDs { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ColumnRoleCRUDs2")]
        public String ColumnRoleCRUDs2 { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultCRUD")]
        public String DefaultCRUD { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "HasAccess")]
        public Nullable<Boolean> HasAccess { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Notes")]
        public String Notes { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Project")]
        [RemoteIsCollection]
        public String Project { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ProjectEmails")]
        [RemoteIsCollection]
        public String ProjectEmails { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ProjectRole")]
        [RemoteIsCollection]
        public String ProjectRole { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ProjectTable")]
        [RemoteIsCollection]
        public String ProjectTable { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ProjectVersion")]
        [RemoteIsCollection]
        public String ProjectVersion { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RoleDefaultCRUD")]
        [RemoteIsCollection]
        public String RoleDefaultCRUD { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RoleDefaultHasAccess")]
        [RemoteIsCollection]
        public Nullable<Boolean> RoleDefaultHasAccess { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "WhereClause")]
        public String WhereClause { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultCallCRUD")]
        public String DefaultCallCRUD { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "LastModifiedTime")]
        public Nullable<DateTime> LastModifiedTime { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultCRUD_legacy")]
        public String DefaultCRUD_legacy { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CallCRUD")]
        public String CallCRUD { get; set; }
    

        

        
        
        private static string CreateTableRoleWhereWhere(IEnumerable<TableRoleWhere> tableRoleWheres, String forignKeyFieldName = "TableRoleWhereId")
        {
            if (!tableRoleWheres.Any()) return "1=1";
            else 
            {
                var idList = tableRoleWheres.Select(selectTableRoleWhere => String.Format("'{0}'", selectTableRoleWhere.TableRoleWhereId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}
