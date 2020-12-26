using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using EAPI.CLI.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class AdminCLIHandler
    {
        public override void AddHelp(StringBuilder sb, string helpTerm)
        {
            sb.AppendLine($"Help for Admin.");
            
            helpTerm = helpTerm.ToLower();
            var found = helpTerm == "general";
            
            if (helpTerm == "general")
            {
                sb.AppendLine();
                
                sb.AppendLine($"PlanProduct: AddPlanProduct");
                sb.AppendLine($"PlanProduct: GetPlanProducts");
                sb.AppendLine($"PlanProduct: UpdatePlanProduct");
                sb.AppendLine($"void: DeletePlanProduct");
                sb.AppendLine($"ProjectTable: AddProjectTable");
                sb.AppendLine($"ProjectTable: GetProjectTables");
                sb.AppendLine($"ProjectTable: UpdateProjectTable");
                sb.AppendLine($"void: DeleteProjectTable");
                sb.AppendLine($"ServiceHostSize: AddServiceHostSize");
                sb.AppendLine($"ServiceHostSize: GetServiceHostSizes");
                sb.AppendLine($"ServiceHostSize: UpdateServiceHostSize");
                sb.AppendLine($"void: DeleteServiceHostSize");
                sb.AppendLine($"ColumnValue: AddColumnValue");
                sb.AppendLine($"ColumnValue: GetColumnValues");
                sb.AppendLine($"ColumnValue: UpdateColumnValue");
                sb.AppendLine($"void: DeleteColumnValue");
                sb.AppendLine($"PortfolioItem_RETIRED: AddPortfolioItemRETIRED");
                sb.AppendLine($"PortfolioItem_RETIRED: GetPortfolioItemsRETIRED");
                sb.AppendLine($"PortfolioItem_RETIRED: UpdatePortfolioItemRETIRED");
                sb.AppendLine($"void: DeletePortfolioItemRETIRED");
                sb.AppendLine($"ProjectStage: AddProjectStage");
                sb.AppendLine($"ProjectStage: GetProjectStages");
                sb.AppendLine($"ProjectStage: UpdateProjectStage");
                sb.AppendLine($"void: DeleteProjectStage");
                sb.AppendLine($"ProjectVersionBuild: AddProjectVersionBuild");
                sb.AppendLine($"ProjectVersionBuild: GetProjectVersionBuilds");
                sb.AppendLine($"ProjectVersionBuild: UpdateProjectVersionBuild");
                sb.AppendLine($"void: DeleteProjectVersionBuild");
                sb.AppendLine($"ProjectRole: AddProjectRole");
                sb.AppendLine($"ProjectRole: GetProjectRoles");
                sb.AppendLine($"ProjectRole: UpdateProjectRole");
                sb.AppendLine($"void: DeleteProjectRole");
                sb.AppendLine($"ServiceHostEndpoint: AddServiceHostEndpoint");
                sb.AppendLine($"ServiceHostEndpoint: GetServiceHostEndpoints");
                sb.AppendLine($"ServiceHostEndpoint: UpdateServiceHostEndpoint");
                sb.AppendLine($"void: DeleteServiceHostEndpoint");
                sb.AppendLine($"EffortlessAPIService: AddEffortlessAPIService");
                sb.AppendLine($"EffortlessAPIService: GetEffortlessAPIServices");
                sb.AppendLine($"EffortlessAPIService: UpdateEffortlessAPIService");
                sb.AppendLine($"void: DeleteEffortlessAPIService");
                sb.AppendLine($"ProjectConnection: AddProjectConnection");
                sb.AppendLine($"ProjectConnection: GetProjectConnections");
                sb.AppendLine($"ProjectConnection: UpdateProjectConnection");
                sb.AppendLine($"void: DeleteProjectConnection");
                sb.AppendLine($"ProjectLexiconTerm: AddProjectLexiconTerm");
                sb.AppendLine($"ProjectLexiconTerm: GetProjectLexiconTerms");
                sb.AppendLine($"ProjectLexiconTerm: UpdateProjectLexiconTerm");
                sb.AppendLine($"void: DeleteProjectLexiconTerm");
                sb.AppendLine($"Portfolio_RETIRED: AddPortfolioRETIRED");
                sb.AppendLine($"Portfolio_RETIRED: GetPortfoliosRETIRED");
                sb.AppendLine($"Portfolio_RETIRED: UpdatePortfolioRETIRED");
                sb.AppendLine($"void: DeletePortfolioRETIRED");
                sb.AppendLine($"ProjectEmail: AddProjectEmail");
                sb.AppendLine($"ProjectEmail: GetProjectEmails");
                sb.AppendLine($"ProjectEmail: UpdateProjectEmail");
                sb.AppendLine($"void: DeleteProjectEmail");
                sb.AppendLine($"ProjectVersion: AddProjectVersion");
                sb.AppendLine($"ProjectVersion: GetProjectVersions");
                sb.AppendLine($"ProjectVersion: UpdateProjectVersion");
                sb.AppendLine($"void: DeleteProjectVersion");
                sb.AppendLine($"ServiceHostType: AddServiceHostType");
                sb.AppendLine($"ServiceHostType: GetServiceHostTypes");
                sb.AppendLine($"ServiceHostType: UpdateServiceHostType");
                sb.AppendLine($"void: DeleteServiceHostType");
                sb.AppendLine($"RemoteEndpoint: AddRemoteEndpoint");
                sb.AppendLine($"RemoteEndpoint: GetRemoteEndpoints");
                sb.AppendLine($"RemoteEndpoint: UpdateRemoteEndpoint");
                sb.AppendLine($"void: DeleteRemoteEndpoint");
                sb.AppendLine($"EffortlessAPIAccount: AddEffortlessAPIAccount");
                sb.AppendLine($"EffortlessAPIAccount: GetEffortlessAPIAccounts");
                sb.AppendLine($"EffortlessAPIAccount: UpdateEffortlessAPIAccount");
                sb.AppendLine($"void: DeleteEffortlessAPIAccount");
                sb.AppendLine($"ServiceProduct: AddServiceProduct");
                sb.AppendLine($"ServiceProduct: GetServiceProducts");
                sb.AppendLine($"ServiceProduct: UpdateServiceProduct");
                sb.AppendLine($"void: DeleteServiceProduct");
                sb.AppendLine($"ProxyRelativeUrl: AddProxyRelativeUrl");
                sb.AppendLine($"ProxyRelativeUrl: GetProxyRelativeUrls");
                sb.AppendLine($"ProxyRelativeUrl: UpdateProxyRelativeUrl");
                sb.AppendLine($"void: DeleteProxyRelativeUrl");
                sb.AppendLine($"ProjectRequestSummary: AddProjectRequestSummary");
                sb.AppendLine($"ProjectRequestSummary: GetProjectRequestSummaries");
                sb.AppendLine($"ProjectRequestSummary: UpdateProjectRequestSummary");
                sb.AppendLine($"void: DeleteProjectRequestSummary");
                sb.AppendLine($"ServicePlan: AddServicePlan");
                sb.AppendLine($"ServicePlan: GetServicePlans");
                sb.AppendLine($"ServicePlan: UpdateServicePlan");
                sb.AppendLine($"void: DeleteServicePlan");
                sb.AppendLine($"ProjectIcon: AddProjectIcon");
                sb.AppendLine($"ProjectIcon: GetProjectIcons");
                sb.AppendLine($"ProjectIcon: UpdateProjectIcon");
                sb.AppendLine($"void: DeleteProjectIcon");
                sb.AppendLine($"TableColumn: AddTableColumn");
                sb.AppendLine($"TableColumn: GetTableColumns");
                sb.AppendLine($"TableColumn: UpdateTableColumn");
                sb.AppendLine($"void: DeleteTableColumn");
                sb.AppendLine($"TableRoleWhere: AddTableRoleWhere");
                sb.AppendLine($"TableRoleWhere: GetTableRoleWheres");
                sb.AppendLine($"TableRoleWhere: UpdateTableRoleWhere");
                sb.AppendLine($"void: DeleteTableRoleWhere");
                sb.AppendLine($"EffortlessAPIProject: AddEffortlessAPIProject");
                sb.AppendLine($"EffortlessAPIProject: GetEffortlessAPIProjects");
                sb.AppendLine($"EffortlessAPIProject: UpdateEffortlessAPIProject");
                sb.AppendLine($"void: DeleteEffortlessAPIProject");
                sb.AppendLine($"ColumnRoleCRUD: AddColumnRoleCRUD");
                sb.AppendLine($"ColumnRoleCRUD: GetColumnRoleCRUDs");
                sb.AppendLine($"ColumnRoleCRUD: UpdateColumnRoleCRUD");
                sb.AppendLine($"void: DeleteColumnRoleCRUD");
                sb.AppendLine($"SDKLanguage: AddSDKLanguage");
                sb.AppendLine($"SDKLanguage: GetSDKLanguages");
                sb.AppendLine($"SDKLanguage: UpdateSDKLanguage");
                sb.AppendLine($"void: DeleteSDKLanguage");
                sb.AppendLine($"ServiceKey: AddServiceKey");
                sb.AppendLine($"ServiceKey: GetServiceKeys");
                sb.AppendLine($"ServiceKey: UpdateServiceKey");
                sb.AppendLine($"void: DeleteServiceKey");
                sb.AppendLine($"CustomerType: AddCustomerType");
                sb.AppendLine($"CustomerType: GetCustomerTypes");
                sb.AppendLine($"CustomerType: UpdateCustomerType");
                sb.AppendLine($"void: DeleteCustomerType");                                            
            }
            
            sb.AppendLine($"{Environment.NewLine}Available Actions Matching: {helpTerm}");
            
            if ("addplanproduct".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddPlanProduct");
                if ("addplanproduct".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddPlanProductHelp(sb);
                }
                found = true;
            }
            if ("getplanproducts".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetPlanProducts");
                if ("getplanproducts".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetPlanProductsHelp(sb);
                }
                found = true;
            }
            if ("updateplanproduct".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdatePlanProduct");
                if ("updateplanproduct".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdatePlanProductHelp(sb);
                }
                found = true;
            }
            if ("deleteplanproduct".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeletePlanProduct");
                if ("deleteplanproduct".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeletePlanProductHelp(sb);
                }
                found = true;
            }
            if ("addprojecttable".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProjectTable");
                if ("addprojecttable".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProjectTableHelp(sb);
                }
                found = true;
            }
            if ("getprojecttables".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProjectTables");
                if ("getprojecttables".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProjectTablesHelp(sb);
                }
                found = true;
            }
            if ("updateprojecttable".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProjectTable");
                if ("updateprojecttable".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProjectTableHelp(sb);
                }
                found = true;
            }
            if ("deleteprojecttable".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProjectTable");
                if ("deleteprojecttable".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProjectTableHelp(sb);
                }
                found = true;
            }
            if ("addservicehostsize".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddServiceHostSize");
                if ("addservicehostsize".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddServiceHostSizeHelp(sb);
                }
                found = true;
            }
            if ("getservicehostsizes".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetServiceHostSizes");
                if ("getservicehostsizes".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetServiceHostSizesHelp(sb);
                }
                found = true;
            }
            if ("updateservicehostsize".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateServiceHostSize");
                if ("updateservicehostsize".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateServiceHostSizeHelp(sb);
                }
                found = true;
            }
            if ("deleteservicehostsize".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteServiceHostSize");
                if ("deleteservicehostsize".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteServiceHostSizeHelp(sb);
                }
                found = true;
            }
            if ("addcolumnvalue".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddColumnValue");
                if ("addcolumnvalue".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddColumnValueHelp(sb);
                }
                found = true;
            }
            if ("getcolumnvalues".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetColumnValues");
                if ("getcolumnvalues".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetColumnValuesHelp(sb);
                }
                found = true;
            }
            if ("updatecolumnvalue".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateColumnValue");
                if ("updatecolumnvalue".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateColumnValueHelp(sb);
                }
                found = true;
            }
            if ("deletecolumnvalue".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteColumnValue");
                if ("deletecolumnvalue".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteColumnValueHelp(sb);
                }
                found = true;
            }
            if ("addportfolioitemretired".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddPortfolioItemRETIRED");
                if ("addportfolioitemretired".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddPortfolioItemRETIREDHelp(sb);
                }
                found = true;
            }
            if ("getportfolioitemsretired".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetPortfolioItemsRETIRED");
                if ("getportfolioitemsretired".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetPortfolioItemsRETIREDHelp(sb);
                }
                found = true;
            }
            if ("updateportfolioitemretired".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdatePortfolioItemRETIRED");
                if ("updateportfolioitemretired".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdatePortfolioItemRETIREDHelp(sb);
                }
                found = true;
            }
            if ("deleteportfolioitemretired".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeletePortfolioItemRETIRED");
                if ("deleteportfolioitemretired".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeletePortfolioItemRETIREDHelp(sb);
                }
                found = true;
            }
            if ("addprojectstage".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProjectStage");
                if ("addprojectstage".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProjectStageHelp(sb);
                }
                found = true;
            }
            if ("getprojectstages".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProjectStages");
                if ("getprojectstages".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProjectStagesHelp(sb);
                }
                found = true;
            }
            if ("updateprojectstage".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProjectStage");
                if ("updateprojectstage".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProjectStageHelp(sb);
                }
                found = true;
            }
            if ("deleteprojectstage".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProjectStage");
                if ("deleteprojectstage".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProjectStageHelp(sb);
                }
                found = true;
            }
            if ("addprojectversionbuild".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProjectVersionBuild");
                if ("addprojectversionbuild".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProjectVersionBuildHelp(sb);
                }
                found = true;
            }
            if ("getprojectversionbuilds".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProjectVersionBuilds");
                if ("getprojectversionbuilds".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProjectVersionBuildsHelp(sb);
                }
                found = true;
            }
            if ("updateprojectversionbuild".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProjectVersionBuild");
                if ("updateprojectversionbuild".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProjectVersionBuildHelp(sb);
                }
                found = true;
            }
            if ("deleteprojectversionbuild".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProjectVersionBuild");
                if ("deleteprojectversionbuild".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProjectVersionBuildHelp(sb);
                }
                found = true;
            }
            if ("addprojectrole".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProjectRole");
                if ("addprojectrole".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProjectRoleHelp(sb);
                }
                found = true;
            }
            if ("getprojectroles".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProjectRoles");
                if ("getprojectroles".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProjectRolesHelp(sb);
                }
                found = true;
            }
            if ("updateprojectrole".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProjectRole");
                if ("updateprojectrole".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProjectRoleHelp(sb);
                }
                found = true;
            }
            if ("deleteprojectrole".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProjectRole");
                if ("deleteprojectrole".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProjectRoleHelp(sb);
                }
                found = true;
            }
            if ("addservicehostendpoint".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddServiceHostEndpoint");
                if ("addservicehostendpoint".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddServiceHostEndpointHelp(sb);
                }
                found = true;
            }
            if ("getservicehostendpoints".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetServiceHostEndpoints");
                if ("getservicehostendpoints".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetServiceHostEndpointsHelp(sb);
                }
                found = true;
            }
            if ("updateservicehostendpoint".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateServiceHostEndpoint");
                if ("updateservicehostendpoint".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateServiceHostEndpointHelp(sb);
                }
                found = true;
            }
            if ("deleteservicehostendpoint".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteServiceHostEndpoint");
                if ("deleteservicehostendpoint".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteServiceHostEndpointHelp(sb);
                }
                found = true;
            }
            if ("addeffortlessapiservice".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddEffortlessAPIService");
                if ("addeffortlessapiservice".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddEffortlessAPIServiceHelp(sb);
                }
                found = true;
            }
            if ("geteffortlessapiservices".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetEffortlessAPIServices");
                if ("geteffortlessapiservices".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetEffortlessAPIServicesHelp(sb);
                }
                found = true;
            }
            if ("updateeffortlessapiservice".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateEffortlessAPIService");
                if ("updateeffortlessapiservice".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateEffortlessAPIServiceHelp(sb);
                }
                found = true;
            }
            if ("deleteeffortlessapiservice".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteEffortlessAPIService");
                if ("deleteeffortlessapiservice".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteEffortlessAPIServiceHelp(sb);
                }
                found = true;
            }
            if ("addprojectconnection".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProjectConnection");
                if ("addprojectconnection".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProjectConnectionHelp(sb);
                }
                found = true;
            }
            if ("getprojectconnections".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProjectConnections");
                if ("getprojectconnections".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProjectConnectionsHelp(sb);
                }
                found = true;
            }
            if ("updateprojectconnection".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProjectConnection");
                if ("updateprojectconnection".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProjectConnectionHelp(sb);
                }
                found = true;
            }
            if ("deleteprojectconnection".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProjectConnection");
                if ("deleteprojectconnection".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProjectConnectionHelp(sb);
                }
                found = true;
            }
            if ("addprojectlexiconterm".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProjectLexiconTerm");
                if ("addprojectlexiconterm".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProjectLexiconTermHelp(sb);
                }
                found = true;
            }
            if ("getprojectlexiconterms".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProjectLexiconTerms");
                if ("getprojectlexiconterms".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProjectLexiconTermsHelp(sb);
                }
                found = true;
            }
            if ("updateprojectlexiconterm".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProjectLexiconTerm");
                if ("updateprojectlexiconterm".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProjectLexiconTermHelp(sb);
                }
                found = true;
            }
            if ("deleteprojectlexiconterm".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProjectLexiconTerm");
                if ("deleteprojectlexiconterm".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProjectLexiconTermHelp(sb);
                }
                found = true;
            }
            if ("addportfolioretired".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddPortfolioRETIRED");
                if ("addportfolioretired".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddPortfolioRETIREDHelp(sb);
                }
                found = true;
            }
            if ("getportfoliosretired".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetPortfoliosRETIRED");
                if ("getportfoliosretired".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetPortfoliosRETIREDHelp(sb);
                }
                found = true;
            }
            if ("updateportfolioretired".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdatePortfolioRETIRED");
                if ("updateportfolioretired".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdatePortfolioRETIREDHelp(sb);
                }
                found = true;
            }
            if ("deleteportfolioretired".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeletePortfolioRETIRED");
                if ("deleteportfolioretired".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeletePortfolioRETIREDHelp(sb);
                }
                found = true;
            }
            if ("addprojectemail".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProjectEmail");
                if ("addprojectemail".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProjectEmailHelp(sb);
                }
                found = true;
            }
            if ("getprojectemails".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProjectEmails");
                if ("getprojectemails".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProjectEmailsHelp(sb);
                }
                found = true;
            }
            if ("updateprojectemail".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProjectEmail");
                if ("updateprojectemail".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProjectEmailHelp(sb);
                }
                found = true;
            }
            if ("deleteprojectemail".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProjectEmail");
                if ("deleteprojectemail".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProjectEmailHelp(sb);
                }
                found = true;
            }
            if ("addprojectversion".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProjectVersion");
                if ("addprojectversion".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProjectVersionHelp(sb);
                }
                found = true;
            }
            if ("getprojectversions".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProjectVersions");
                if ("getprojectversions".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProjectVersionsHelp(sb);
                }
                found = true;
            }
            if ("updateprojectversion".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProjectVersion");
                if ("updateprojectversion".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProjectVersionHelp(sb);
                }
                found = true;
            }
            if ("deleteprojectversion".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProjectVersion");
                if ("deleteprojectversion".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProjectVersionHelp(sb);
                }
                found = true;
            }
            if ("addservicehosttype".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddServiceHostType");
                if ("addservicehosttype".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddServiceHostTypeHelp(sb);
                }
                found = true;
            }
            if ("getservicehosttypes".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetServiceHostTypes");
                if ("getservicehosttypes".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetServiceHostTypesHelp(sb);
                }
                found = true;
            }
            if ("updateservicehosttype".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateServiceHostType");
                if ("updateservicehosttype".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateServiceHostTypeHelp(sb);
                }
                found = true;
            }
            if ("deleteservicehosttype".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteServiceHostType");
                if ("deleteservicehosttype".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteServiceHostTypeHelp(sb);
                }
                found = true;
            }
            if ("addremoteendpoint".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddRemoteEndpoint");
                if ("addremoteendpoint".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddRemoteEndpointHelp(sb);
                }
                found = true;
            }
            if ("getremoteendpoints".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetRemoteEndpoints");
                if ("getremoteendpoints".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetRemoteEndpointsHelp(sb);
                }
                found = true;
            }
            if ("updateremoteendpoint".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateRemoteEndpoint");
                if ("updateremoteendpoint".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateRemoteEndpointHelp(sb);
                }
                found = true;
            }
            if ("deleteremoteendpoint".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteRemoteEndpoint");
                if ("deleteremoteendpoint".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteRemoteEndpointHelp(sb);
                }
                found = true;
            }
            if ("addeffortlessapiaccount".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddEffortlessAPIAccount");
                if ("addeffortlessapiaccount".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddEffortlessAPIAccountHelp(sb);
                }
                found = true;
            }
            if ("geteffortlessapiaccounts".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetEffortlessAPIAccounts");
                if ("geteffortlessapiaccounts".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetEffortlessAPIAccountsHelp(sb);
                }
                found = true;
            }
            if ("updateeffortlessapiaccount".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateEffortlessAPIAccount");
                if ("updateeffortlessapiaccount".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateEffortlessAPIAccountHelp(sb);
                }
                found = true;
            }
            if ("deleteeffortlessapiaccount".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteEffortlessAPIAccount");
                if ("deleteeffortlessapiaccount".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteEffortlessAPIAccountHelp(sb);
                }
                found = true;
            }
            if ("addserviceproduct".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddServiceProduct");
                if ("addserviceproduct".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddServiceProductHelp(sb);
                }
                found = true;
            }
            if ("getserviceproducts".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetServiceProducts");
                if ("getserviceproducts".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetServiceProductsHelp(sb);
                }
                found = true;
            }
            if ("updateserviceproduct".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateServiceProduct");
                if ("updateserviceproduct".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateServiceProductHelp(sb);
                }
                found = true;
            }
            if ("deleteserviceproduct".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteServiceProduct");
                if ("deleteserviceproduct".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteServiceProductHelp(sb);
                }
                found = true;
            }
            if ("addproxyrelativeurl".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProxyRelativeUrl");
                if ("addproxyrelativeurl".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProxyRelativeUrlHelp(sb);
                }
                found = true;
            }
            if ("getproxyrelativeurls".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProxyRelativeUrls");
                if ("getproxyrelativeurls".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProxyRelativeUrlsHelp(sb);
                }
                found = true;
            }
            if ("updateproxyrelativeurl".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProxyRelativeUrl");
                if ("updateproxyrelativeurl".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProxyRelativeUrlHelp(sb);
                }
                found = true;
            }
            if ("deleteproxyrelativeurl".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProxyRelativeUrl");
                if ("deleteproxyrelativeurl".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProxyRelativeUrlHelp(sb);
                }
                found = true;
            }
            if ("addprojectrequestsummary".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProjectRequestSummary");
                if ("addprojectrequestsummary".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProjectRequestSummaryHelp(sb);
                }
                found = true;
            }
            if ("getprojectrequestsummaries".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProjectRequestSummaries");
                if ("getprojectrequestsummaries".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProjectRequestSummariesHelp(sb);
                }
                found = true;
            }
            if ("updateprojectrequestsummary".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProjectRequestSummary");
                if ("updateprojectrequestsummary".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProjectRequestSummaryHelp(sb);
                }
                found = true;
            }
            if ("deleteprojectrequestsummary".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProjectRequestSummary");
                if ("deleteprojectrequestsummary".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProjectRequestSummaryHelp(sb);
                }
                found = true;
            }
            if ("addserviceplan".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddServicePlan");
                if ("addserviceplan".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddServicePlanHelp(sb);
                }
                found = true;
            }
            if ("getserviceplans".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetServicePlans");
                if ("getserviceplans".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetServicePlansHelp(sb);
                }
                found = true;
            }
            if ("updateserviceplan".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateServicePlan");
                if ("updateserviceplan".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateServicePlanHelp(sb);
                }
                found = true;
            }
            if ("deleteserviceplan".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteServicePlan");
                if ("deleteserviceplan".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteServicePlanHelp(sb);
                }
                found = true;
            }
            if ("addprojecticon".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddProjectIcon");
                if ("addprojecticon".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddProjectIconHelp(sb);
                }
                found = true;
            }
            if ("getprojecticons".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetProjectIcons");
                if ("getprojecticons".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetProjectIconsHelp(sb);
                }
                found = true;
            }
            if ("updateprojecticon".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateProjectIcon");
                if ("updateprojecticon".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateProjectIconHelp(sb);
                }
                found = true;
            }
            if ("deleteprojecticon".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteProjectIcon");
                if ("deleteprojecticon".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteProjectIconHelp(sb);
                }
                found = true;
            }
            if ("addtablecolumn".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddTableColumn");
                if ("addtablecolumn".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddTableColumnHelp(sb);
                }
                found = true;
            }
            if ("gettablecolumns".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetTableColumns");
                if ("gettablecolumns".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetTableColumnsHelp(sb);
                }
                found = true;
            }
            if ("updatetablecolumn".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateTableColumn");
                if ("updatetablecolumn".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateTableColumnHelp(sb);
                }
                found = true;
            }
            if ("deletetablecolumn".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteTableColumn");
                if ("deletetablecolumn".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteTableColumnHelp(sb);
                }
                found = true;
            }
            if ("addtablerolewhere".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddTableRoleWhere");
                if ("addtablerolewhere".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddTableRoleWhereHelp(sb);
                }
                found = true;
            }
            if ("gettablerolewheres".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetTableRoleWheres");
                if ("gettablerolewheres".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetTableRoleWheresHelp(sb);
                }
                found = true;
            }
            if ("updatetablerolewhere".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateTableRoleWhere");
                if ("updatetablerolewhere".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateTableRoleWhereHelp(sb);
                }
                found = true;
            }
            if ("deletetablerolewhere".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteTableRoleWhere");
                if ("deletetablerolewhere".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteTableRoleWhereHelp(sb);
                }
                found = true;
            }
            if ("addeffortlessapiproject".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddEffortlessAPIProject");
                if ("addeffortlessapiproject".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddEffortlessAPIProjectHelp(sb);
                }
                found = true;
            }
            if ("geteffortlessapiprojects".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetEffortlessAPIProjects");
                if ("geteffortlessapiprojects".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetEffortlessAPIProjectsHelp(sb);
                }
                found = true;
            }
            if ("updateeffortlessapiproject".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateEffortlessAPIProject");
                if ("updateeffortlessapiproject".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateEffortlessAPIProjectHelp(sb);
                }
                found = true;
            }
            if ("deleteeffortlessapiproject".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteEffortlessAPIProject");
                if ("deleteeffortlessapiproject".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteEffortlessAPIProjectHelp(sb);
                }
                found = true;
            }
            if ("addcolumnrolecrud".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddColumnRoleCRUD");
                if ("addcolumnrolecrud".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddColumnRoleCRUDHelp(sb);
                }
                found = true;
            }
            if ("getcolumnrolecruds".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetColumnRoleCRUDs");
                if ("getcolumnrolecruds".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetColumnRoleCRUDsHelp(sb);
                }
                found = true;
            }
            if ("updatecolumnrolecrud".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateColumnRoleCRUD");
                if ("updatecolumnrolecrud".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateColumnRoleCRUDHelp(sb);
                }
                found = true;
            }
            if ("deletecolumnrolecrud".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteColumnRoleCRUD");
                if ("deletecolumnrolecrud".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteColumnRoleCRUDHelp(sb);
                }
                found = true;
            }
            if ("addsdklanguage".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddSDKLanguage");
                if ("addsdklanguage".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddSDKLanguageHelp(sb);
                }
                found = true;
            }
            if ("getsdklanguages".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetSDKLanguages");
                if ("getsdklanguages".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetSDKLanguagesHelp(sb);
                }
                found = true;
            }
            if ("updatesdklanguage".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateSDKLanguage");
                if ("updatesdklanguage".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateSDKLanguageHelp(sb);
                }
                found = true;
            }
            if ("deletesdklanguage".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteSDKLanguage");
                if ("deletesdklanguage".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteSDKLanguageHelp(sb);
                }
                found = true;
            }
            if ("addservicekey".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddServiceKey");
                if ("addservicekey".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddServiceKeyHelp(sb);
                }
                found = true;
            }
            if ("getservicekeys".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetServiceKeys");
                if ("getservicekeys".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetServiceKeysHelp(sb);
                }
                found = true;
            }
            if ("updateservicekey".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateServiceKey");
                if ("updateservicekey".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateServiceKeyHelp(sb);
                }
                found = true;
            }
            if ("deleteservicekey".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteServiceKey");
                if ("deleteservicekey".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteServiceKeyHelp(sb);
                }
                found = true;
            }
            if ("addcustomertype".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddCustomerType");
                if ("addcustomertype".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddCustomerTypeHelp(sb);
                }
                found = true;
            }
            if ("getcustomertypes".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetCustomerTypes");
                if ("getcustomertypes".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetCustomerTypesHelp(sb);
                }
                found = true;
            }
            if ("updatecustomertype".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateCustomerType");
                if ("updatecustomertype".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateCustomerTypeHelp(sb);
                }
                found = true;
            }
            if ("deletecustomertype".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteCustomerType");
                if ("deletecustomertype".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteCustomerTypeHelp(sb);
                }
                found = true;
            }
                       
            if (!found)
            {
                sb.AppendLine();
                sb.AppendLine($"{Environment.NewLine}UNABLE TO FIND COMMAND: {helpTerm} not found.");
            }
        }

        private string HandlerFactory(string invokeRequest, string payloadString, string where)
        {
            var result = "";
            var payload = JsonConvert.DeserializeObject<StandardPayload>(payloadString);
            payload.SetActor(this.SMQActor);
            payload.AccessToken = this.SMQActor.AccessToken;
            payload.AirtableWhere = where;

            switch (invokeRequest.ToLower())
            {
                case "addplanproduct":
                    this.SMQActor.AddPlanProduct(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getplanproducts":
                    this.SMQActor.GetPlanProducts(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateplanproduct":
                    this.SMQActor.UpdatePlanProduct(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteplanproduct":
                    this.SMQActor.DeletePlanProduct(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addprojecttable":
                    this.SMQActor.AddProjectTable(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getprojecttables":
                    this.SMQActor.GetProjectTables(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateprojecttable":
                    this.SMQActor.UpdateProjectTable(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteprojecttable":
                    this.SMQActor.DeleteProjectTable(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addservicehostsize":
                    this.SMQActor.AddServiceHostSize(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getservicehostsizes":
                    this.SMQActor.GetServiceHostSizes(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateservicehostsize":
                    this.SMQActor.UpdateServiceHostSize(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteservicehostsize":
                    this.SMQActor.DeleteServiceHostSize(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addcolumnvalue":
                    this.SMQActor.AddColumnValue(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcolumnvalues":
                    this.SMQActor.GetColumnValues(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatecolumnvalue":
                    this.SMQActor.UpdateColumnValue(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletecolumnvalue":
                    this.SMQActor.DeleteColumnValue(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addportfolioitemretired":
                    this.SMQActor.AddPortfolioItemRETIRED(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getportfolioitemsretired":
                    this.SMQActor.GetPortfolioItemsRETIRED(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateportfolioitemretired":
                    this.SMQActor.UpdatePortfolioItemRETIRED(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteportfolioitemretired":
                    this.SMQActor.DeletePortfolioItemRETIRED(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addprojectstage":
                    this.SMQActor.AddProjectStage(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getprojectstages":
                    this.SMQActor.GetProjectStages(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateprojectstage":
                    this.SMQActor.UpdateProjectStage(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteprojectstage":
                    this.SMQActor.DeleteProjectStage(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addprojectversionbuild":
                    this.SMQActor.AddProjectVersionBuild(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getprojectversionbuilds":
                    this.SMQActor.GetProjectVersionBuilds(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateprojectversionbuild":
                    this.SMQActor.UpdateProjectVersionBuild(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteprojectversionbuild":
                    this.SMQActor.DeleteProjectVersionBuild(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addprojectrole":
                    this.SMQActor.AddProjectRole(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getprojectroles":
                    this.SMQActor.GetProjectRoles(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateprojectrole":
                    this.SMQActor.UpdateProjectRole(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteprojectrole":
                    this.SMQActor.DeleteProjectRole(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addservicehostendpoint":
                    this.SMQActor.AddServiceHostEndpoint(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getservicehostendpoints":
                    this.SMQActor.GetServiceHostEndpoints(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateservicehostendpoint":
                    this.SMQActor.UpdateServiceHostEndpoint(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteservicehostendpoint":
                    this.SMQActor.DeleteServiceHostEndpoint(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addeffortlessapiservice":
                    this.SMQActor.AddEffortlessAPIService(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "geteffortlessapiservices":
                    this.SMQActor.GetEffortlessAPIServices(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateeffortlessapiservice":
                    this.SMQActor.UpdateEffortlessAPIService(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteeffortlessapiservice":
                    this.SMQActor.DeleteEffortlessAPIService(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addprojectconnection":
                    this.SMQActor.AddProjectConnection(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getprojectconnections":
                    this.SMQActor.GetProjectConnections(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateprojectconnection":
                    this.SMQActor.UpdateProjectConnection(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteprojectconnection":
                    this.SMQActor.DeleteProjectConnection(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addprojectlexiconterm":
                    this.SMQActor.AddProjectLexiconTerm(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getprojectlexiconterms":
                    this.SMQActor.GetProjectLexiconTerms(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateprojectlexiconterm":
                    this.SMQActor.UpdateProjectLexiconTerm(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteprojectlexiconterm":
                    this.SMQActor.DeleteProjectLexiconTerm(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addportfolioretired":
                    this.SMQActor.AddPortfolioRETIRED(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getportfoliosretired":
                    this.SMQActor.GetPortfoliosRETIRED(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateportfolioretired":
                    this.SMQActor.UpdatePortfolioRETIRED(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteportfolioretired":
                    this.SMQActor.DeletePortfolioRETIRED(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addprojectemail":
                    this.SMQActor.AddProjectEmail(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getprojectemails":
                    this.SMQActor.GetProjectEmails(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateprojectemail":
                    this.SMQActor.UpdateProjectEmail(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteprojectemail":
                    this.SMQActor.DeleteProjectEmail(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addprojectversion":
                    this.SMQActor.AddProjectVersion(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getprojectversions":
                    this.SMQActor.GetProjectVersions(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateprojectversion":
                    this.SMQActor.UpdateProjectVersion(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteprojectversion":
                    this.SMQActor.DeleteProjectVersion(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addservicehosttype":
                    this.SMQActor.AddServiceHostType(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getservicehosttypes":
                    this.SMQActor.GetServiceHostTypes(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateservicehosttype":
                    this.SMQActor.UpdateServiceHostType(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteservicehosttype":
                    this.SMQActor.DeleteServiceHostType(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addremoteendpoint":
                    this.SMQActor.AddRemoteEndpoint(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getremoteendpoints":
                    this.SMQActor.GetRemoteEndpoints(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateremoteendpoint":
                    this.SMQActor.UpdateRemoteEndpoint(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteremoteendpoint":
                    this.SMQActor.DeleteRemoteEndpoint(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addeffortlessapiaccount":
                    this.SMQActor.AddEffortlessAPIAccount(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "geteffortlessapiaccounts":
                    this.SMQActor.GetEffortlessAPIAccounts(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateeffortlessapiaccount":
                    this.SMQActor.UpdateEffortlessAPIAccount(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteeffortlessapiaccount":
                    this.SMQActor.DeleteEffortlessAPIAccount(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addserviceproduct":
                    this.SMQActor.AddServiceProduct(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getserviceproducts":
                    this.SMQActor.GetServiceProducts(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateserviceproduct":
                    this.SMQActor.UpdateServiceProduct(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteserviceproduct":
                    this.SMQActor.DeleteServiceProduct(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addproxyrelativeurl":
                    this.SMQActor.AddProxyRelativeUrl(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getproxyrelativeurls":
                    this.SMQActor.GetProxyRelativeUrls(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateproxyrelativeurl":
                    this.SMQActor.UpdateProxyRelativeUrl(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteproxyrelativeurl":
                    this.SMQActor.DeleteProxyRelativeUrl(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addprojectrequestsummary":
                    this.SMQActor.AddProjectRequestSummary(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getprojectrequestsummaries":
                    this.SMQActor.GetProjectRequestSummaries(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateprojectrequestsummary":
                    this.SMQActor.UpdateProjectRequestSummary(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteprojectrequestsummary":
                    this.SMQActor.DeleteProjectRequestSummary(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addserviceplan":
                    this.SMQActor.AddServicePlan(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getserviceplans":
                    this.SMQActor.GetServicePlans(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateserviceplan":
                    this.SMQActor.UpdateServicePlan(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteserviceplan":
                    this.SMQActor.DeleteServicePlan(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addprojecticon":
                    this.SMQActor.AddProjectIcon(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getprojecticons":
                    this.SMQActor.GetProjectIcons(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateprojecticon":
                    this.SMQActor.UpdateProjectIcon(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteprojecticon":
                    this.SMQActor.DeleteProjectIcon(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addtablecolumn":
                    this.SMQActor.AddTableColumn(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "gettablecolumns":
                    this.SMQActor.GetTableColumns(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatetablecolumn":
                    this.SMQActor.UpdateTableColumn(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletetablecolumn":
                    this.SMQActor.DeleteTableColumn(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addtablerolewhere":
                    this.SMQActor.AddTableRoleWhere(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "gettablerolewheres":
                    this.SMQActor.GetTableRoleWheres(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatetablerolewhere":
                    this.SMQActor.UpdateTableRoleWhere(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletetablerolewhere":
                    this.SMQActor.DeleteTableRoleWhere(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addeffortlessapiproject":
                    this.SMQActor.AddEffortlessAPIProject(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "geteffortlessapiprojects":
                    this.SMQActor.GetEffortlessAPIProjects(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateeffortlessapiproject":
                    this.SMQActor.UpdateEffortlessAPIProject(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteeffortlessapiproject":
                    this.SMQActor.DeleteEffortlessAPIProject(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addcolumnrolecrud":
                    this.SMQActor.AddColumnRoleCRUD(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcolumnrolecruds":
                    this.SMQActor.GetColumnRoleCRUDs(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatecolumnrolecrud":
                    this.SMQActor.UpdateColumnRoleCRUD(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletecolumnrolecrud":
                    this.SMQActor.DeleteColumnRoleCRUD(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addsdklanguage":
                    this.SMQActor.AddSDKLanguage(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getsdklanguages":
                    this.SMQActor.GetSDKLanguages(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatesdklanguage":
                    this.SMQActor.UpdateSDKLanguage(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletesdklanguage":
                    this.SMQActor.DeleteSDKLanguage(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addservicekey":
                    this.SMQActor.AddServiceKey(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getservicekeys":
                    this.SMQActor.GetServiceKeys(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateservicekey":
                    this.SMQActor.UpdateServiceKey(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteservicekey":
                    this.SMQActor.DeleteServiceKey(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addcustomertype":
                    this.SMQActor.AddCustomerType(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcustomertypes":
                    this.SMQActor.GetCustomerTypes(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatecustomertype":
                    this.SMQActor.UpdateCustomerType(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletecustomertype":
                    this.SMQActor.DeleteCustomerType(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                default:
                    throw new Exception($"Invalid request: {invokeRequest}");
            }

            return result;
        }
        
        
        public void PrintAddPlanProductHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: PlanProduct     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - PlanProductId");
                    sb.AppendLine($"CRUD      - AdjustmentAmount");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - EffectiveQuantity");
                    sb.AppendLine($"CRUD      - FinalQuantity");
                    sb.AppendLine($"CRUD      - FinalQuantityUnitCost");
                    sb.AppendLine($"CRUD      - HighEndUser");
                    sb.AppendLine($"CRUD      - HighEndUserMonthlySubscription");
                    sb.AppendLine($"CRUD      - Included");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - IsIncludedByDefault");
                    sb.AppendLine($"CRUD      - Max");
                    sb.AppendLine($"CRUD      - Min");
                    sb.AppendLine($"CRUD      - MonthlySubscription");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PlanDiscount");
                    sb.AppendLine($"CRUD      - PlanPrice");
                    sb.AppendLine($"CRUD      - PricingModel");
                    sb.AppendLine($"CRUD      - ProductDescriptions");
                    sb.AppendLine($"CRUD      - ProductLogo");
                    sb.AppendLine($"CRUD      - ProductSortOrder");
                    sb.AppendLine($"CRUD      - RadioGroup");
                    sb.AppendLine($"CRUD      - ServicePlan");
                    sb.AppendLine($"CRUD      - ServicePlanName");
                    sb.AppendLine($"CRUD      - ServiceProduct");
                    sb.AppendLine($"CRUD      - SuggestedMSRP");
                    sb.AppendLine($"CRUD      - SuggestedPlanPrice");
                    sb.AppendLine($"CRUD      - UnitPrice");
                    sb.AppendLine($"CRUD      - UnitPriceAdjustment");
                    sb.AppendLine($"CRUD      - VolumeScalePercent");
                
            
        }
        
        public void PrintGetPlanProductsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: PlanProduct     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - PlanProductId");
                    sb.AppendLine($"CRUD      - AdjustmentAmount");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - EffectiveQuantity");
                    sb.AppendLine($"CRUD      - FinalQuantity");
                    sb.AppendLine($"CRUD      - FinalQuantityUnitCost");
                    sb.AppendLine($"CRUD      - HighEndUser");
                    sb.AppendLine($"CRUD      - HighEndUserMonthlySubscription");
                    sb.AppendLine($"CRUD      - Included");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - IsIncludedByDefault");
                    sb.AppendLine($"CRUD      - Max");
                    sb.AppendLine($"CRUD      - Min");
                    sb.AppendLine($"CRUD      - MonthlySubscription");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PlanDiscount");
                    sb.AppendLine($"CRUD      - PlanPrice");
                    sb.AppendLine($"CRUD      - PricingModel");
                    sb.AppendLine($"CRUD      - ProductDescriptions");
                    sb.AppendLine($"CRUD      - ProductLogo");
                    sb.AppendLine($"CRUD      - ProductSortOrder");
                    sb.AppendLine($"CRUD      - RadioGroup");
                    sb.AppendLine($"CRUD      - ServicePlan");
                    sb.AppendLine($"CRUD      - ServicePlanName");
                    sb.AppendLine($"CRUD      - ServiceProduct");
                    sb.AppendLine($"CRUD      - SuggestedMSRP");
                    sb.AppendLine($"CRUD      - SuggestedPlanPrice");
                    sb.AppendLine($"CRUD      - UnitPrice");
                    sb.AppendLine($"CRUD      - UnitPriceAdjustment");
                    sb.AppendLine($"CRUD      - VolumeScalePercent");
                
            
        }
        
        public void PrintUpdatePlanProductHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: PlanProduct     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - PlanProductId");
                    sb.AppendLine($"CRUD      - AdjustmentAmount");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - EffectiveQuantity");
                    sb.AppendLine($"CRUD      - FinalQuantity");
                    sb.AppendLine($"CRUD      - FinalQuantityUnitCost");
                    sb.AppendLine($"CRUD      - HighEndUser");
                    sb.AppendLine($"CRUD      - HighEndUserMonthlySubscription");
                    sb.AppendLine($"CRUD      - Included");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - IsIncludedByDefault");
                    sb.AppendLine($"CRUD      - Max");
                    sb.AppendLine($"CRUD      - Min");
                    sb.AppendLine($"CRUD      - MonthlySubscription");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PlanDiscount");
                    sb.AppendLine($"CRUD      - PlanPrice");
                    sb.AppendLine($"CRUD      - PricingModel");
                    sb.AppendLine($"CRUD      - ProductDescriptions");
                    sb.AppendLine($"CRUD      - ProductLogo");
                    sb.AppendLine($"CRUD      - ProductSortOrder");
                    sb.AppendLine($"CRUD      - RadioGroup");
                    sb.AppendLine($"CRUD      - ServicePlan");
                    sb.AppendLine($"CRUD      - ServicePlanName");
                    sb.AppendLine($"CRUD      - ServiceProduct");
                    sb.AppendLine($"CRUD      - SuggestedMSRP");
                    sb.AppendLine($"CRUD      - SuggestedPlanPrice");
                    sb.AppendLine($"CRUD      - UnitPrice");
                    sb.AppendLine($"CRUD      - UnitPriceAdjustment");
                    sb.AppendLine($"CRUD      - VolumeScalePercent");
                
            
        }
        
        public void PrintDeletePlanProductHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProjectTableHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectTable     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectTableId");
                    sb.AppendLine($"CRUD      - IsEnumeration");
                    sb.AppendLine($"CRUD      - AirtableName");
                    sb.AppendLine($"CRUD      - AppRoleTableForProject");
                    sb.AppendLine($"CRUD      - AppUserTableForProject");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CreatedAt");
                    sb.AppendLine($"CRUD      - Description");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - DoubleCheckCRUD");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - PluralName");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - TableColumns");
                    sb.AppendLine($"CRUD      - TableGroup");
                    sb.AppendLine($"CRUD      - TableRoleWhere");
                    sb.AppendLine($"CRUD      - TablesTableForProject");
                    sb.AppendLine($"CRUD      - ToName");
                    sb.AppendLine($"CRUD      - IsExcluded");
                
            
        }
        
        public void PrintGetProjectTablesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectTable     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectTableId");
                    sb.AppendLine($"CRUD      - IsEnumeration");
                    sb.AppendLine($"CRUD      - AirtableName");
                    sb.AppendLine($"CRUD      - AppRoleTableForProject");
                    sb.AppendLine($"CRUD      - AppUserTableForProject");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CreatedAt");
                    sb.AppendLine($"CRUD      - Description");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - DoubleCheckCRUD");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - PluralName");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - TableColumns");
                    sb.AppendLine($"CRUD      - TableGroup");
                    sb.AppendLine($"CRUD      - TableRoleWhere");
                    sb.AppendLine($"CRUD      - TablesTableForProject");
                    sb.AppendLine($"CRUD      - ToName");
                    sb.AppendLine($"CRUD      - IsExcluded");
                
            
        }
        
        public void PrintUpdateProjectTableHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectTable     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectTableId");
                    sb.AppendLine($"CRUD      - IsEnumeration");
                    sb.AppendLine($"CRUD      - AirtableName");
                    sb.AppendLine($"CRUD      - AppRoleTableForProject");
                    sb.AppendLine($"CRUD      - AppUserTableForProject");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CreatedAt");
                    sb.AppendLine($"CRUD      - Description");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - DoubleCheckCRUD");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - PluralName");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - TableColumns");
                    sb.AppendLine($"CRUD      - TableGroup");
                    sb.AppendLine($"CRUD      - TableRoleWhere");
                    sb.AppendLine($"CRUD      - TablesTableForProject");
                    sb.AppendLine($"CRUD      - ToName");
                    sb.AppendLine($"CRUD      - IsExcluded");
                
            
        }
        
        public void PrintDeleteProjectTableHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddServiceHostSizeHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostSize     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceHostSizeId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ServiceHostEndpoints");
                
            
        }
        
        public void PrintGetServiceHostSizesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostSize     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceHostSizeId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ServiceHostEndpoints");
                
            
        }
        
        public void PrintUpdateServiceHostSizeHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostSize     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceHostSizeId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ServiceHostEndpoints");
                
            
        }
        
        public void PrintDeleteServiceHostSizeHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddColumnValueHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ColumnValue     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ColumnValueId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - TableColumn");
                    sb.AppendLine($"CRUD      - Color");
                    sb.AppendLine($"CRUD      - DataValue");
                    sb.AppendLine($"CRUD      - TableColumnName");
                    sb.AppendLine($"CRUD      - TableName");
                    sb.AppendLine($"CRUD      - SortOrder");
                
            
        }
        
        public void PrintGetColumnValuesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ColumnValue     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ColumnValueId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - TableColumn");
                    sb.AppendLine($"CRUD      - Color");
                    sb.AppendLine($"CRUD      - DataValue");
                    sb.AppendLine($"CRUD      - TableColumnName");
                    sb.AppendLine($"CRUD      - TableName");
                    sb.AppendLine($"CRUD      - SortOrder");
                
            
        }
        
        public void PrintUpdateColumnValueHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ColumnValue     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ColumnValueId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - TableColumn");
                    sb.AppendLine($"CRUD      - Color");
                    sb.AppendLine($"CRUD      - DataValue");
                    sb.AppendLine($"CRUD      - TableColumnName");
                    sb.AppendLine($"CRUD      - TableName");
                    sb.AppendLine($"CRUD      - SortOrder");
                
            
        }
        
        public void PrintDeleteColumnValueHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddPortfolioItemRETIREDHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: PortfolioItem_RETIRED     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - PortfolioItem_RETIREDId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ItemStatus");
                    sb.AppendLine($"CRUD      - ItemType");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Portfolio");
                    sb.AppendLine($"CRUD      - PortfolioItemId");
                    sb.AppendLine($"CRUD      - PublishUrl");
                    sb.AppendLine($"CRUD      - Who");
                
            
        }
        
        public void PrintGetPortfolioItemsRETIREDHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: PortfolioItem_RETIRED     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - PortfolioItem_RETIREDId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ItemStatus");
                    sb.AppendLine($"CRUD      - ItemType");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Portfolio");
                    sb.AppendLine($"CRUD      - PortfolioItemId");
                    sb.AppendLine($"CRUD      - PublishUrl");
                    sb.AppendLine($"CRUD      - Who");
                
            
        }
        
        public void PrintUpdatePortfolioItemRETIREDHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: PortfolioItem_RETIRED     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - PortfolioItem_RETIREDId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ItemStatus");
                    sb.AppendLine($"CRUD      - ItemType");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Portfolio");
                    sb.AppendLine($"CRUD      - PortfolioItemId");
                    sb.AppendLine($"CRUD      - PublishUrl");
                    sb.AppendLine($"CRUD      - Who");
                
            
        }
        
        public void PrintDeletePortfolioItemRETIREDHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProjectStageHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectStage     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectStageId");
                    sb.AppendLine($"CRUD      - EffortlessApiProjects2");
                    sb.AppendLine($"CRUD      - VSPAlias");
                    sb.AppendLine($"CRUD      - IsEC2");
                    sb.AppendLine($"CRUD      - ActiveVersion");
                    sb.AppendLine($"CRUD      - Alias");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - AwsId");
                    sb.AppendLine($"CRUD      - AwsRegion");
                    sb.AppendLine($"CRUD      - CpuUnits");
                    sb.AppendLine($"CRUD      - CustomAlias");
                    sb.AppendLine($"CRUD      - CustomAwsId");
                    sb.AppendLine($"CRUD      - CustomAwsRegion");
                    sb.AppendLine($"CRUD      - CustomCpuUnits");
                    sb.AppendLine($"CRUD      - CustomDesiredCount");
                    sb.AppendLine($"CRUD      - CustomMaxMemory");
                    sb.AppendLine($"CRUD      - CustomProfile");
                    sb.AppendLine($"CRUD      - CustomRabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - CustomSecurityGroup");
                    sb.AppendLine($"CRUD      - CustomSubnet");
                    sb.AppendLine($"CRUD      - CustomTaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - CustomTaskExecutionRole");
                    sb.AppendLine($"CRUD      - DesiredCount");
                    sb.AppendLine($"CRUD      - EffortlessAPIProjects");
                    sb.AppendLine($"CRUD      - EffortlessAPIProjects2");
                    sb.AppendLine($"CRUD      - HeadStageForProjects");
                    sb.AppendLine($"CRUD      - MaxMemory");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - OverrideRabbitMQEndpoint");
                    sb.AppendLine($"CRUD      - OverrideSassyMQEndpoint");
                    sb.AppendLine($"CRUD      - Profile");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectAlias");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectId");
                    sb.AppendLine($"CRUD      - ProjectVersionMismatch");
                    sb.AppendLine($"CRUD      - RabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - SecurityGroup");
                    sb.AppendLine($"CRUD      - SPVAlias");
                    sb.AppendLine($"CRUD      - Stage");
                    sb.AppendLine($"CRUD      - StageAlias");
                    sb.AppendLine($"CRUD      - Subnet");
                    sb.AppendLine($"CRUD      - TaskAwsId");
                    sb.AppendLine($"CRUD      - TaskAwsRegion");
                    sb.AppendLine($"CRUD      - TaskClusterName");
                    sb.AppendLine($"CRUD      - TaskCpuUnits");
                    sb.AppendLine($"CRUD      - TaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - TaskDesiredCount");
                    sb.AppendLine($"CRUD      - TaskExecutionRole");
                    sb.AppendLine($"CRUD      - TaskMaxMemory");
                    sb.AppendLine($"CRUD      - TaskProfile");
                    sb.AppendLine($"CRUD      - TaskRabbitMQAdminUsername");
                    sb.AppendLine($"CRUD      - TaskRabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - TaskSecurityGroup");
                    sb.AppendLine($"CRUD      - TaskSubnet");
                    sb.AppendLine($"CRUD      - TaskTaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - TaskTaskExecutionRole");
                    sb.AppendLine($"CRUD      - TemplateTaskEndpoint");
                    sb.AppendLine($"CRUD      - VersionNumber");
                    sb.AppendLine($"CRUD      - VersionProject");
                    sb.AppendLine($"CRUD      - VPSAlias");
                    sb.AppendLine($"CRUD      - EffortlessApiProjects");
                    sb.AppendLine($"CRUD      - EnableDeveloperDiscount");
                    sb.AppendLine($"CRUD      - SubscriptionId");
                    sb.AppendLine($"CRUD      - MonthlySubscription");
                    sb.AppendLine($"CRUD      - SubscriptionStartDate");
                    sb.AppendLine($"CRUD      - SubscriptionEndDate");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - UpdatedOn");
                    sb.AppendLine($"CRUD      - BasePrice");
                    sb.AppendLine($"CRUD      - SuggestedMonthlySubscription");
                    sb.AppendLine($"CRUD      - StageNumber");
                    sb.AppendLine($"CRUD      - IsDeleted");
                    sb.AppendLine($"CRUD      - ActiveMonthlySubscription");
                    sb.AppendLine($"CRUD      - AccountDiscount");
                    sb.AppendLine($"CRUD      - SuggestedMonthlySubscriptionWithAccountDiscount");
                    sb.AppendLine($"CRUD      - RecId");
                
            
        }
        
        public void PrintGetProjectStagesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectStage     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectStageId");
                    sb.AppendLine($"CRUD      - EffortlessApiProjects2");
                    sb.AppendLine($"CRUD      - VSPAlias");
                    sb.AppendLine($"CRUD      - IsEC2");
                    sb.AppendLine($"CRUD      - ActiveVersion");
                    sb.AppendLine($"CRUD      - Alias");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - AwsId");
                    sb.AppendLine($"CRUD      - AwsRegion");
                    sb.AppendLine($"CRUD      - CpuUnits");
                    sb.AppendLine($"CRUD      - CustomAlias");
                    sb.AppendLine($"CRUD      - CustomAwsId");
                    sb.AppendLine($"CRUD      - CustomAwsRegion");
                    sb.AppendLine($"CRUD      - CustomCpuUnits");
                    sb.AppendLine($"CRUD      - CustomDesiredCount");
                    sb.AppendLine($"CRUD      - CustomMaxMemory");
                    sb.AppendLine($"CRUD      - CustomProfile");
                    sb.AppendLine($"CRUD      - CustomRabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - CustomSecurityGroup");
                    sb.AppendLine($"CRUD      - CustomSubnet");
                    sb.AppendLine($"CRUD      - CustomTaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - CustomTaskExecutionRole");
                    sb.AppendLine($"CRUD      - DesiredCount");
                    sb.AppendLine($"CRUD      - EffortlessAPIProjects");
                    sb.AppendLine($"CRUD      - EffortlessAPIProjects2");
                    sb.AppendLine($"CRUD      - HeadStageForProjects");
                    sb.AppendLine($"CRUD      - MaxMemory");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - OverrideRabbitMQEndpoint");
                    sb.AppendLine($"CRUD      - OverrideSassyMQEndpoint");
                    sb.AppendLine($"CRUD      - Profile");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectAlias");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectId");
                    sb.AppendLine($"CRUD      - ProjectVersionMismatch");
                    sb.AppendLine($"CRUD      - RabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - SecurityGroup");
                    sb.AppendLine($"CRUD      - SPVAlias");
                    sb.AppendLine($"CRUD      - Stage");
                    sb.AppendLine($"CRUD      - StageAlias");
                    sb.AppendLine($"CRUD      - Subnet");
                    sb.AppendLine($"CRUD      - TaskAwsId");
                    sb.AppendLine($"CRUD      - TaskAwsRegion");
                    sb.AppendLine($"CRUD      - TaskClusterName");
                    sb.AppendLine($"CRUD      - TaskCpuUnits");
                    sb.AppendLine($"CRUD      - TaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - TaskDesiredCount");
                    sb.AppendLine($"CRUD      - TaskExecutionRole");
                    sb.AppendLine($"CRUD      - TaskMaxMemory");
                    sb.AppendLine($"CRUD      - TaskProfile");
                    sb.AppendLine($"CRUD      - TaskRabbitMQAdminUsername");
                    sb.AppendLine($"CRUD      - TaskRabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - TaskSecurityGroup");
                    sb.AppendLine($"CRUD      - TaskSubnet");
                    sb.AppendLine($"CRUD      - TaskTaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - TaskTaskExecutionRole");
                    sb.AppendLine($"CRUD      - TemplateTaskEndpoint");
                    sb.AppendLine($"CRUD      - VersionNumber");
                    sb.AppendLine($"CRUD      - VersionProject");
                    sb.AppendLine($"CRUD      - VPSAlias");
                    sb.AppendLine($"CRUD      - EffortlessApiProjects");
                    sb.AppendLine($"CRUD      - EnableDeveloperDiscount");
                    sb.AppendLine($"CRUD      - SubscriptionId");
                    sb.AppendLine($"CRUD      - MonthlySubscription");
                    sb.AppendLine($"CRUD      - SubscriptionStartDate");
                    sb.AppendLine($"CRUD      - SubscriptionEndDate");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - UpdatedOn");
                    sb.AppendLine($"CRUD      - BasePrice");
                    sb.AppendLine($"CRUD      - SuggestedMonthlySubscription");
                    sb.AppendLine($"CRUD      - StageNumber");
                    sb.AppendLine($"CRUD      - IsDeleted");
                    sb.AppendLine($"CRUD      - ActiveMonthlySubscription");
                    sb.AppendLine($"CRUD      - AccountDiscount");
                    sb.AppendLine($"CRUD      - SuggestedMonthlySubscriptionWithAccountDiscount");
                    sb.AppendLine($"CRUD      - RecId");
                
            
        }
        
        public void PrintUpdateProjectStageHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectStage     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectStageId");
                    sb.AppendLine($"CRUD      - EffortlessApiProjects2");
                    sb.AppendLine($"CRUD      - VSPAlias");
                    sb.AppendLine($"CRUD      - IsEC2");
                    sb.AppendLine($"CRUD      - ActiveVersion");
                    sb.AppendLine($"CRUD      - Alias");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - AwsId");
                    sb.AppendLine($"CRUD      - AwsRegion");
                    sb.AppendLine($"CRUD      - CpuUnits");
                    sb.AppendLine($"CRUD      - CustomAlias");
                    sb.AppendLine($"CRUD      - CustomAwsId");
                    sb.AppendLine($"CRUD      - CustomAwsRegion");
                    sb.AppendLine($"CRUD      - CustomCpuUnits");
                    sb.AppendLine($"CRUD      - CustomDesiredCount");
                    sb.AppendLine($"CRUD      - CustomMaxMemory");
                    sb.AppendLine($"CRUD      - CustomProfile");
                    sb.AppendLine($"CRUD      - CustomRabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - CustomSecurityGroup");
                    sb.AppendLine($"CRUD      - CustomSubnet");
                    sb.AppendLine($"CRUD      - CustomTaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - CustomTaskExecutionRole");
                    sb.AppendLine($"CRUD      - DesiredCount");
                    sb.AppendLine($"CRUD      - EffortlessAPIProjects");
                    sb.AppendLine($"CRUD      - EffortlessAPIProjects2");
                    sb.AppendLine($"CRUD      - HeadStageForProjects");
                    sb.AppendLine($"CRUD      - MaxMemory");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - OverrideRabbitMQEndpoint");
                    sb.AppendLine($"CRUD      - OverrideSassyMQEndpoint");
                    sb.AppendLine($"CRUD      - Profile");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectAlias");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectId");
                    sb.AppendLine($"CRUD      - ProjectVersionMismatch");
                    sb.AppendLine($"CRUD      - RabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - SecurityGroup");
                    sb.AppendLine($"CRUD      - SPVAlias");
                    sb.AppendLine($"CRUD      - Stage");
                    sb.AppendLine($"CRUD      - StageAlias");
                    sb.AppendLine($"CRUD      - Subnet");
                    sb.AppendLine($"CRUD      - TaskAwsId");
                    sb.AppendLine($"CRUD      - TaskAwsRegion");
                    sb.AppendLine($"CRUD      - TaskClusterName");
                    sb.AppendLine($"CRUD      - TaskCpuUnits");
                    sb.AppendLine($"CRUD      - TaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - TaskDesiredCount");
                    sb.AppendLine($"CRUD      - TaskExecutionRole");
                    sb.AppendLine($"CRUD      - TaskMaxMemory");
                    sb.AppendLine($"CRUD      - TaskProfile");
                    sb.AppendLine($"CRUD      - TaskRabbitMQAdminUsername");
                    sb.AppendLine($"CRUD      - TaskRabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - TaskSecurityGroup");
                    sb.AppendLine($"CRUD      - TaskSubnet");
                    sb.AppendLine($"CRUD      - TaskTaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - TaskTaskExecutionRole");
                    sb.AppendLine($"CRUD      - TemplateTaskEndpoint");
                    sb.AppendLine($"CRUD      - VersionNumber");
                    sb.AppendLine($"CRUD      - VersionProject");
                    sb.AppendLine($"CRUD      - VPSAlias");
                    sb.AppendLine($"CRUD      - EffortlessApiProjects");
                    sb.AppendLine($"CRUD      - EnableDeveloperDiscount");
                    sb.AppendLine($"CRUD      - SubscriptionId");
                    sb.AppendLine($"CRUD      - MonthlySubscription");
                    sb.AppendLine($"CRUD      - SubscriptionStartDate");
                    sb.AppendLine($"CRUD      - SubscriptionEndDate");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - UpdatedOn");
                    sb.AppendLine($"CRUD      - BasePrice");
                    sb.AppendLine($"CRUD      - SuggestedMonthlySubscription");
                    sb.AppendLine($"CRUD      - StageNumber");
                    sb.AppendLine($"CRUD      - IsDeleted");
                    sb.AppendLine($"CRUD      - ActiveMonthlySubscription");
                    sb.AppendLine($"CRUD      - AccountDiscount");
                    sb.AppendLine($"CRUD      - SuggestedMonthlySubscriptionWithAccountDiscount");
                    sb.AppendLine($"CRUD      - RecId");
                
            
        }
        
        public void PrintDeleteProjectStageHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProjectVersionBuildHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectVersionBuild     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectVersionBuildId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - BuildCompleted");
                    sb.AppendLine($"CRUD      - BuildOutput");
                    sb.AppendLine($"CRUD      - BuildStarted");
                    sb.AppendLine($"CRUD      - BuildSucceeded");
                    sb.AppendLine($"CRUD      - ErrorOutput");
                    sb.AppendLine($"CRUD      - FinalTaskName");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                
            
        }
        
        public void PrintGetProjectVersionBuildsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectVersionBuild     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectVersionBuildId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - BuildCompleted");
                    sb.AppendLine($"CRUD      - BuildOutput");
                    sb.AppendLine($"CRUD      - BuildStarted");
                    sb.AppendLine($"CRUD      - BuildSucceeded");
                    sb.AppendLine($"CRUD      - ErrorOutput");
                    sb.AppendLine($"CRUD      - FinalTaskName");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                
            
        }
        
        public void PrintUpdateProjectVersionBuildHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectVersionBuild     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectVersionBuildId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - BuildCompleted");
                    sb.AppendLine($"CRUD      - BuildOutput");
                    sb.AppendLine($"CRUD      - BuildStarted");
                    sb.AppendLine($"CRUD      - BuildSucceeded");
                    sb.AppendLine($"CRUD      - ErrorOutput");
                    sb.AppendLine($"CRUD      - FinalTaskName");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                
            
        }
        
        public void PrintDeleteProjectVersionBuildHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProjectRoleHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectRole     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectRoleId");
                    sb.AppendLine($"CRUD      - AdminRoleForProject");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CanCreateByDefault");
                    sb.AppendLine($"CRUD      - CanDeleteByDefault");
                    sb.AppendLine($"CRUD      - CanReadByDefault");
                    sb.AppendLine($"CRUD      - CanUpdateByDefault");
                    sb.AppendLine($"CRUD      - ColumnRoleCRUD");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - DefaultAirtableWhere");
                    sb.AppendLine($"CRUD      - DefaultCRUD");
                    sb.AppendLine($"CRUD      - DefaultHasAccess");
                    sb.AppendLine($"CRUD      - DefaultWhere");
                    sb.AppendLine($"CRUD      - GuestRoleForProject");
                    sb.AppendLine($"CRUD      - Lexicon");
                    sb.AppendLine($"CRUD      - Lexicon2");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectLexiconTerms");
                    sb.AppendLine($"CRUD      - ProjectLexiconTerms2");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - TableRoleWhere");
                    sb.AppendLine($"CRUD      - UserRoleForProject");
                
            
        }
        
        public void PrintGetProjectRolesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectRole     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectRoleId");
                    sb.AppendLine($"CRUD      - AdminRoleForProject");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CanCreateByDefault");
                    sb.AppendLine($"CRUD      - CanDeleteByDefault");
                    sb.AppendLine($"CRUD      - CanReadByDefault");
                    sb.AppendLine($"CRUD      - CanUpdateByDefault");
                    sb.AppendLine($"CRUD      - ColumnRoleCRUD");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - DefaultAirtableWhere");
                    sb.AppendLine($"CRUD      - DefaultCRUD");
                    sb.AppendLine($"CRUD      - DefaultHasAccess");
                    sb.AppendLine($"CRUD      - DefaultWhere");
                    sb.AppendLine($"CRUD      - GuestRoleForProject");
                    sb.AppendLine($"CRUD      - Lexicon");
                    sb.AppendLine($"CRUD      - Lexicon2");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectLexiconTerms");
                    sb.AppendLine($"CRUD      - ProjectLexiconTerms2");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - TableRoleWhere");
                    sb.AppendLine($"CRUD      - UserRoleForProject");
                
            
        }
        
        public void PrintUpdateProjectRoleHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectRole     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectRoleId");
                    sb.AppendLine($"CRUD      - AdminRoleForProject");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CanCreateByDefault");
                    sb.AppendLine($"CRUD      - CanDeleteByDefault");
                    sb.AppendLine($"CRUD      - CanReadByDefault");
                    sb.AppendLine($"CRUD      - CanUpdateByDefault");
                    sb.AppendLine($"CRUD      - ColumnRoleCRUD");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - DefaultAirtableWhere");
                    sb.AppendLine($"CRUD      - DefaultCRUD");
                    sb.AppendLine($"CRUD      - DefaultHasAccess");
                    sb.AppendLine($"CRUD      - DefaultWhere");
                    sb.AppendLine($"CRUD      - GuestRoleForProject");
                    sb.AppendLine($"CRUD      - Lexicon");
                    sb.AppendLine($"CRUD      - Lexicon2");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectLexiconTerms");
                    sb.AppendLine($"CRUD      - ProjectLexiconTerms2");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - TableRoleWhere");
                    sb.AppendLine($"CRUD      - UserRoleForProject");
                
            
        }
        
        public void PrintDeleteProjectRoleHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddServiceHostEndpointHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostEndpoint     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceHostEndpointId");
                    sb.AppendLine($"CRUD      - Alias");
                    sb.AppendLine($"CRUD      - AmqpsConnectionString");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - AwsId");
                    sb.AppendLine($"CRUD      - AwsRegion");
                    sb.AppendLine($"CRUD      - BaseUrl");
                    sb.AppendLine($"CRUD      - ClusterAwsId");
                    sb.AppendLine($"CRUD      - ClusterAwsRegion");
                    sb.AppendLine($"CRUD      - ClusterName");
                    sb.AppendLine($"CRUD      - DefaultPassword");
                    sb.AppendLine($"CRUD      - DefaultUsername");
                    sb.AppendLine($"CRUD      - DesiredCount");
                    sb.AppendLine($"CRUD      - EndpointSize");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - IsEC2");
                    sb.AppendLine($"CRUD      - IsFargate");
                    sb.AppendLine($"CRUD      - IsSecure");
                    sb.AppendLine($"CRUD      - MaxCPU");
                    sb.AppendLine($"CRUD      - MaxMemory");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Profile");
                    sb.AppendLine($"CRUD      - ProjectStages");
                    sb.AppendLine($"CRUD      - ProjectTasks");
                    sb.AppendLine($"CRUD      - RabbitMQDefaultUsername");
                    sb.AppendLine($"CRUD      - RabbitMQEndpoint");
                    sb.AppendLine($"CRUD      - RabbitMQHost");
                    sb.AppendLine($"CRUD      - RabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - SecurityGroup");
                    sb.AppendLine($"CRUD      - ServiceHostType");
                    sb.AppendLine($"CRUD      - ServiceName");
                    sb.AppendLine($"CRUD      - Subnet");
                    sb.AppendLine($"CRUD      - TaskClusterEndpoint");
                    sb.AppendLine($"CRUD      - TaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - TaskExecutionRole");
                    sb.AppendLine($"CRUD      - TaskRabbitMQAdminUsername");
                    sb.AppendLine($"CRUD      - TaskRabbitMQEndpoint");
                    sb.AppendLine($"CRUD      - TaskSassyMQEndpoint");
                    sb.AppendLine($"CRUD      - RECORD_ID");
                    sb.AppendLine($"CRUD      - IsEAPIEndpoint");
                
            
        }
        
        public void PrintGetServiceHostEndpointsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostEndpoint     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceHostEndpointId");
                    sb.AppendLine($"CRUD      - Alias");
                    sb.AppendLine($"CRUD      - AmqpsConnectionString");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - AwsId");
                    sb.AppendLine($"CRUD      - AwsRegion");
                    sb.AppendLine($"CRUD      - BaseUrl");
                    sb.AppendLine($"CRUD      - ClusterAwsId");
                    sb.AppendLine($"CRUD      - ClusterAwsRegion");
                    sb.AppendLine($"CRUD      - ClusterName");
                    sb.AppendLine($"CRUD      - DefaultPassword");
                    sb.AppendLine($"CRUD      - DefaultUsername");
                    sb.AppendLine($"CRUD      - DesiredCount");
                    sb.AppendLine($"CRUD      - EndpointSize");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - IsEC2");
                    sb.AppendLine($"CRUD      - IsFargate");
                    sb.AppendLine($"CRUD      - IsSecure");
                    sb.AppendLine($"CRUD      - MaxCPU");
                    sb.AppendLine($"CRUD      - MaxMemory");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Profile");
                    sb.AppendLine($"CRUD      - ProjectStages");
                    sb.AppendLine($"CRUD      - ProjectTasks");
                    sb.AppendLine($"CRUD      - RabbitMQDefaultUsername");
                    sb.AppendLine($"CRUD      - RabbitMQEndpoint");
                    sb.AppendLine($"CRUD      - RabbitMQHost");
                    sb.AppendLine($"CRUD      - RabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - SecurityGroup");
                    sb.AppendLine($"CRUD      - ServiceHostType");
                    sb.AppendLine($"CRUD      - ServiceName");
                    sb.AppendLine($"CRUD      - Subnet");
                    sb.AppendLine($"CRUD      - TaskClusterEndpoint");
                    sb.AppendLine($"CRUD      - TaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - TaskExecutionRole");
                    sb.AppendLine($"CRUD      - TaskRabbitMQAdminUsername");
                    sb.AppendLine($"CRUD      - TaskRabbitMQEndpoint");
                    sb.AppendLine($"CRUD      - TaskSassyMQEndpoint");
                    sb.AppendLine($"CRUD      - RECORD_ID");
                    sb.AppendLine($"CRUD      - IsEAPIEndpoint");
                
            
        }
        
        public void PrintUpdateServiceHostEndpointHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostEndpoint     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceHostEndpointId");
                    sb.AppendLine($"CRUD      - Alias");
                    sb.AppendLine($"CRUD      - AmqpsConnectionString");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - AwsId");
                    sb.AppendLine($"CRUD      - AwsRegion");
                    sb.AppendLine($"CRUD      - BaseUrl");
                    sb.AppendLine($"CRUD      - ClusterAwsId");
                    sb.AppendLine($"CRUD      - ClusterAwsRegion");
                    sb.AppendLine($"CRUD      - ClusterName");
                    sb.AppendLine($"CRUD      - DefaultPassword");
                    sb.AppendLine($"CRUD      - DefaultUsername");
                    sb.AppendLine($"CRUD      - DesiredCount");
                    sb.AppendLine($"CRUD      - EndpointSize");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - IsEC2");
                    sb.AppendLine($"CRUD      - IsFargate");
                    sb.AppendLine($"CRUD      - IsSecure");
                    sb.AppendLine($"CRUD      - MaxCPU");
                    sb.AppendLine($"CRUD      - MaxMemory");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Profile");
                    sb.AppendLine($"CRUD      - ProjectStages");
                    sb.AppendLine($"CRUD      - ProjectTasks");
                    sb.AppendLine($"CRUD      - RabbitMQDefaultUsername");
                    sb.AppendLine($"CRUD      - RabbitMQEndpoint");
                    sb.AppendLine($"CRUD      - RabbitMQHost");
                    sb.AppendLine($"CRUD      - RabbitMQHostUrl");
                    sb.AppendLine($"CRUD      - SecurityGroup");
                    sb.AppendLine($"CRUD      - ServiceHostType");
                    sb.AppendLine($"CRUD      - ServiceName");
                    sb.AppendLine($"CRUD      - Subnet");
                    sb.AppendLine($"CRUD      - TaskClusterEndpoint");
                    sb.AppendLine($"CRUD      - TaskDefinitionJsonLocation");
                    sb.AppendLine($"CRUD      - TaskExecutionRole");
                    sb.AppendLine($"CRUD      - TaskRabbitMQAdminUsername");
                    sb.AppendLine($"CRUD      - TaskRabbitMQEndpoint");
                    sb.AppendLine($"CRUD      - TaskSassyMQEndpoint");
                    sb.AppendLine($"CRUD      - RECORD_ID");
                    sb.AppendLine($"CRUD      - IsEAPIEndpoint");
                
            
        }
        
        public void PrintDeleteServiceHostEndpointHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddEffortlessAPIServiceHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EffortlessAPIService     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EffortlessAPIServiceId");
                    sb.AppendLine($"CRUD      - EffortlessApiProjects");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - EffortlessAPIProjects");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ProjectConnections");
                    sb.AppendLine($"CRUD      - ServiceKeys");
                    sb.AppendLine($"CRUD      - ServicePlan");
                    sb.AppendLine($"CRUD      - ServiceStatus");
                    sb.AppendLine($"CRUD      - ServiceType");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - AirtableRecordID");
                
            
        }
        
        public void PrintGetEffortlessAPIServicesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EffortlessAPIService     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EffortlessAPIServiceId");
                    sb.AppendLine($"CRUD      - EffortlessApiProjects");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - EffortlessAPIProjects");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ProjectConnections");
                    sb.AppendLine($"CRUD      - ServiceKeys");
                    sb.AppendLine($"CRUD      - ServicePlan");
                    sb.AppendLine($"CRUD      - ServiceStatus");
                    sb.AppendLine($"CRUD      - ServiceType");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - AirtableRecordID");
                
            
        }
        
        public void PrintUpdateEffortlessAPIServiceHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EffortlessAPIService     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EffortlessAPIServiceId");
                    sb.AppendLine($"CRUD      - EffortlessApiProjects");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - EffortlessAPIProjects");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ProjectConnections");
                    sb.AppendLine($"CRUD      - ServiceKeys");
                    sb.AppendLine($"CRUD      - ServicePlan");
                    sb.AppendLine($"CRUD      - ServiceStatus");
                    sb.AppendLine($"CRUD      - ServiceType");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - AirtableRecordID");
                
            
        }
        
        public void PrintDeleteEffortlessAPIServiceHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProjectConnectionHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectConnection     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectConnectionId");
                    sb.AppendLine($"CRUD      - AirtableConnection");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ConnectionForService");
                    sb.AppendLine($"CRUD      - ConnectionString");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectVersions");
                
            
        }
        
        public void PrintGetProjectConnectionsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectConnection     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectConnectionId");
                    sb.AppendLine($"CRUD      - AirtableConnection");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ConnectionForService");
                    sb.AppendLine($"CRUD      - ConnectionString");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectVersions");
                
            
        }
        
        public void PrintUpdateProjectConnectionHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectConnection     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectConnectionId");
                    sb.AppendLine($"CRUD      - AirtableConnection");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ConnectionForService");
                    sb.AppendLine($"CRUD      - ConnectionString");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectVersions");
                
            
        }
        
        public void PrintDeleteProjectConnectionHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProjectLexiconTermHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectLexiconTerm     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectLexiconTermId");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - From");
                    sb.AppendLine($"CRUD      - FromRole");
                    sb.AppendLine($"CRUD      - IsDirectMessages");
                    sb.AppendLine($"CRUD      - IsDirectMessage");
                    sb.AppendLine($"CRUD      - Message");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - To");
                    sb.AppendLine($"CRUD      - ToRole");
                    sb.AppendLine($"CRUD      - HttpPOSTUrl");
                
            
        }
        
        public void PrintGetProjectLexiconTermsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectLexiconTerm     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectLexiconTermId");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - From");
                    sb.AppendLine($"CRUD      - FromRole");
                    sb.AppendLine($"CRUD      - IsDirectMessages");
                    sb.AppendLine($"CRUD      - IsDirectMessage");
                    sb.AppendLine($"CRUD      - Message");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - To");
                    sb.AppendLine($"CRUD      - ToRole");
                    sb.AppendLine($"CRUD      - HttpPOSTUrl");
                
            
        }
        
        public void PrintUpdateProjectLexiconTermHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectLexiconTerm     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectLexiconTermId");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - From");
                    sb.AppendLine($"CRUD      - FromRole");
                    sb.AppendLine($"CRUD      - IsDirectMessages");
                    sb.AppendLine($"CRUD      - IsDirectMessage");
                    sb.AppendLine($"CRUD      - Message");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - To");
                    sb.AppendLine($"CRUD      - ToRole");
                    sb.AppendLine($"CRUD      - HttpPOSTUrl");
                
            
        }
        
        public void PrintDeleteProjectLexiconTermHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddPortfolioRETIREDHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: Portfolio_RETIRED     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - Portfolio_RETIREDId");
                    sb.AppendLine($"CRUD      - AiirtableUrl");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - BackEndWho");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PortfolioId");
                    sb.AppendLine($"CRUD      - PortfolioItem");
                
            
        }
        
        public void PrintGetPortfoliosRETIREDHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: Portfolio_RETIRED     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - Portfolio_RETIREDId");
                    sb.AppendLine($"CRUD      - AiirtableUrl");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - BackEndWho");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PortfolioId");
                    sb.AppendLine($"CRUD      - PortfolioItem");
                
            
        }
        
        public void PrintUpdatePortfolioRETIREDHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: Portfolio_RETIRED     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - Portfolio_RETIREDId");
                    sb.AppendLine($"CRUD      - AiirtableUrl");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - BackEndWho");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PortfolioId");
                    sb.AppendLine($"CRUD      - PortfolioItem");
                
            
        }
        
        public void PrintDeletePortfolioRETIREDHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProjectEmailHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectEmail     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectEmailId");
                    sb.AppendLine($"CRUD      - Account");
                    sb.AppendLine($"CRUD      - AccountEmail");
                    sb.AppendLine($"CRUD      - AccountEmailLookup");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectOwnerEmail");
                
            
        }
        
        public void PrintGetProjectEmailsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectEmail     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectEmailId");
                    sb.AppendLine($"CRUD      - Account");
                    sb.AppendLine($"CRUD      - AccountEmail");
                    sb.AppendLine($"CRUD      - AccountEmailLookup");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectOwnerEmail");
                
            
        }
        
        public void PrintUpdateProjectEmailHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectEmail     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectEmailId");
                    sb.AppendLine($"CRUD      - Account");
                    sb.AppendLine($"CRUD      - AccountEmail");
                    sb.AppendLine($"CRUD      - AccountEmailLookup");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectOwnerEmail");
                
            
        }
        
        public void PrintDeleteProjectEmailHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProjectVersionHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectVersion     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectVersionId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ConnectionString");
                    sb.AppendLine($"CRUD      - CreatedAt");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - OverrideVersion");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectNumber");
                    sb.AppendLine($"CRUD      - ProjectRoles");
                    sb.AppendLine($"CRUD      - ProjectStages");
                    sb.AppendLine($"CRUD      - ProjectTables");
                    sb.AppendLine($"CRUD      - ProjectVersionBuilds");
                    sb.AppendLine($"CRUD      - RoleCount");
                    sb.AppendLine($"CRUD      - StageNames");
                    sb.AppendLine($"CRUD      - TableCount");
                    sb.AppendLine($"CRUD      - VersionConnection");
                    sb.AppendLine($"CRUD      - VersionNumber");
                    sb.AppendLine($"CRUD      - ProjectService");
                    sb.AppendLine($"CRUD      - ProjectServiceLogo");
                    sb.AppendLine($"CRUD      - ProjectServiceName");
                
            
        }
        
        public void PrintGetProjectVersionsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectVersion     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectVersionId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ConnectionString");
                    sb.AppendLine($"CRUD      - CreatedAt");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - OverrideVersion");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectNumber");
                    sb.AppendLine($"CRUD      - ProjectRoles");
                    sb.AppendLine($"CRUD      - ProjectStages");
                    sb.AppendLine($"CRUD      - ProjectTables");
                    sb.AppendLine($"CRUD      - ProjectVersionBuilds");
                    sb.AppendLine($"CRUD      - RoleCount");
                    sb.AppendLine($"CRUD      - StageNames");
                    sb.AppendLine($"CRUD      - TableCount");
                    sb.AppendLine($"CRUD      - VersionConnection");
                    sb.AppendLine($"CRUD      - VersionNumber");
                    sb.AppendLine($"CRUD      - ProjectService");
                    sb.AppendLine($"CRUD      - ProjectServiceLogo");
                    sb.AppendLine($"CRUD      - ProjectServiceName");
                
            
        }
        
        public void PrintUpdateProjectVersionHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectVersion     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectVersionId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ConnectionString");
                    sb.AppendLine($"CRUD      - CreatedAt");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - OverrideVersion");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectNumber");
                    sb.AppendLine($"CRUD      - ProjectRoles");
                    sb.AppendLine($"CRUD      - ProjectStages");
                    sb.AppendLine($"CRUD      - ProjectTables");
                    sb.AppendLine($"CRUD      - ProjectVersionBuilds");
                    sb.AppendLine($"CRUD      - RoleCount");
                    sb.AppendLine($"CRUD      - StageNames");
                    sb.AppendLine($"CRUD      - TableCount");
                    sb.AppendLine($"CRUD      - VersionConnection");
                    sb.AppendLine($"CRUD      - VersionNumber");
                    sb.AppendLine($"CRUD      - ProjectService");
                    sb.AppendLine($"CRUD      - ProjectServiceLogo");
                    sb.AppendLine($"CRUD      - ProjectServiceName");
                
            
        }
        
        public void PrintDeleteProjectVersionHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddServiceHostTypeHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostType     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceHostTypeId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ServiceHostEndpoints");
                    sb.AppendLine($"CRUD      - IsEAPIEndpoint");
                
            
        }
        
        public void PrintGetServiceHostTypesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostType     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceHostTypeId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ServiceHostEndpoints");
                    sb.AppendLine($"CRUD      - IsEAPIEndpoint");
                
            
        }
        
        public void PrintUpdateServiceHostTypeHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostType     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceHostTypeId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ServiceHostEndpoints");
                    sb.AppendLine($"CRUD      - IsEAPIEndpoint");
                
            
        }
        
        public void PrintDeleteServiceHostTypeHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddRemoteEndpointHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: RemoteEndpoint     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - RemoteEndpointId");
                    sb.AppendLine($"CRUD      - AMQPConnectionString");
                    sb.AppendLine($"CRUD      - AMQPHostname");
                    sb.AppendLine($"CRUD      - AMQPPassword");
                    sb.AppendLine($"CRUD      - AMQPUsername");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - IsSecure");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - VHost");
                
            
        }
        
        public void PrintGetRemoteEndpointsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: RemoteEndpoint     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - RemoteEndpointId");
                    sb.AppendLine($"CRUD      - AMQPConnectionString");
                    sb.AppendLine($"CRUD      - AMQPHostname");
                    sb.AppendLine($"CRUD      - AMQPPassword");
                    sb.AppendLine($"CRUD      - AMQPUsername");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - IsSecure");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - VHost");
                
            
        }
        
        public void PrintUpdateRemoteEndpointHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: RemoteEndpoint     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - RemoteEndpointId");
                    sb.AppendLine($"CRUD      - AMQPConnectionString");
                    sb.AppendLine($"CRUD      - AMQPHostname");
                    sb.AppendLine($"CRUD      - AMQPPassword");
                    sb.AppendLine($"CRUD      - AMQPUsername");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - IsSecure");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - VHost");
                
            
        }
        
        public void PrintDeleteRemoteEndpointHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddEffortlessAPIAccountHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EffortlessAPIAccount     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EffortlessAPIAccountId");
                    sb.AppendLine($"CRUD      - DemoPassword");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - DebugPassword");
                    sb.AppendLine($"CRUD      - EmailAddress");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - Projects");
                    sb.AppendLine($"CRUD      - Role");
                    sb.AppendLine($"CRUD      - ServiceKeys");
                    sb.AppendLine($"CRUD      - MonthlySubscriptionTotals");
                    sb.AppendLine($"CRUD      - AccountDiscount");
                    sb.AppendLine($"CRUD      - DefaultMaxPages");
                
            
        }
        
        public void PrintGetEffortlessAPIAccountsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EffortlessAPIAccount     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EffortlessAPIAccountId");
                    sb.AppendLine($"CRUD      - DemoPassword");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - DebugPassword");
                    sb.AppendLine($"CRUD      - EmailAddress");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - Projects");
                    sb.AppendLine($"CRUD      - Role");
                    sb.AppendLine($"CRUD      - ServiceKeys");
                    sb.AppendLine($"CRUD      - MonthlySubscriptionTotals");
                    sb.AppendLine($"CRUD      - AccountDiscount");
                    sb.AppendLine($"CRUD      - DefaultMaxPages");
                
            
        }
        
        public void PrintUpdateEffortlessAPIAccountHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EffortlessAPIAccount     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EffortlessAPIAccountId");
                    sb.AppendLine($"CRUD      - DemoPassword");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - DebugPassword");
                    sb.AppendLine($"CRUD      - EmailAddress");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - Projects");
                    sb.AppendLine($"CRUD      - Role");
                    sb.AppendLine($"CRUD      - ServiceKeys");
                    sb.AppendLine($"CRUD      - MonthlySubscriptionTotals");
                    sb.AppendLine($"CRUD      - AccountDiscount");
                    sb.AppendLine($"CRUD      - DefaultMaxPages");
                
            
        }
        
        public void PrintDeleteEffortlessAPIAccountHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddServiceProductHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceProduct     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceProductId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Category");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - EffectiveQuantity");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - MSRP");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PlanProducts");
                    sb.AppendLine($"CRUD      - PricingModel");
                    sb.AppendLine($"CRUD      - RadioGroup");
                    sb.AppendLine($"CRUD      - SortOrder");
                
            
        }
        
        public void PrintGetServiceProductsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceProduct     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceProductId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Category");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - EffectiveQuantity");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - MSRP");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PlanProducts");
                    sb.AppendLine($"CRUD      - PricingModel");
                    sb.AppendLine($"CRUD      - RadioGroup");
                    sb.AppendLine($"CRUD      - SortOrder");
                
            
        }
        
        public void PrintUpdateServiceProductHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceProduct     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceProductId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Category");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - EffectiveQuantity");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - MSRP");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PlanProducts");
                    sb.AppendLine($"CRUD      - PricingModel");
                    sb.AppendLine($"CRUD      - RadioGroup");
                    sb.AppendLine($"CRUD      - SortOrder");
                
            
        }
        
        public void PrintDeleteServiceProductHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProxyRelativeUrlHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProxyRelativeUrl     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProxyRelativeUrlId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Category");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - Url");
                
            
        }
        
        public void PrintGetProxyRelativeUrlsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProxyRelativeUrl     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProxyRelativeUrlId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Category");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - Url");
                
            
        }
        
        public void PrintUpdateProxyRelativeUrlHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProxyRelativeUrl     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProxyRelativeUrlId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Category");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - Url");
                
            
        }
        
        public void PrintDeleteProxyRelativeUrlHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProjectRequestSummaryHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectRequestSummary     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectRequestSummaryId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CreateAt");
                    sb.AppendLine($"CRUD      - EffortlessAPIProject");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - RequestSummaryJson");
                    sb.AppendLine($"CRUD      - TotalRequests");
                
            
        }
        
        public void PrintGetProjectRequestSummariesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectRequestSummary     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectRequestSummaryId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CreateAt");
                    sb.AppendLine($"CRUD      - EffortlessAPIProject");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - RequestSummaryJson");
                    sb.AppendLine($"CRUD      - TotalRequests");
                
            
        }
        
        public void PrintUpdateProjectRequestSummaryHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectRequestSummary     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectRequestSummaryId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CreateAt");
                    sb.AppendLine($"CRUD      - EffortlessAPIProject");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - RequestSummaryJson");
                    sb.AppendLine($"CRUD      - TotalRequests");
                
            
        }
        
        public void PrintDeleteProjectRequestSummaryHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddServicePlanHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServicePlan     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServicePlanId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CallForPricing");
                    sb.AppendLine($"CRUD      - DefaultDiscount");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - EffortlessAPIService");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - IsDeveloperPlan");
                    sb.AppendLine($"CRUD      - MonthlyPrice");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - NumberedDisplayName");
                    sb.AppendLine($"CRUD      - PlanProducts");
                    sb.AppendLine($"CRUD      - RawPrice");
                    sb.AppendLine($"CRUD      - ServicePlanProducts");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - SuggestedPrice");
                    sb.AppendLine($"CRUD      - EffortlessApiService");
                
            
        }
        
        public void PrintGetServicePlansHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServicePlan     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServicePlanId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CallForPricing");
                    sb.AppendLine($"CRUD      - DefaultDiscount");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - EffortlessAPIService");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - IsDeveloperPlan");
                    sb.AppendLine($"CRUD      - MonthlyPrice");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - NumberedDisplayName");
                    sb.AppendLine($"CRUD      - PlanProducts");
                    sb.AppendLine($"CRUD      - RawPrice");
                    sb.AppendLine($"CRUD      - ServicePlanProducts");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - SuggestedPrice");
                    sb.AppendLine($"CRUD      - EffortlessApiService");
                
            
        }
        
        public void PrintUpdateServicePlanHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServicePlan     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServicePlanId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CallForPricing");
                    sb.AppendLine($"CRUD      - DefaultDiscount");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - EffortlessAPIService");
                    sb.AppendLine($"CRUD      - IsActive");
                    sb.AppendLine($"CRUD      - IsDeveloperPlan");
                    sb.AppendLine($"CRUD      - MonthlyPrice");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - NumberedDisplayName");
                    sb.AppendLine($"CRUD      - PlanProducts");
                    sb.AppendLine($"CRUD      - RawPrice");
                    sb.AppendLine($"CRUD      - ServicePlanProducts");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - SuggestedPrice");
                    sb.AppendLine($"CRUD      - EffortlessApiService");
                
            
        }
        
        public void PrintDeleteServicePlanHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddProjectIconHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectIcon     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectIconId");
                    sb.AppendLine($"CRUD      - ASCIICode");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                
            
        }
        
        public void PrintGetProjectIconsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectIcon     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectIconId");
                    sb.AppendLine($"CRUD      - ASCIICode");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                
            
        }
        
        public void PrintUpdateProjectIconHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectIcon     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ProjectIconId");
                    sb.AppendLine($"CRUD      - ASCIICode");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                
            
        }
        
        public void PrintDeleteProjectIconHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddTableColumnHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: TableColumn     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - TableColumnId");
                    sb.AppendLine($"CRUD      - SymmetricTableColumn");
                    sb.AppendLine($"CRUD      - RelationshipType");
                    sb.AppendLine($"CRUD      - OtherSideOfRelationship");
                    sb.AppendLine($"CRUD      - RelationshipName");
                    sb.AppendLine($"CRUD      - ModifiedOn");
                    sb.AppendLine($"CRUD      - IsReadonly");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ColumnAutoNumber");
                    sb.AppendLine($"CRUD      - ColumnCRUDs");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - DataType");
                    sb.AppendLine($"CRUD      - DefaultValue");
                    sb.AppendLine($"CRUD      - DeletedOn");
                    sb.AppendLine($"CRUD      - Description");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - IsCollection");
                    sb.AppendLine($"CRUD      - IsObsolete");
                    sb.AppendLine($"CRUD      - IsRequired");
                    sb.AppendLine($"CRUD      - IsUnique");
                    sb.AppendLine($"CRUD      - Length");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - OverrideDataType");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectEmails1");
                    sb.AppendLine($"CRUD      - ProjectTable");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - TableName");
                    sb.AppendLine($"CRUD      - TableProject");
                    sb.AppendLine($"CRUD      - ToName");
                    sb.AppendLine($"CRUD      - DefaultSortOrder");
                    sb.AppendLine($"CRUD      - FormulaDisplay");
                    sb.AppendLine($"CRUD      - Formula");
                    sb.AppendLine($"CRUD      - IsRequiredORIGINALTEXT");
                    sb.AppendLine($"CRUD      - ReferencedColumns");
                    sb.AppendLine($"CRUD      - ColumnValues");
                    sb.AppendLine($"CRUD      - LookupColumn");
                    sb.AppendLine($"CRUD      - LookupColumnName");
                    sb.AppendLine($"CRUD      - SymmetricTableColumnName");
                    sb.AppendLine($"CRUD      - OverrideLength");
                    sb.AppendLine($"CRUD      - OverrideIsCollection");
                
            
        }
        
        public void PrintGetTableColumnsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: TableColumn     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - TableColumnId");
                    sb.AppendLine($"CRUD      - SymmetricTableColumn");
                    sb.AppendLine($"CRUD      - RelationshipType");
                    sb.AppendLine($"CRUD      - OtherSideOfRelationship");
                    sb.AppendLine($"CRUD      - RelationshipName");
                    sb.AppendLine($"CRUD      - ModifiedOn");
                    sb.AppendLine($"CRUD      - IsReadonly");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ColumnAutoNumber");
                    sb.AppendLine($"CRUD      - ColumnCRUDs");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - DataType");
                    sb.AppendLine($"CRUD      - DefaultValue");
                    sb.AppendLine($"CRUD      - DeletedOn");
                    sb.AppendLine($"CRUD      - Description");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - IsCollection");
                    sb.AppendLine($"CRUD      - IsObsolete");
                    sb.AppendLine($"CRUD      - IsRequired");
                    sb.AppendLine($"CRUD      - IsUnique");
                    sb.AppendLine($"CRUD      - Length");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - OverrideDataType");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectEmails1");
                    sb.AppendLine($"CRUD      - ProjectTable");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - TableName");
                    sb.AppendLine($"CRUD      - TableProject");
                    sb.AppendLine($"CRUD      - ToName");
                    sb.AppendLine($"CRUD      - DefaultSortOrder");
                    sb.AppendLine($"CRUD      - FormulaDisplay");
                    sb.AppendLine($"CRUD      - Formula");
                    sb.AppendLine($"CRUD      - IsRequiredORIGINALTEXT");
                    sb.AppendLine($"CRUD      - ReferencedColumns");
                    sb.AppendLine($"CRUD      - ColumnValues");
                    sb.AppendLine($"CRUD      - LookupColumn");
                    sb.AppendLine($"CRUD      - LookupColumnName");
                    sb.AppendLine($"CRUD      - SymmetricTableColumnName");
                    sb.AppendLine($"CRUD      - OverrideLength");
                    sb.AppendLine($"CRUD      - OverrideIsCollection");
                
            
        }
        
        public void PrintUpdateTableColumnHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: TableColumn     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - TableColumnId");
                    sb.AppendLine($"CRUD      - SymmetricTableColumn");
                    sb.AppendLine($"CRUD      - RelationshipType");
                    sb.AppendLine($"CRUD      - OtherSideOfRelationship");
                    sb.AppendLine($"CRUD      - RelationshipName");
                    sb.AppendLine($"CRUD      - ModifiedOn");
                    sb.AppendLine($"CRUD      - IsReadonly");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - ColumnAutoNumber");
                    sb.AppendLine($"CRUD      - ColumnCRUDs");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - DataType");
                    sb.AppendLine($"CRUD      - DefaultValue");
                    sb.AppendLine($"CRUD      - DeletedOn");
                    sb.AppendLine($"CRUD      - Description");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - IsCollection");
                    sb.AppendLine($"CRUD      - IsObsolete");
                    sb.AppendLine($"CRUD      - IsRequired");
                    sb.AppendLine($"CRUD      - IsUnique");
                    sb.AppendLine($"CRUD      - Length");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - OverrideDataType");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectEmails1");
                    sb.AppendLine($"CRUD      - ProjectTable");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - SortOrder");
                    sb.AppendLine($"CRUD      - TableName");
                    sb.AppendLine($"CRUD      - TableProject");
                    sb.AppendLine($"CRUD      - ToName");
                    sb.AppendLine($"CRUD      - DefaultSortOrder");
                    sb.AppendLine($"CRUD      - FormulaDisplay");
                    sb.AppendLine($"CRUD      - Formula");
                    sb.AppendLine($"CRUD      - IsRequiredORIGINALTEXT");
                    sb.AppendLine($"CRUD      - ReferencedColumns");
                    sb.AppendLine($"CRUD      - ColumnValues");
                    sb.AppendLine($"CRUD      - LookupColumn");
                    sb.AppendLine($"CRUD      - LookupColumnName");
                    sb.AppendLine($"CRUD      - SymmetricTableColumnName");
                    sb.AppendLine($"CRUD      - OverrideLength");
                    sb.AppendLine($"CRUD      - OverrideIsCollection");
                
            
        }
        
        public void PrintDeleteTableColumnHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddTableRoleWhereHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: TableRoleWhere     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - TableRoleWhereId");
                    sb.AppendLine($"CRUD      - CreatedAt");
                    sb.AppendLine($"CRUD      - AirtableWhereClause");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CanCallCreate");
                    sb.AppendLine($"CRUD      - CanCallDelete");
                    sb.AppendLine($"CRUD      - CanCallRead");
                    sb.AppendLine($"CRUD      - CanCallUpdate");
                    sb.AppendLine($"CRUD      - CanCreateByDefault");
                    sb.AppendLine($"CRUD      - CanDeleteByDefault");
                    sb.AppendLine($"CRUD      - CanReadByDefault");
                    sb.AppendLine($"CRUD      - CanUpdateByDefault");
                    sb.AppendLine($"CRUD      - ColumnRoleCRUDs");
                    sb.AppendLine($"CRUD      - ColumnRoleCRUDs2");
                    sb.AppendLine($"CRUD      - DefaultCRUD");
                    sb.AppendLine($"CRUD      - HasAccess");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectRole");
                    sb.AppendLine($"CRUD      - ProjectTable");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RoleDefaultCRUD");
                    sb.AppendLine($"CRUD      - RoleDefaultHasAccess");
                    sb.AppendLine($"CRUD      - WhereClause");
                
            
        }
        
        public void PrintGetTableRoleWheresHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: TableRoleWhere     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - TableRoleWhereId");
                    sb.AppendLine($"CRUD      - CreatedAt");
                    sb.AppendLine($"CRUD      - AirtableWhereClause");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CanCallCreate");
                    sb.AppendLine($"CRUD      - CanCallDelete");
                    sb.AppendLine($"CRUD      - CanCallRead");
                    sb.AppendLine($"CRUD      - CanCallUpdate");
                    sb.AppendLine($"CRUD      - CanCreateByDefault");
                    sb.AppendLine($"CRUD      - CanDeleteByDefault");
                    sb.AppendLine($"CRUD      - CanReadByDefault");
                    sb.AppendLine($"CRUD      - CanUpdateByDefault");
                    sb.AppendLine($"CRUD      - ColumnRoleCRUDs");
                    sb.AppendLine($"CRUD      - ColumnRoleCRUDs2");
                    sb.AppendLine($"CRUD      - DefaultCRUD");
                    sb.AppendLine($"CRUD      - HasAccess");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectRole");
                    sb.AppendLine($"CRUD      - ProjectTable");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RoleDefaultCRUD");
                    sb.AppendLine($"CRUD      - RoleDefaultHasAccess");
                    sb.AppendLine($"CRUD      - WhereClause");
                
            
        }
        
        public void PrintUpdateTableRoleWhereHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: TableRoleWhere     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - TableRoleWhereId");
                    sb.AppendLine($"CRUD      - CreatedAt");
                    sb.AppendLine($"CRUD      - AirtableWhereClause");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CanCallCreate");
                    sb.AppendLine($"CRUD      - CanCallDelete");
                    sb.AppendLine($"CRUD      - CanCallRead");
                    sb.AppendLine($"CRUD      - CanCallUpdate");
                    sb.AppendLine($"CRUD      - CanCreateByDefault");
                    sb.AppendLine($"CRUD      - CanDeleteByDefault");
                    sb.AppendLine($"CRUD      - CanReadByDefault");
                    sb.AppendLine($"CRUD      - CanUpdateByDefault");
                    sb.AppendLine($"CRUD      - ColumnRoleCRUDs");
                    sb.AppendLine($"CRUD      - ColumnRoleCRUDs2");
                    sb.AppendLine($"CRUD      - DefaultCRUD");
                    sb.AppendLine($"CRUD      - HasAccess");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectRole");
                    sb.AppendLine($"CRUD      - ProjectTable");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RoleDefaultCRUD");
                    sb.AppendLine($"CRUD      - RoleDefaultHasAccess");
                    sb.AppendLine($"CRUD      - WhereClause");
                
            
        }
        
        public void PrintDeleteTableRoleWhereHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddEffortlessAPIProjectHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EffortlessAPIProject     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EffortlessAPIProjectId");
                    sb.AppendLine($"CRUD      - ModifiedOn");
                    sb.AppendLine($"CRUD      - Account");
                    sb.AppendLine($"CRUD      - AccountName");
                    sb.AppendLine($"CRUD      - AdminRole");
                    sb.AppendLine($"CRUD      - AirtableId");
                    sb.AppendLine($"CRUD      - Alias");
                    sb.AppendLine($"CRUD      - AllowAirtableWhere");
                    sb.AppendLine($"CRUD      - AutoAssignedID");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - ConnectionString");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - DefaultDesiredAlias");
                    sb.AppendLine($"CRUD      - DesiredAlias");
                    sb.AppendLine($"CRUD      - EffortlessApiService");
                    sb.AppendLine($"CRUD      - EmailColumnName");
                    sb.AppendLine($"CRUD      - EntitiesTable");
                    sb.AppendLine($"CRUD      - GuestRole");
                    sb.AppendLine($"CRUD      - HeadStage");
                    sb.AppendLine($"CRUD      - HeadVersion");
                    sb.AppendLine($"CRUD      - IsLexiconSecret");
                    sb.AppendLine($"CRUD      - IsSchemaSecret");
                    sb.AppendLine($"CRUD      - LowerAirtableId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - OwnerEmail");
                    sb.AppendLine($"CRUD      - ProductionStage");
                    sb.AppendLine($"CRUD      - ProjectBuilds");
                    sb.AppendLine($"CRUD      - ProjectConnections");
                    sb.AppendLine($"CRUD      - ProjectEmailList");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectLexiconTerms");
                    sb.AppendLine($"CRUD      - ProjectRequestSummary");
                    sb.AppendLine($"CRUD      - ProjectStage");
                    sb.AppendLine($"CRUD      - ProjectStages");
                    sb.AppendLine($"CRUD      - ProjectType");
                    sb.AppendLine($"CRUD      - ProjectVersions");
                    sb.AppendLine($"CRUD      - RemoteEndpoints");
                    sb.AppendLine($"CRUD      - RoleColumnName");
                    sb.AppendLine($"CRUD      - RolesTable");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - ServiceLogo");
                    sb.AppendLine($"CRUD      - UseDebugDataStorage");
                    sb.AppendLine($"CRUD      - UserRole");
                    sb.AppendLine($"CRUD      - UserTable");
                    sb.AppendLine($"CRUD      - EffortlessAPIServiceName");
                    sb.AppendLine($"CRUD      - LastPublished");
                    sb.AppendLine($"CRUD      - RECORD_ID");
                    sb.AppendLine($"CRUD      - HeadStageIsEC2");
                    sb.AppendLine($"CRUD      - SubscriptionTotals");
                    sb.AppendLine($"CRUD      - AccountDiscount");
                    sb.AppendLine($"CRUD      - CustomMaxPages");
                    sb.AppendLine($"CRUD      - AccountDefaultMaxPages");
                    sb.AppendLine($"CRUD      - MaxPages");
                
            
        }
        
        public void PrintGetEffortlessAPIProjectsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EffortlessAPIProject     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EffortlessAPIProjectId");
                    sb.AppendLine($"CRUD      - ModifiedOn");
                    sb.AppendLine($"CRUD      - Account");
                    sb.AppendLine($"CRUD      - AccountName");
                    sb.AppendLine($"CRUD      - AdminRole");
                    sb.AppendLine($"CRUD      - AirtableId");
                    sb.AppendLine($"CRUD      - Alias");
                    sb.AppendLine($"CRUD      - AllowAirtableWhere");
                    sb.AppendLine($"CRUD      - AutoAssignedID");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - ConnectionString");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - DefaultDesiredAlias");
                    sb.AppendLine($"CRUD      - DesiredAlias");
                    sb.AppendLine($"CRUD      - EffortlessApiService");
                    sb.AppendLine($"CRUD      - EmailColumnName");
                    sb.AppendLine($"CRUD      - EntitiesTable");
                    sb.AppendLine($"CRUD      - GuestRole");
                    sb.AppendLine($"CRUD      - HeadStage");
                    sb.AppendLine($"CRUD      - HeadVersion");
                    sb.AppendLine($"CRUD      - IsLexiconSecret");
                    sb.AppendLine($"CRUD      - IsSchemaSecret");
                    sb.AppendLine($"CRUD      - LowerAirtableId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - OwnerEmail");
                    sb.AppendLine($"CRUD      - ProductionStage");
                    sb.AppendLine($"CRUD      - ProjectBuilds");
                    sb.AppendLine($"CRUD      - ProjectConnections");
                    sb.AppendLine($"CRUD      - ProjectEmailList");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectLexiconTerms");
                    sb.AppendLine($"CRUD      - ProjectRequestSummary");
                    sb.AppendLine($"CRUD      - ProjectStage");
                    sb.AppendLine($"CRUD      - ProjectStages");
                    sb.AppendLine($"CRUD      - ProjectType");
                    sb.AppendLine($"CRUD      - ProjectVersions");
                    sb.AppendLine($"CRUD      - RemoteEndpoints");
                    sb.AppendLine($"CRUD      - RoleColumnName");
                    sb.AppendLine($"CRUD      - RolesTable");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - ServiceLogo");
                    sb.AppendLine($"CRUD      - UseDebugDataStorage");
                    sb.AppendLine($"CRUD      - UserRole");
                    sb.AppendLine($"CRUD      - UserTable");
                    sb.AppendLine($"CRUD      - EffortlessAPIServiceName");
                    sb.AppendLine($"CRUD      - LastPublished");
                    sb.AppendLine($"CRUD      - RECORD_ID");
                    sb.AppendLine($"CRUD      - HeadStageIsEC2");
                    sb.AppendLine($"CRUD      - SubscriptionTotals");
                    sb.AppendLine($"CRUD      - AccountDiscount");
                    sb.AppendLine($"CRUD      - CustomMaxPages");
                    sb.AppendLine($"CRUD      - AccountDefaultMaxPages");
                    sb.AppendLine($"CRUD      - MaxPages");
                
            
        }
        
        public void PrintUpdateEffortlessAPIProjectHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EffortlessAPIProject     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EffortlessAPIProjectId");
                    sb.AppendLine($"CRUD      - ModifiedOn");
                    sb.AppendLine($"CRUD      - Account");
                    sb.AppendLine($"CRUD      - AccountName");
                    sb.AppendLine($"CRUD      - AdminRole");
                    sb.AppendLine($"CRUD      - AirtableId");
                    sb.AppendLine($"CRUD      - Alias");
                    sb.AppendLine($"CRUD      - AllowAirtableWhere");
                    sb.AppendLine($"CRUD      - AutoAssignedID");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - ConnectionString");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - DefaultDesiredAlias");
                    sb.AppendLine($"CRUD      - DesiredAlias");
                    sb.AppendLine($"CRUD      - EffortlessApiService");
                    sb.AppendLine($"CRUD      - EmailColumnName");
                    sb.AppendLine($"CRUD      - EntitiesTable");
                    sb.AppendLine($"CRUD      - GuestRole");
                    sb.AppendLine($"CRUD      - HeadStage");
                    sb.AppendLine($"CRUD      - HeadVersion");
                    sb.AppendLine($"CRUD      - IsLexiconSecret");
                    sb.AppendLine($"CRUD      - IsSchemaSecret");
                    sb.AppendLine($"CRUD      - LowerAirtableId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - OwnerEmail");
                    sb.AppendLine($"CRUD      - ProductionStage");
                    sb.AppendLine($"CRUD      - ProjectBuilds");
                    sb.AppendLine($"CRUD      - ProjectConnections");
                    sb.AppendLine($"CRUD      - ProjectEmailList");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectLexiconTerms");
                    sb.AppendLine($"CRUD      - ProjectRequestSummary");
                    sb.AppendLine($"CRUD      - ProjectStage");
                    sb.AppendLine($"CRUD      - ProjectStages");
                    sb.AppendLine($"CRUD      - ProjectType");
                    sb.AppendLine($"CRUD      - ProjectVersions");
                    sb.AppendLine($"CRUD      - RemoteEndpoints");
                    sb.AppendLine($"CRUD      - RoleColumnName");
                    sb.AppendLine($"CRUD      - RolesTable");
                    sb.AppendLine($"CRUD      - RowKey");
                    sb.AppendLine($"CRUD      - ServiceLogo");
                    sb.AppendLine($"CRUD      - UseDebugDataStorage");
                    sb.AppendLine($"CRUD      - UserRole");
                    sb.AppendLine($"CRUD      - UserTable");
                    sb.AppendLine($"CRUD      - EffortlessAPIServiceName");
                    sb.AppendLine($"CRUD      - LastPublished");
                    sb.AppendLine($"CRUD      - RECORD_ID");
                    sb.AppendLine($"CRUD      - HeadStageIsEC2");
                    sb.AppendLine($"CRUD      - SubscriptionTotals");
                    sb.AppendLine($"CRUD      - AccountDiscount");
                    sb.AppendLine($"CRUD      - CustomMaxPages");
                    sb.AppendLine($"CRUD      - AccountDefaultMaxPages");
                    sb.AppendLine($"CRUD      - MaxPages");
                
            
        }
        
        public void PrintDeleteEffortlessAPIProjectHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddColumnRoleCRUDHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ColumnRoleCRUD     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ColumnRoleCRUDId");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - ModifiedOn");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CanCreate");
                    sb.AppendLine($"CRUD      - CanDelete");
                    sb.AppendLine($"CRUD      - CanRead");
                    sb.AppendLine($"CRUD      - CanUpdate");
                    sb.AppendLine($"CRUD      - ColumnName");
                    sb.AppendLine($"CRUD      - CRUD");
                    sb.AppendLine($"CRUD      - DataType");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectRole");
                    sb.AppendLine($"CRUD      - ProjectTable");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RoleCRUD");
                    sb.AppendLine($"CRUD      - RoleName");
                    sb.AppendLine($"CRUD      - TableColumn");
                    sb.AppendLine($"CRUD      - TableName");
                
            
        }
        
        public void PrintGetColumnRoleCRUDsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ColumnRoleCRUD     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ColumnRoleCRUDId");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - ModifiedOn");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CanCreate");
                    sb.AppendLine($"CRUD      - CanDelete");
                    sb.AppendLine($"CRUD      - CanRead");
                    sb.AppendLine($"CRUD      - CanUpdate");
                    sb.AppendLine($"CRUD      - ColumnName");
                    sb.AppendLine($"CRUD      - CRUD");
                    sb.AppendLine($"CRUD      - DataType");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectRole");
                    sb.AppendLine($"CRUD      - ProjectTable");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RoleCRUD");
                    sb.AppendLine($"CRUD      - RoleName");
                    sb.AppendLine($"CRUD      - TableColumn");
                    sb.AppendLine($"CRUD      - TableName");
                
            
        }
        
        public void PrintUpdateColumnRoleCRUDHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ColumnRoleCRUD     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ColumnRoleCRUDId");
                    sb.AppendLine($"CRUD      - CreatedOn");
                    sb.AppendLine($"CRUD      - ModifiedOn");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - CanCreate");
                    sb.AppendLine($"CRUD      - CanDelete");
                    sb.AppendLine($"CRUD      - CanRead");
                    sb.AppendLine($"CRUD      - CanUpdate");
                    sb.AppendLine($"CRUD      - ColumnName");
                    sb.AppendLine($"CRUD      - CRUD");
                    sb.AppendLine($"CRUD      - DataType");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Project");
                    sb.AppendLine($"CRUD      - ProjectEmails");
                    sb.AppendLine($"CRUD      - ProjectRole");
                    sb.AppendLine($"CRUD      - ProjectTable");
                    sb.AppendLine($"CRUD      - ProjectVersion");
                    sb.AppendLine($"CRUD      - RoleCRUD");
                    sb.AppendLine($"CRUD      - RoleName");
                    sb.AppendLine($"CRUD      - TableColumn");
                    sb.AppendLine($"CRUD      - TableName");
                
            
        }
        
        public void PrintDeleteColumnRoleCRUDHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddSDKLanguageHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: SDKLanguage     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - SDKLanguageId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                
            
        }
        
        public void PrintGetSDKLanguagesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: SDKLanguage     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - SDKLanguageId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                
            
        }
        
        public void PrintUpdateSDKLanguageHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: SDKLanguage     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - SDKLanguageId");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                
            
        }
        
        public void PrintDeleteSDKLanguageHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddServiceKeyHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceKey     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceKeyId");
                    sb.AppendLine($"CRUD      - Account");
                    sb.AppendLine($"CRUD      - ApiKey");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PasswordHash");
                    sb.AppendLine($"CRUD      - Service");
                    sb.AppendLine($"CRUD      - Username");
                
            
        }
        
        public void PrintGetServiceKeysHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceKey     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceKeyId");
                    sb.AppendLine($"CRUD      - Account");
                    sb.AppendLine($"CRUD      - ApiKey");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PasswordHash");
                    sb.AppendLine($"CRUD      - Service");
                    sb.AppendLine($"CRUD      - Username");
                
            
        }
        
        public void PrintUpdateServiceKeyHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceKey     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ServiceKeyId");
                    sb.AppendLine($"CRUD      - Account");
                    sb.AppendLine($"CRUD      - ApiKey");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - PasswordHash");
                    sb.AppendLine($"CRUD      - Service");
                    sb.AppendLine($"CRUD      - Username");
                
            
        }
        
        public void PrintDeleteServiceKeyHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddCustomerTypeHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: CustomerType     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - CustomerTypeId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - IsOpenSource");
                    sb.AppendLine($"CRUD      - IsPaid");
                
            
        }
        
        public void PrintGetCustomerTypesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: CustomerType     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - CustomerTypeId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - IsOpenSource");
                    sb.AppendLine($"CRUD      - IsPaid");
                
            
        }
        
        public void PrintUpdateCustomerTypeHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: CustomerType     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - CustomerTypeId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - IsOpenSource");
                    sb.AppendLine($"CRUD      - IsPaid");
                
            
        }
        
        public void PrintDeleteCustomerTypeHelp(StringBuilder sb)
        {
            
        }
        

    }
}
