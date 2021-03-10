using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using EAPI.CLI.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class DeveloperCLIHandler
    {
        public override void AddHelp(StringBuilder sb, string helpTerm)
        {
            sb.AppendLine($"Help for Developer.");
            
            helpTerm = helpTerm.ToLower();
            var found = helpTerm == "general";
            
            if (helpTerm == "general")
            {
                sb.AppendLine();
                
                sb.AppendLine($"void: CancelBuild");
                sb.AppendLine($"void: GetEndpointDetails");
                sb.AppendLine($"void: StopEndpoint");
                sb.AppendLine($"void: ProxyStatusReport");
                sb.AppendLine($"void: SynchronizeSchema");
                sb.AppendLine($"void: MoveEndpoint");
                sb.AppendLine($"void: Publish");
                sb.AppendLine($"void: StartEndpoint");
                sb.AppendLine($"void: SynchronizeWithAirtable");
                sb.AppendLine($"void: DoSomethingElse");
                sb.AppendLine($"PlanProduct: GetPlanProducts");
                sb.AppendLine($"ProjectTable: AddProjectTable");
                sb.AppendLine($"ProjectTable: GetProjectTables");
                sb.AppendLine($"ProjectTable: UpdateProjectTable");
                sb.AppendLine($"void: DeleteProjectTable");
                sb.AppendLine($"ProjectStage: AddProjectStage");
                sb.AppendLine($"ProjectStage: GetProjectStages");
                sb.AppendLine($"ProjectStage: UpdateProjectStage");
                sb.AppendLine($"void: DeleteProjectStage");
                sb.AppendLine($"ProjectVersionBuild: AddProjectVersionBuild");
                sb.AppendLine($"ProjectVersionBuild: GetProjectVersionBuilds");
                sb.AppendLine($"ProjectVersionBuild: UpdateProjectVersionBuild");
                sb.AppendLine($"ProjectRole: AddProjectRole");
                sb.AppendLine($"ProjectRole: GetProjectRoles");
                sb.AppendLine($"ProjectRole: UpdateProjectRole");
                sb.AppendLine($"void: DeleteProjectRole");
                sb.AppendLine($"ServiceHostEndpoint: GetServiceHostEndpoints");
                sb.AppendLine($"EffortlessAPIService: GetEffortlessAPIServices");
                sb.AppendLine($"ProjectConnection: AddProjectConnection");
                sb.AppendLine($"ProjectConnection: GetProjectConnections");
                sb.AppendLine($"ProjectConnection: UpdateProjectConnection");
                sb.AppendLine($"void: DeleteProjectConnection");
                sb.AppendLine($"ProjectLexiconTerm: AddProjectLexiconTerm");
                sb.AppendLine($"ProjectLexiconTerm: GetProjectLexiconTerms");
                sb.AppendLine($"ProjectLexiconTerm: UpdateProjectLexiconTerm");
                sb.AppendLine($"void: DeleteProjectLexiconTerm");
                sb.AppendLine($"ProjectEmail: AddProjectEmail");
                sb.AppendLine($"ProjectEmail: GetProjectEmails");
                sb.AppendLine($"ProjectEmail: UpdateProjectEmail");
                sb.AppendLine($"void: DeleteProjectEmail");
                sb.AppendLine($"ProjectVersion: AddProjectVersion");
                sb.AppendLine($"ProjectVersion: GetProjectVersions");
                sb.AppendLine($"ProjectVersion: UpdateProjectVersion");
                sb.AppendLine($"EffortlessAPIAccount: AddEffortlessAPIAccount");
                sb.AppendLine($"EffortlessAPIAccount: GetEffortlessAPIAccounts");
                sb.AppendLine($"EffortlessAPIAccount: UpdateEffortlessAPIAccount");
                sb.AppendLine($"void: DeleteEffortlessAPIAccount");
                sb.AppendLine($"ServiceProduct: GetServiceProducts");
                sb.AppendLine($"ServicePlan: GetServicePlans");
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
            }
            
            sb.AppendLine($"{Environment.NewLine}Available Actions Matching: {helpTerm}");
            
            if ("cancelbuild".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - CancelBuild");
                if ("cancelbuild".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintCancelBuildHelp(sb);
                }
                found = true;
            }
            if ("getendpointdetails".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetEndpointDetails");
                if ("getendpointdetails".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetEndpointDetailsHelp(sb);
                }
                found = true;
            }
            if ("stopendpoint".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - StopEndpoint");
                if ("stopendpoint".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintStopEndpointHelp(sb);
                }
                found = true;
            }
            if ("proxystatusreport".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - ProxyStatusReport");
                if ("proxystatusreport".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintProxyStatusReportHelp(sb);
                }
                found = true;
            }
            if ("synchronizeschema".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - SynchronizeSchema");
                if ("synchronizeschema".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintSynchronizeSchemaHelp(sb);
                }
                found = true;
            }
            if ("moveendpoint".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - MoveEndpoint");
                if ("moveendpoint".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintMoveEndpointHelp(sb);
                }
                found = true;
            }
            if ("publish".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - Publish");
                if ("publish".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintPublishHelp(sb);
                }
                found = true;
            }
            if ("startendpoint".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - StartEndpoint");
                if ("startendpoint".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintStartEndpointHelp(sb);
                }
                found = true;
            }
            if ("synchronizewithairtable".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - SynchronizeWithAirtable");
                if ("synchronizewithairtable".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintSynchronizeWithAirtableHelp(sb);
                }
                found = true;
            }
            if ("dosomethingelse".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DoSomethingElse");
                if ("dosomethingelse".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDoSomethingElseHelp(sb);
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
            if ("getservicehostendpoints".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetServiceHostEndpoints");
                if ("getservicehostendpoints".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetServiceHostEndpointsHelp(sb);
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
            if ("getserviceproducts".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetServiceProducts");
                if ("getserviceproducts".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetServiceProductsHelp(sb);
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
                       
            if (!found)
            {
                sb.AppendLine();
                sb.AppendLine($"{Environment.NewLine}UNABLE TO FIND COMMAND: {helpTerm} not found.");
            }
        }

        private string HandlerFactory(string invokeRequest, string payloadString, string where, int maxPages)
        {
            var result = "";
            var payload = JsonConvert.DeserializeObject<StandardPayload>(payloadString);
            payload.SetActor(this.SMQActor);
            payload.AccessToken = this.SMQActor.AccessToken;
            payload.AirtableWhere = where;
            payload.MaxPages = maxPages;

            switch (invokeRequest.ToLower())
            {
                case "cancelbuild":
                    this.SMQActor.CancelBuild(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getendpointdetails":
                    this.SMQActor.GetEndpointDetails(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "stopendpoint":
                    this.SMQActor.StopEndpoint(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "proxystatusreport":
                    this.SMQActor.ProxyStatusReport(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "synchronizeschema":
                    this.SMQActor.SynchronizeSchema(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "moveendpoint":
                    this.SMQActor.MoveEndpoint(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "publish":
                    this.SMQActor.Publish(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "startendpoint":
                    this.SMQActor.StartEndpoint(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "synchronizewithairtable":
                    this.SMQActor.SynchronizeWithAirtable(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "dosomethingelse":
                    this.SMQActor.DoSomethingElse(payload, (reply, bdea) =>
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

                case "getservicehostendpoints":
                    this.SMQActor.GetServiceHostEndpoints(payload, (reply, bdea) =>
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

                case "getserviceproducts":
                    this.SMQActor.GetServiceProducts(payload, (reply, bdea) =>
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

                default:
                    throw new Exception($"Invalid request: {invokeRequest}");
            }

            return result;
        }
        
        
        public void PrintCancelBuildHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintGetEndpointDetailsHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintStopEndpointHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintProxyStatusReportHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintSynchronizeSchemaHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintMoveEndpointHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintPublishHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintStartEndpointHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintSynchronizeWithAirtableHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintDoSomethingElseHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintGetPlanProductsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: PlanProduct     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"R      - PlanProductId");
                    sb.AppendLine($"R      - AdjustmentAmount");
                    sb.AppendLine($"R      - Attachments");
                    sb.AppendLine($"R      - EffectiveQuantity");
                    sb.AppendLine($"R      - FinalQuantity");
                    sb.AppendLine($"R      - FinalQuantityUnitCost");
                    sb.AppendLine($"R      - HighEndUser");
                    sb.AppendLine($"R      - HighEndUserMonthlySubscription");
                    sb.AppendLine($"R      - Included");
                    sb.AppendLine($"R      - IsActive");
                    sb.AppendLine($"R      - IsIncludedByDefault");
                    sb.AppendLine($"R      - Max");
                    sb.AppendLine($"R      - Min");
                    sb.AppendLine($"R      - MonthlySubscription");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                    sb.AppendLine($"R      - PlanDiscount");
                    sb.AppendLine($"R      - PlanPrice");
                    sb.AppendLine($"R      - PricingModel");
                    sb.AppendLine($"R      - ProductDescriptions");
                    sb.AppendLine($"R      - ProductLogo");
                    sb.AppendLine($"R      - ProductSortOrder");
                    sb.AppendLine($"R      - RadioGroup");
                    sb.AppendLine($"R      - ServicePlan");
                    sb.AppendLine($"R      - ServicePlanName");
                    sb.AppendLine($"R      - ServiceProduct");
                    sb.AppendLine($"R      - SuggestedMSRP");
                    sb.AppendLine($"R      - SuggestedPlanPrice");
                    sb.AppendLine($"R      - UnitPrice");
                    sb.AppendLine($"R      - UnitPriceAdjustment");
                    sb.AppendLine($"R      - VolumeScalePercent");
                
            
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
                
                    sb.AppendLine($"CRU      - ProjectVersionBuildId");
                    sb.AppendLine($"CRU      - Attachments");
                    sb.AppendLine($"CRU      - BuildCompleted");
                    sb.AppendLine($"CRU      - BuildOutput");
                    sb.AppendLine($"CRU      - BuildStarted");
                    sb.AppendLine($"CRU      - BuildSucceeded");
                    sb.AppendLine($"CRU      - ErrorOutput");
                    sb.AppendLine($"CRU      - FinalTaskName");
                    sb.AppendLine($"CRU      - Name");
                    sb.AppendLine($"CRU      - Notes");
                    sb.AppendLine($"CRU      - Project");
                    sb.AppendLine($"CRU      - ProjectVersion");
                
            
        }
        
        public void PrintGetProjectVersionBuildsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectVersionBuild     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRU      - ProjectVersionBuildId");
                    sb.AppendLine($"CRU      - Attachments");
                    sb.AppendLine($"CRU      - BuildCompleted");
                    sb.AppendLine($"CRU      - BuildOutput");
                    sb.AppendLine($"CRU      - BuildStarted");
                    sb.AppendLine($"CRU      - BuildSucceeded");
                    sb.AppendLine($"CRU      - ErrorOutput");
                    sb.AppendLine($"CRU      - FinalTaskName");
                    sb.AppendLine($"CRU      - Name");
                    sb.AppendLine($"CRU      - Notes");
                    sb.AppendLine($"CRU      - Project");
                    sb.AppendLine($"CRU      - ProjectVersion");
                
            
        }
        
        public void PrintUpdateProjectVersionBuildHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectVersionBuild     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRU      - ProjectVersionBuildId");
                    sb.AppendLine($"CRU      - Attachments");
                    sb.AppendLine($"CRU      - BuildCompleted");
                    sb.AppendLine($"CRU      - BuildOutput");
                    sb.AppendLine($"CRU      - BuildStarted");
                    sb.AppendLine($"CRU      - BuildSucceeded");
                    sb.AppendLine($"CRU      - ErrorOutput");
                    sb.AppendLine($"CRU      - FinalTaskName");
                    sb.AppendLine($"CRU      - Name");
                    sb.AppendLine($"CRU      - Notes");
                    sb.AppendLine($"CRU      - Project");
                    sb.AppendLine($"CRU      - ProjectVersion");
                
            
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
        
        public void PrintGetServiceHostEndpointsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostEndpoint     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"R      - ServiceHostEndpointId");
                    sb.AppendLine($"R      - Alias");
                    sb.AppendLine($"R      - AmqpsConnectionString");
                    sb.AppendLine($"R      - Attachments");
                    sb.AppendLine($"R      - AwsId");
                    sb.AppendLine($"R      - AwsRegion");
                    sb.AppendLine($"R      - BaseUrl");
                    sb.AppendLine($"R      - ClusterAwsId");
                    sb.AppendLine($"R      - ClusterAwsRegion");
                    sb.AppendLine($"R      - ClusterName");
                    sb.AppendLine($"R      - DefaultPassword");
                    sb.AppendLine($"R      - DefaultUsername");
                    sb.AppendLine($"R      - DesiredCount");
                    sb.AppendLine($"R      - EndpointSize");
                    sb.AppendLine($"R      - IsActive");
                    sb.AppendLine($"R      - IsEC2");
                    sb.AppendLine($"R      - IsFargate");
                    sb.AppendLine($"R      - IsSecure");
                    sb.AppendLine($"R      - MaxCPU");
                    sb.AppendLine($"R      - MaxMemory");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                    sb.AppendLine($"R      - Profile");
                    sb.AppendLine($"R      - ProjectStages");
                    sb.AppendLine($"R      - ProjectTasks");
                    sb.AppendLine($"R      - RabbitMQDefaultUsername");
                    sb.AppendLine($"R      - RabbitMQEndpoint");
                    sb.AppendLine($"R      - RabbitMQHost");
                    sb.AppendLine($"R      - RabbitMQHostUrl");
                    sb.AppendLine($"R      - SecurityGroup");
                    sb.AppendLine($"R      - ServiceHostType");
                    sb.AppendLine($"R      - ServiceName");
                    sb.AppendLine($"R      - Subnet");
                    sb.AppendLine($"R      - TaskClusterEndpoint");
                    sb.AppendLine($"R      - TaskDefinitionJsonLocation");
                    sb.AppendLine($"R      - TaskExecutionRole");
                    sb.AppendLine($"R      - TaskRabbitMQAdminUsername");
                    sb.AppendLine($"R      - TaskRabbitMQEndpoint");
                    sb.AppendLine($"R      - TaskSassyMQEndpoint");
                    sb.AppendLine($"R      - RECORD_ID");
                    sb.AppendLine($"R      - IsEAPIEndpoint");
                
            
        }
        
        public void PrintGetEffortlessAPIServicesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EffortlessAPIService     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"R      - EffortlessAPIServiceId");
                    sb.AppendLine($"R      - EffortlessApiProjects");
                    sb.AppendLine($"R      - Attachments");
                    sb.AppendLine($"R      - DisplayName");
                    sb.AppendLine($"R      - EffortlessAPIProjects");
                    sb.AppendLine($"R      - IsActive");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                    sb.AppendLine($"R      - ProjectConnections");
                    sb.AppendLine($"R      - ServiceKeys");
                    sb.AppendLine($"R      - ServicePlan");
                    sb.AppendLine($"R      - ServiceStatus");
                    sb.AppendLine($"R      - ServiceType");
                    sb.AppendLine($"R      - SortOrder");
                    sb.AppendLine($"R      - AirtableRecordID");
                
            
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
                
                    sb.AppendLine($"CRU      - ProjectVersionId");
                    sb.AppendLine($"CRU      - Attachments");
                    sb.AppendLine($"CRU      - ConnectionString");
                    sb.AppendLine($"CRU      - CreatedAt");
                    sb.AppendLine($"CRU      - Name");
                    sb.AppendLine($"CRU      - Notes");
                    sb.AppendLine($"CRU      - OverrideVersion");
                    sb.AppendLine($"CRU      - Project");
                    sb.AppendLine($"CRU      - ProjectEmails");
                    sb.AppendLine($"CRU      - ProjectNumber");
                    sb.AppendLine($"CRU      - ProjectRoles");
                    sb.AppendLine($"CRU      - ProjectStages");
                    sb.AppendLine($"CRU      - ProjectTables");
                    sb.AppendLine($"CRU      - ProjectVersionBuilds");
                    sb.AppendLine($"CRU      - RoleCount");
                    sb.AppendLine($"CRU      - StageNames");
                    sb.AppendLine($"CRU      - TableCount");
                    sb.AppendLine($"CRU      - VersionConnection");
                    sb.AppendLine($"CRU      - VersionNumber");
                    sb.AppendLine($"CRU      - ProjectService");
                    sb.AppendLine($"CRU      - ProjectServiceLogo");
                    sb.AppendLine($"CRU      - ProjectServiceName");
                
            
        }
        
        public void PrintGetProjectVersionsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectVersion     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRU      - ProjectVersionId");
                    sb.AppendLine($"CRU      - Attachments");
                    sb.AppendLine($"CRU      - ConnectionString");
                    sb.AppendLine($"CRU      - CreatedAt");
                    sb.AppendLine($"CRU      - Name");
                    sb.AppendLine($"CRU      - Notes");
                    sb.AppendLine($"CRU      - OverrideVersion");
                    sb.AppendLine($"CRU      - Project");
                    sb.AppendLine($"CRU      - ProjectEmails");
                    sb.AppendLine($"CRU      - ProjectNumber");
                    sb.AppendLine($"CRU      - ProjectRoles");
                    sb.AppendLine($"CRU      - ProjectStages");
                    sb.AppendLine($"CRU      - ProjectTables");
                    sb.AppendLine($"CRU      - ProjectVersionBuilds");
                    sb.AppendLine($"CRU      - RoleCount");
                    sb.AppendLine($"CRU      - StageNames");
                    sb.AppendLine($"CRU      - TableCount");
                    sb.AppendLine($"CRU      - VersionConnection");
                    sb.AppendLine($"CRU      - VersionNumber");
                    sb.AppendLine($"CRU      - ProjectService");
                    sb.AppendLine($"CRU      - ProjectServiceLogo");
                    sb.AppendLine($"CRU      - ProjectServiceName");
                
            
        }
        
        public void PrintUpdateProjectVersionHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ProjectVersion     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRU      - ProjectVersionId");
                    sb.AppendLine($"CRU      - Attachments");
                    sb.AppendLine($"CRU      - ConnectionString");
                    sb.AppendLine($"CRU      - CreatedAt");
                    sb.AppendLine($"CRU      - Name");
                    sb.AppendLine($"CRU      - Notes");
                    sb.AppendLine($"CRU      - OverrideVersion");
                    sb.AppendLine($"CRU      - Project");
                    sb.AppendLine($"CRU      - ProjectEmails");
                    sb.AppendLine($"CRU      - ProjectNumber");
                    sb.AppendLine($"CRU      - ProjectRoles");
                    sb.AppendLine($"CRU      - ProjectStages");
                    sb.AppendLine($"CRU      - ProjectTables");
                    sb.AppendLine($"CRU      - ProjectVersionBuilds");
                    sb.AppendLine($"CRU      - RoleCount");
                    sb.AppendLine($"CRU      - StageNames");
                    sb.AppendLine($"CRU      - TableCount");
                    sb.AppendLine($"CRU      - VersionConnection");
                    sb.AppendLine($"CRU      - VersionNumber");
                    sb.AppendLine($"CRU      - ProjectService");
                    sb.AppendLine($"CRU      - ProjectServiceLogo");
                    sb.AppendLine($"CRU      - ProjectServiceName");
                
            
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
        
        public void PrintGetServiceProductsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceProduct     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"R      - ServiceProductId");
                    sb.AppendLine($"R      - Attachments");
                    sb.AppendLine($"R      - Category");
                    sb.AppendLine($"R      - DisplayName");
                    sb.AppendLine($"R      - EffectiveQuantity");
                    sb.AppendLine($"R      - IsActive");
                    sb.AppendLine($"R      - MSRP");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                    sb.AppendLine($"R      - PlanProducts");
                    sb.AppendLine($"R      - PricingModel");
                    sb.AppendLine($"R      - RadioGroup");
                    sb.AppendLine($"R      - SortOrder");
                
            
        }
        
        public void PrintGetServicePlansHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServicePlan     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"R      - ServicePlanId");
                    sb.AppendLine($"R      - Attachments");
                    sb.AppendLine($"R      - CallForPricing");
                    sb.AppendLine($"R      - DefaultDiscount");
                    sb.AppendLine($"R      - DisplayName");
                    sb.AppendLine($"R      - EffortlessAPIService");
                    sb.AppendLine($"R      - IsActive");
                    sb.AppendLine($"R      - IsDeveloperPlan");
                    sb.AppendLine($"R      - MonthlyPrice");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                    sb.AppendLine($"R      - NumberedDisplayName");
                    sb.AppendLine($"R      - PlanProducts");
                    sb.AppendLine($"R      - RawPrice");
                    sb.AppendLine($"R      - ServicePlanProducts");
                    sb.AppendLine($"R      - SortOrder");
                    sb.AppendLine($"R      - SuggestedPrice");
                    sb.AppendLine($"R      - EffortlessApiService");
                
            
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
                    sb.AppendLine($"CRUD      - DefaultCallCRUD");
                
            
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
                    sb.AppendLine($"CRUD      - DefaultCallCRUD");
                
            
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
                    sb.AppendLine($"CRUD      - DefaultCallCRUD");
                
            
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
        

    }
}
