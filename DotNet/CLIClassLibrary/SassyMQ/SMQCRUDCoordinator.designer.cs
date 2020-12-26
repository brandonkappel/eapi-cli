using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQCRUDCoordinator : SMQActorBase
    {

        public SMQCRUDCoordinator(String amqpConnectionString)
            : base(amqpConnectionString, "crudcoordinator")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            var originalAccessToken = payload.AccessToken;
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                    case "crudcoordinator.general.guest.requesttoken":
                        this.OnGuestRequestTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.validatetemporaryaccesstoken":
                        this.OnGuestValidateTemporaryAccessTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.whoami":
                        this.OnGuestWhoAmIReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.whoareyou":
                        this.OnGuestWhoAreYouReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.utlity.guest.storetempfile":
                        this.OnGuestStoreTempFileReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.crudcoordinator.resetrabbitsassymqconfiguration":
                        this.OnCRUDCoordinatorResetRabbitSassyMQConfigurationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.crudcoordinator.resetjwtsecretkey":
                        this.OnCRUDCoordinatorResetJWTSecretKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.custom.developer.cancelbuild":
                        this.OnDeveloperCancelBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.custom.developer.getendpointdetails":
                        this.OnDeveloperGetEndpointDetailsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.custom.developer.stopendpoint":
                        this.OnDeveloperStopEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.custom.developer.proxystatusreport":
                        this.OnDeveloperProxyStatusReportReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.custom.developer.synchronizeschema":
                        this.OnDeveloperSynchronizeSchemaReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.custom.developer.moveendpoint":
                        this.OnDeveloperMoveEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.custom.developer.publish":
                        this.OnDeveloperPublishReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.custom.developer.startendpoint":
                        this.OnDeveloperStartEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.custom.developer.synchronizewithairtable":
                        this.OnDeveloperSynchronizeWithAirtableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.custom.developer.dosomethingelse":
                        this.OnDeveloperDoSomethingElseReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.getplanproducts":
                        this.OnGuestGetPlanProductsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addplanproduct":
                        this.OnEffortlessProxyDataCoordinatorAddPlanProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getplanproducts":
                        this.OnEffortlessProxyDataCoordinatorGetPlanProductsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateplanproduct":
                        this.OnEffortlessProxyDataCoordinatorUpdatePlanProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteplanproduct":
                        this.OnEffortlessProxyDataCoordinatorDeletePlanProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getplanproducts":
                        this.OnDeveloperGetPlanProductsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addplanproduct":
                        this.OnAdminAddPlanProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getplanproducts":
                        this.OnAdminGetPlanProductsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateplanproduct":
                        this.OnAdminUpdatePlanProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteplanproduct":
                        this.OnAdminDeletePlanProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addplanproduct":
                        this.OnCRUDCoordinatorAddPlanProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getplanproducts":
                        this.OnCRUDCoordinatorGetPlanProductsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateplanproduct":
                        this.OnCRUDCoordinatorUpdatePlanProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteplanproduct":
                        this.OnCRUDCoordinatorDeletePlanProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addprojecttable":
                        this.OnEffortlessProxyDataCoordinatorAddProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getprojecttables":
                        this.OnEffortlessProxyDataCoordinatorGetProjectTablesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateprojecttable":
                        this.OnEffortlessProxyDataCoordinatorUpdateProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteprojecttable":
                        this.OnEffortlessProxyDataCoordinatorDeleteProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addprojecttable":
                        this.OnDeveloperAddProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getprojecttables":
                        this.OnDeveloperGetProjectTablesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updateprojecttable":
                        this.OnDeveloperUpdateProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deleteprojecttable":
                        this.OnDeveloperDeleteProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addprojecttable":
                        this.OnAdminAddProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getprojecttables":
                        this.OnAdminGetProjectTablesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateprojecttable":
                        this.OnAdminUpdateProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteprojecttable":
                        this.OnAdminDeleteProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addprojecttable":
                        this.OnCRUDCoordinatorAddProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getprojecttables":
                        this.OnCRUDCoordinatorGetProjectTablesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateprojecttable":
                        this.OnCRUDCoordinatorUpdateProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteprojecttable":
                        this.OnCRUDCoordinatorDeleteProjectTableReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addservicehostsize":
                        this.OnEffortlessProxyDataCoordinatorAddServiceHostSizeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getservicehostsizes":
                        this.OnEffortlessProxyDataCoordinatorGetServiceHostSizesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateservicehostsize":
                        this.OnEffortlessProxyDataCoordinatorUpdateServiceHostSizeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteservicehostsize":
                        this.OnEffortlessProxyDataCoordinatorDeleteServiceHostSizeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addservicehostsize":
                        this.OnAdminAddServiceHostSizeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getservicehostsizes":
                        this.OnAdminGetServiceHostSizesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateservicehostsize":
                        this.OnAdminUpdateServiceHostSizeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteservicehostsize":
                        this.OnAdminDeleteServiceHostSizeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addservicehostsize":
                        this.OnCRUDCoordinatorAddServiceHostSizeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getservicehostsizes":
                        this.OnCRUDCoordinatorGetServiceHostSizesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateservicehostsize":
                        this.OnCRUDCoordinatorUpdateServiceHostSizeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteservicehostsize":
                        this.OnCRUDCoordinatorDeleteServiceHostSizeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addcolumnvalue":
                        this.OnEffortlessProxyDataCoordinatorAddColumnValueReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getcolumnvalues":
                        this.OnEffortlessProxyDataCoordinatorGetColumnValuesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updatecolumnvalue":
                        this.OnEffortlessProxyDataCoordinatorUpdateColumnValueReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deletecolumnvalue":
                        this.OnEffortlessProxyDataCoordinatorDeleteColumnValueReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addcolumnvalue":
                        this.OnAdminAddColumnValueReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getcolumnvalues":
                        this.OnAdminGetColumnValuesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatecolumnvalue":
                        this.OnAdminUpdateColumnValueReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletecolumnvalue":
                        this.OnAdminDeleteColumnValueReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addcolumnvalue":
                        this.OnCRUDCoordinatorAddColumnValueReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getcolumnvalues":
                        this.OnCRUDCoordinatorGetColumnValuesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updatecolumnvalue":
                        this.OnCRUDCoordinatorUpdateColumnValueReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deletecolumnvalue":
                        this.OnCRUDCoordinatorDeleteColumnValueReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addportfolioitemretired":
                        this.OnEffortlessProxyDataCoordinatorAddPortfolioItemRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getportfolioitemsretired":
                        this.OnEffortlessProxyDataCoordinatorGetPortfolioItemsRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateportfolioitemretired":
                        this.OnEffortlessProxyDataCoordinatorUpdatePortfolioItemRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteportfolioitemretired":
                        this.OnEffortlessProxyDataCoordinatorDeletePortfolioItemRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addportfolioitemretired":
                        this.OnAdminAddPortfolioItemRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getportfolioitemsretired":
                        this.OnAdminGetPortfolioItemsRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateportfolioitemretired":
                        this.OnAdminUpdatePortfolioItemRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteportfolioitemretired":
                        this.OnAdminDeletePortfolioItemRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addportfolioitemretired":
                        this.OnCRUDCoordinatorAddPortfolioItemRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getportfolioitemsretired":
                        this.OnCRUDCoordinatorGetPortfolioItemsRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateportfolioitemretired":
                        this.OnCRUDCoordinatorUpdatePortfolioItemRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteportfolioitemretired":
                        this.OnCRUDCoordinatorDeletePortfolioItemRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addprojectstage":
                        this.OnEffortlessProxyDataCoordinatorAddProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getprojectstages":
                        this.OnEffortlessProxyDataCoordinatorGetProjectStagesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateprojectstage":
                        this.OnEffortlessProxyDataCoordinatorUpdateProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteprojectstage":
                        this.OnEffortlessProxyDataCoordinatorDeleteProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addprojectstage":
                        this.OnDeveloperAddProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getprojectstages":
                        this.OnDeveloperGetProjectStagesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updateprojectstage":
                        this.OnDeveloperUpdateProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deleteprojectstage":
                        this.OnDeveloperDeleteProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addprojectstage":
                        this.OnAdminAddProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getprojectstages":
                        this.OnAdminGetProjectStagesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateprojectstage":
                        this.OnAdminUpdateProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteprojectstage":
                        this.OnAdminDeleteProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addprojectstage":
                        this.OnCRUDCoordinatorAddProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getprojectstages":
                        this.OnCRUDCoordinatorGetProjectStagesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateprojectstage":
                        this.OnCRUDCoordinatorUpdateProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteprojectstage":
                        this.OnCRUDCoordinatorDeleteProjectStageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addprojectversionbuild":
                        this.OnEffortlessProxyDataCoordinatorAddProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getprojectversionbuilds":
                        this.OnEffortlessProxyDataCoordinatorGetProjectVersionBuildsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateprojectversionbuild":
                        this.OnEffortlessProxyDataCoordinatorUpdateProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteprojectversionbuild":
                        this.OnEffortlessProxyDataCoordinatorDeleteProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addprojectversionbuild":
                        this.OnDeveloperAddProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getprojectversionbuilds":
                        this.OnDeveloperGetProjectVersionBuildsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updateprojectversionbuild":
                        this.OnDeveloperUpdateProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addprojectversionbuild":
                        this.OnAdminAddProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getprojectversionbuilds":
                        this.OnAdminGetProjectVersionBuildsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateprojectversionbuild":
                        this.OnAdminUpdateProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteprojectversionbuild":
                        this.OnAdminDeleteProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addprojectversionbuild":
                        this.OnCRUDCoordinatorAddProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getprojectversionbuilds":
                        this.OnCRUDCoordinatorGetProjectVersionBuildsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateprojectversionbuild":
                        this.OnCRUDCoordinatorUpdateProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteprojectversionbuild":
                        this.OnCRUDCoordinatorDeleteProjectVersionBuildReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addprojectrole":
                        this.OnEffortlessProxyDataCoordinatorAddProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getprojectroles":
                        this.OnEffortlessProxyDataCoordinatorGetProjectRolesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateprojectrole":
                        this.OnEffortlessProxyDataCoordinatorUpdateProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteprojectrole":
                        this.OnEffortlessProxyDataCoordinatorDeleteProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addprojectrole":
                        this.OnDeveloperAddProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getprojectroles":
                        this.OnDeveloperGetProjectRolesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updateprojectrole":
                        this.OnDeveloperUpdateProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deleteprojectrole":
                        this.OnDeveloperDeleteProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addprojectrole":
                        this.OnAdminAddProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getprojectroles":
                        this.OnAdminGetProjectRolesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateprojectrole":
                        this.OnAdminUpdateProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteprojectrole":
                        this.OnAdminDeleteProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addprojectrole":
                        this.OnCRUDCoordinatorAddProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getprojectroles":
                        this.OnCRUDCoordinatorGetProjectRolesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateprojectrole":
                        this.OnCRUDCoordinatorUpdateProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteprojectrole":
                        this.OnCRUDCoordinatorDeleteProjectRoleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.getservicehostendpoints":
                        this.OnGuestGetServiceHostEndpointsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addservicehostendpoint":
                        this.OnEffortlessProxyDataCoordinatorAddServiceHostEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getservicehostendpoints":
                        this.OnEffortlessProxyDataCoordinatorGetServiceHostEndpointsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateservicehostendpoint":
                        this.OnEffortlessProxyDataCoordinatorUpdateServiceHostEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteservicehostendpoint":
                        this.OnEffortlessProxyDataCoordinatorDeleteServiceHostEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getservicehostendpoints":
                        this.OnDeveloperGetServiceHostEndpointsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addservicehostendpoint":
                        this.OnAdminAddServiceHostEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getservicehostendpoints":
                        this.OnAdminGetServiceHostEndpointsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateservicehostendpoint":
                        this.OnAdminUpdateServiceHostEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteservicehostendpoint":
                        this.OnAdminDeleteServiceHostEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addservicehostendpoint":
                        this.OnCRUDCoordinatorAddServiceHostEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getservicehostendpoints":
                        this.OnCRUDCoordinatorGetServiceHostEndpointsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateservicehostendpoint":
                        this.OnCRUDCoordinatorUpdateServiceHostEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteservicehostendpoint":
                        this.OnCRUDCoordinatorDeleteServiceHostEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.geteffortlessapiservices":
                        this.OnGuestGetEffortlessAPIServicesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addeffortlessapiservice":
                        this.OnEffortlessProxyDataCoordinatorAddEffortlessAPIServiceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.geteffortlessapiservices":
                        this.OnEffortlessProxyDataCoordinatorGetEffortlessAPIServicesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateeffortlessapiservice":
                        this.OnEffortlessProxyDataCoordinatorUpdateEffortlessAPIServiceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteeffortlessapiservice":
                        this.OnEffortlessProxyDataCoordinatorDeleteEffortlessAPIServiceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.geteffortlessapiservices":
                        this.OnDeveloperGetEffortlessAPIServicesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addeffortlessapiservice":
                        this.OnAdminAddEffortlessAPIServiceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.geteffortlessapiservices":
                        this.OnAdminGetEffortlessAPIServicesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateeffortlessapiservice":
                        this.OnAdminUpdateEffortlessAPIServiceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteeffortlessapiservice":
                        this.OnAdminDeleteEffortlessAPIServiceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addeffortlessapiservice":
                        this.OnCRUDCoordinatorAddEffortlessAPIServiceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.geteffortlessapiservices":
                        this.OnCRUDCoordinatorGetEffortlessAPIServicesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateeffortlessapiservice":
                        this.OnCRUDCoordinatorUpdateEffortlessAPIServiceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteeffortlessapiservice":
                        this.OnCRUDCoordinatorDeleteEffortlessAPIServiceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addprojectconnection":
                        this.OnEffortlessProxyDataCoordinatorAddProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getprojectconnections":
                        this.OnEffortlessProxyDataCoordinatorGetProjectConnectionsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateprojectconnection":
                        this.OnEffortlessProxyDataCoordinatorUpdateProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteprojectconnection":
                        this.OnEffortlessProxyDataCoordinatorDeleteProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addprojectconnection":
                        this.OnDeveloperAddProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getprojectconnections":
                        this.OnDeveloperGetProjectConnectionsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updateprojectconnection":
                        this.OnDeveloperUpdateProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deleteprojectconnection":
                        this.OnDeveloperDeleteProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addprojectconnection":
                        this.OnAdminAddProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getprojectconnections":
                        this.OnAdminGetProjectConnectionsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateprojectconnection":
                        this.OnAdminUpdateProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteprojectconnection":
                        this.OnAdminDeleteProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addprojectconnection":
                        this.OnCRUDCoordinatorAddProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getprojectconnections":
                        this.OnCRUDCoordinatorGetProjectConnectionsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateprojectconnection":
                        this.OnCRUDCoordinatorUpdateProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteprojectconnection":
                        this.OnCRUDCoordinatorDeleteProjectConnectionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addprojectlexiconterm":
                        this.OnEffortlessProxyDataCoordinatorAddProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getprojectlexiconterms":
                        this.OnEffortlessProxyDataCoordinatorGetProjectLexiconTermsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateprojectlexiconterm":
                        this.OnEffortlessProxyDataCoordinatorUpdateProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteprojectlexiconterm":
                        this.OnEffortlessProxyDataCoordinatorDeleteProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addprojectlexiconterm":
                        this.OnDeveloperAddProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getprojectlexiconterms":
                        this.OnDeveloperGetProjectLexiconTermsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updateprojectlexiconterm":
                        this.OnDeveloperUpdateProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deleteprojectlexiconterm":
                        this.OnDeveloperDeleteProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addprojectlexiconterm":
                        this.OnAdminAddProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getprojectlexiconterms":
                        this.OnAdminGetProjectLexiconTermsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateprojectlexiconterm":
                        this.OnAdminUpdateProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteprojectlexiconterm":
                        this.OnAdminDeleteProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addprojectlexiconterm":
                        this.OnCRUDCoordinatorAddProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getprojectlexiconterms":
                        this.OnCRUDCoordinatorGetProjectLexiconTermsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateprojectlexiconterm":
                        this.OnCRUDCoordinatorUpdateProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteprojectlexiconterm":
                        this.OnCRUDCoordinatorDeleteProjectLexiconTermReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addportfolioretired":
                        this.OnEffortlessProxyDataCoordinatorAddPortfolioRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getportfoliosretired":
                        this.OnEffortlessProxyDataCoordinatorGetPortfoliosRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateportfolioretired":
                        this.OnEffortlessProxyDataCoordinatorUpdatePortfolioRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteportfolioretired":
                        this.OnEffortlessProxyDataCoordinatorDeletePortfolioRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addportfolioretired":
                        this.OnAdminAddPortfolioRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getportfoliosretired":
                        this.OnAdminGetPortfoliosRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateportfolioretired":
                        this.OnAdminUpdatePortfolioRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteportfolioretired":
                        this.OnAdminDeletePortfolioRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addportfolioretired":
                        this.OnCRUDCoordinatorAddPortfolioRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getportfoliosretired":
                        this.OnCRUDCoordinatorGetPortfoliosRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateportfolioretired":
                        this.OnCRUDCoordinatorUpdatePortfolioRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteportfolioretired":
                        this.OnCRUDCoordinatorDeletePortfolioRETIREDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addprojectemail":
                        this.OnEffortlessProxyDataCoordinatorAddProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getprojectemails":
                        this.OnEffortlessProxyDataCoordinatorGetProjectEmailsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateprojectemail":
                        this.OnEffortlessProxyDataCoordinatorUpdateProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteprojectemail":
                        this.OnEffortlessProxyDataCoordinatorDeleteProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addprojectemail":
                        this.OnDeveloperAddProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getprojectemails":
                        this.OnDeveloperGetProjectEmailsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updateprojectemail":
                        this.OnDeveloperUpdateProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deleteprojectemail":
                        this.OnDeveloperDeleteProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addprojectemail":
                        this.OnAdminAddProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getprojectemails":
                        this.OnAdminGetProjectEmailsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateprojectemail":
                        this.OnAdminUpdateProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteprojectemail":
                        this.OnAdminDeleteProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addprojectemail":
                        this.OnCRUDCoordinatorAddProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getprojectemails":
                        this.OnCRUDCoordinatorGetProjectEmailsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateprojectemail":
                        this.OnCRUDCoordinatorUpdateProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteprojectemail":
                        this.OnCRUDCoordinatorDeleteProjectEmailReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addprojectversion":
                        this.OnEffortlessProxyDataCoordinatorAddProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getprojectversions":
                        this.OnEffortlessProxyDataCoordinatorGetProjectVersionsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateprojectversion":
                        this.OnEffortlessProxyDataCoordinatorUpdateProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteprojectversion":
                        this.OnEffortlessProxyDataCoordinatorDeleteProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addprojectversion":
                        this.OnDeveloperAddProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getprojectversions":
                        this.OnDeveloperGetProjectVersionsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updateprojectversion":
                        this.OnDeveloperUpdateProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addprojectversion":
                        this.OnAdminAddProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getprojectversions":
                        this.OnAdminGetProjectVersionsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateprojectversion":
                        this.OnAdminUpdateProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteprojectversion":
                        this.OnAdminDeleteProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addprojectversion":
                        this.OnCRUDCoordinatorAddProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getprojectversions":
                        this.OnCRUDCoordinatorGetProjectVersionsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateprojectversion":
                        this.OnCRUDCoordinatorUpdateProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteprojectversion":
                        this.OnCRUDCoordinatorDeleteProjectVersionReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.getservicehosttypes":
                        this.OnGuestGetServiceHostTypesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addservicehosttype":
                        this.OnEffortlessProxyDataCoordinatorAddServiceHostTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getservicehosttypes":
                        this.OnEffortlessProxyDataCoordinatorGetServiceHostTypesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateservicehosttype":
                        this.OnEffortlessProxyDataCoordinatorUpdateServiceHostTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteservicehosttype":
                        this.OnEffortlessProxyDataCoordinatorDeleteServiceHostTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addservicehosttype":
                        this.OnAdminAddServiceHostTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getservicehosttypes":
                        this.OnAdminGetServiceHostTypesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateservicehosttype":
                        this.OnAdminUpdateServiceHostTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteservicehosttype":
                        this.OnAdminDeleteServiceHostTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addservicehosttype":
                        this.OnCRUDCoordinatorAddServiceHostTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getservicehosttypes":
                        this.OnCRUDCoordinatorGetServiceHostTypesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateservicehosttype":
                        this.OnCRUDCoordinatorUpdateServiceHostTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteservicehosttype":
                        this.OnCRUDCoordinatorDeleteServiceHostTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addremoteendpoint":
                        this.OnEffortlessProxyDataCoordinatorAddRemoteEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getremoteendpoints":
                        this.OnEffortlessProxyDataCoordinatorGetRemoteEndpointsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateremoteendpoint":
                        this.OnEffortlessProxyDataCoordinatorUpdateRemoteEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteremoteendpoint":
                        this.OnEffortlessProxyDataCoordinatorDeleteRemoteEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addremoteendpoint":
                        this.OnAdminAddRemoteEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getremoteendpoints":
                        this.OnAdminGetRemoteEndpointsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateremoteendpoint":
                        this.OnAdminUpdateRemoteEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteremoteendpoint":
                        this.OnAdminDeleteRemoteEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addremoteendpoint":
                        this.OnCRUDCoordinatorAddRemoteEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getremoteendpoints":
                        this.OnCRUDCoordinatorGetRemoteEndpointsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateremoteendpoint":
                        this.OnCRUDCoordinatorUpdateRemoteEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteremoteendpoint":
                        this.OnCRUDCoordinatorDeleteRemoteEndpointReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addeffortlessapiaccount":
                        this.OnEffortlessProxyDataCoordinatorAddEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.geteffortlessapiaccounts":
                        this.OnEffortlessProxyDataCoordinatorGetEffortlessAPIAccountsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateeffortlessapiaccount":
                        this.OnEffortlessProxyDataCoordinatorUpdateEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteeffortlessapiaccount":
                        this.OnEffortlessProxyDataCoordinatorDeleteEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addeffortlessapiaccount":
                        this.OnDeveloperAddEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.geteffortlessapiaccounts":
                        this.OnDeveloperGetEffortlessAPIAccountsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updateeffortlessapiaccount":
                        this.OnDeveloperUpdateEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deleteeffortlessapiaccount":
                        this.OnDeveloperDeleteEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addeffortlessapiaccount":
                        this.OnAdminAddEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.geteffortlessapiaccounts":
                        this.OnAdminGetEffortlessAPIAccountsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateeffortlessapiaccount":
                        this.OnAdminUpdateEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteeffortlessapiaccount":
                        this.OnAdminDeleteEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addeffortlessapiaccount":
                        this.OnCRUDCoordinatorAddEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.geteffortlessapiaccounts":
                        this.OnCRUDCoordinatorGetEffortlessAPIAccountsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateeffortlessapiaccount":
                        this.OnCRUDCoordinatorUpdateEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteeffortlessapiaccount":
                        this.OnCRUDCoordinatorDeleteEffortlessAPIAccountReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.getserviceproducts":
                        this.OnGuestGetServiceProductsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addserviceproduct":
                        this.OnEffortlessProxyDataCoordinatorAddServiceProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getserviceproducts":
                        this.OnEffortlessProxyDataCoordinatorGetServiceProductsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateserviceproduct":
                        this.OnEffortlessProxyDataCoordinatorUpdateServiceProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteserviceproduct":
                        this.OnEffortlessProxyDataCoordinatorDeleteServiceProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getserviceproducts":
                        this.OnDeveloperGetServiceProductsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addserviceproduct":
                        this.OnAdminAddServiceProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getserviceproducts":
                        this.OnAdminGetServiceProductsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateserviceproduct":
                        this.OnAdminUpdateServiceProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteserviceproduct":
                        this.OnAdminDeleteServiceProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addserviceproduct":
                        this.OnCRUDCoordinatorAddServiceProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getserviceproducts":
                        this.OnCRUDCoordinatorGetServiceProductsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateserviceproduct":
                        this.OnCRUDCoordinatorUpdateServiceProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteserviceproduct":
                        this.OnCRUDCoordinatorDeleteServiceProductReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addproxyrelativeurl":
                        this.OnEffortlessProxyDataCoordinatorAddProxyRelativeUrlReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getproxyrelativeurls":
                        this.OnEffortlessProxyDataCoordinatorGetProxyRelativeUrlsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateproxyrelativeurl":
                        this.OnEffortlessProxyDataCoordinatorUpdateProxyRelativeUrlReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteproxyrelativeurl":
                        this.OnEffortlessProxyDataCoordinatorDeleteProxyRelativeUrlReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addproxyrelativeurl":
                        this.OnAdminAddProxyRelativeUrlReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getproxyrelativeurls":
                        this.OnAdminGetProxyRelativeUrlsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateproxyrelativeurl":
                        this.OnAdminUpdateProxyRelativeUrlReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteproxyrelativeurl":
                        this.OnAdminDeleteProxyRelativeUrlReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addproxyrelativeurl":
                        this.OnCRUDCoordinatorAddProxyRelativeUrlReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getproxyrelativeurls":
                        this.OnCRUDCoordinatorGetProxyRelativeUrlsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateproxyrelativeurl":
                        this.OnCRUDCoordinatorUpdateProxyRelativeUrlReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteproxyrelativeurl":
                        this.OnCRUDCoordinatorDeleteProxyRelativeUrlReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addprojectrequestsummary":
                        this.OnEffortlessProxyDataCoordinatorAddProjectRequestSummaryReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getprojectrequestsummaries":
                        this.OnEffortlessProxyDataCoordinatorGetProjectRequestSummariesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateprojectrequestsummary":
                        this.OnEffortlessProxyDataCoordinatorUpdateProjectRequestSummaryReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteprojectrequestsummary":
                        this.OnEffortlessProxyDataCoordinatorDeleteProjectRequestSummaryReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addprojectrequestsummary":
                        this.OnAdminAddProjectRequestSummaryReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getprojectrequestsummaries":
                        this.OnAdminGetProjectRequestSummariesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateprojectrequestsummary":
                        this.OnAdminUpdateProjectRequestSummaryReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteprojectrequestsummary":
                        this.OnAdminDeleteProjectRequestSummaryReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addprojectrequestsummary":
                        this.OnCRUDCoordinatorAddProjectRequestSummaryReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getprojectrequestsummaries":
                        this.OnCRUDCoordinatorGetProjectRequestSummariesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateprojectrequestsummary":
                        this.OnCRUDCoordinatorUpdateProjectRequestSummaryReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteprojectrequestsummary":
                        this.OnCRUDCoordinatorDeleteProjectRequestSummaryReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.getserviceplans":
                        this.OnGuestGetServicePlansReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addserviceplan":
                        this.OnEffortlessProxyDataCoordinatorAddServicePlanReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getserviceplans":
                        this.OnEffortlessProxyDataCoordinatorGetServicePlansReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateserviceplan":
                        this.OnEffortlessProxyDataCoordinatorUpdateServicePlanReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteserviceplan":
                        this.OnEffortlessProxyDataCoordinatorDeleteServicePlanReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getserviceplans":
                        this.OnDeveloperGetServicePlansReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addserviceplan":
                        this.OnAdminAddServicePlanReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getserviceplans":
                        this.OnAdminGetServicePlansReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateserviceplan":
                        this.OnAdminUpdateServicePlanReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteserviceplan":
                        this.OnAdminDeleteServicePlanReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addserviceplan":
                        this.OnCRUDCoordinatorAddServicePlanReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getserviceplans":
                        this.OnCRUDCoordinatorGetServicePlansReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateserviceplan":
                        this.OnCRUDCoordinatorUpdateServicePlanReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteserviceplan":
                        this.OnCRUDCoordinatorDeleteServicePlanReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addprojecticon":
                        this.OnEffortlessProxyDataCoordinatorAddProjectIconReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getprojecticons":
                        this.OnEffortlessProxyDataCoordinatorGetProjectIconsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateprojecticon":
                        this.OnEffortlessProxyDataCoordinatorUpdateProjectIconReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteprojecticon":
                        this.OnEffortlessProxyDataCoordinatorDeleteProjectIconReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addprojecticon":
                        this.OnAdminAddProjectIconReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getprojecticons":
                        this.OnAdminGetProjectIconsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateprojecticon":
                        this.OnAdminUpdateProjectIconReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteprojecticon":
                        this.OnAdminDeleteProjectIconReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addprojecticon":
                        this.OnCRUDCoordinatorAddProjectIconReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getprojecticons":
                        this.OnCRUDCoordinatorGetProjectIconsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateprojecticon":
                        this.OnCRUDCoordinatorUpdateProjectIconReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteprojecticon":
                        this.OnCRUDCoordinatorDeleteProjectIconReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addtablecolumn":
                        this.OnEffortlessProxyDataCoordinatorAddTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.gettablecolumns":
                        this.OnEffortlessProxyDataCoordinatorGetTableColumnsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updatetablecolumn":
                        this.OnEffortlessProxyDataCoordinatorUpdateTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deletetablecolumn":
                        this.OnEffortlessProxyDataCoordinatorDeleteTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addtablecolumn":
                        this.OnDeveloperAddTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.gettablecolumns":
                        this.OnDeveloperGetTableColumnsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updatetablecolumn":
                        this.OnDeveloperUpdateTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deletetablecolumn":
                        this.OnDeveloperDeleteTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addtablecolumn":
                        this.OnAdminAddTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.gettablecolumns":
                        this.OnAdminGetTableColumnsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatetablecolumn":
                        this.OnAdminUpdateTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletetablecolumn":
                        this.OnAdminDeleteTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addtablecolumn":
                        this.OnCRUDCoordinatorAddTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.gettablecolumns":
                        this.OnCRUDCoordinatorGetTableColumnsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updatetablecolumn":
                        this.OnCRUDCoordinatorUpdateTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deletetablecolumn":
                        this.OnCRUDCoordinatorDeleteTableColumnReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addtablerolewhere":
                        this.OnEffortlessProxyDataCoordinatorAddTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.gettablerolewheres":
                        this.OnEffortlessProxyDataCoordinatorGetTableRoleWheresReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updatetablerolewhere":
                        this.OnEffortlessProxyDataCoordinatorUpdateTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deletetablerolewhere":
                        this.OnEffortlessProxyDataCoordinatorDeleteTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addtablerolewhere":
                        this.OnDeveloperAddTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.gettablerolewheres":
                        this.OnDeveloperGetTableRoleWheresReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updatetablerolewhere":
                        this.OnDeveloperUpdateTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deletetablerolewhere":
                        this.OnDeveloperDeleteTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addtablerolewhere":
                        this.OnAdminAddTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.gettablerolewheres":
                        this.OnAdminGetTableRoleWheresReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatetablerolewhere":
                        this.OnAdminUpdateTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletetablerolewhere":
                        this.OnAdminDeleteTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addtablerolewhere":
                        this.OnCRUDCoordinatorAddTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.gettablerolewheres":
                        this.OnCRUDCoordinatorGetTableRoleWheresReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updatetablerolewhere":
                        this.OnCRUDCoordinatorUpdateTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deletetablerolewhere":
                        this.OnCRUDCoordinatorDeleteTableRoleWhereReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addeffortlessapiproject":
                        this.OnEffortlessProxyDataCoordinatorAddEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.geteffortlessapiprojects":
                        this.OnEffortlessProxyDataCoordinatorGetEffortlessAPIProjectsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateeffortlessapiproject":
                        this.OnEffortlessProxyDataCoordinatorUpdateEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteeffortlessapiproject":
                        this.OnEffortlessProxyDataCoordinatorDeleteEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addeffortlessapiproject":
                        this.OnDeveloperAddEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.geteffortlessapiprojects":
                        this.OnDeveloperGetEffortlessAPIProjectsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updateeffortlessapiproject":
                        this.OnDeveloperUpdateEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deleteeffortlessapiproject":
                        this.OnDeveloperDeleteEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addeffortlessapiproject":
                        this.OnAdminAddEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.geteffortlessapiprojects":
                        this.OnAdminGetEffortlessAPIProjectsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateeffortlessapiproject":
                        this.OnAdminUpdateEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteeffortlessapiproject":
                        this.OnAdminDeleteEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addeffortlessapiproject":
                        this.OnCRUDCoordinatorAddEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.geteffortlessapiprojects":
                        this.OnCRUDCoordinatorGetEffortlessAPIProjectsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateeffortlessapiproject":
                        this.OnCRUDCoordinatorUpdateEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteeffortlessapiproject":
                        this.OnCRUDCoordinatorDeleteEffortlessAPIProjectReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addcolumnrolecrud":
                        this.OnEffortlessProxyDataCoordinatorAddColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getcolumnrolecruds":
                        this.OnEffortlessProxyDataCoordinatorGetColumnRoleCRUDsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updatecolumnrolecrud":
                        this.OnEffortlessProxyDataCoordinatorUpdateColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deletecolumnrolecrud":
                        this.OnEffortlessProxyDataCoordinatorDeleteColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.addcolumnrolecrud":
                        this.OnDeveloperAddColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.getcolumnrolecruds":
                        this.OnDeveloperGetColumnRoleCRUDsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.updatecolumnrolecrud":
                        this.OnDeveloperUpdateColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.developer.deletecolumnrolecrud":
                        this.OnDeveloperDeleteColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addcolumnrolecrud":
                        this.OnAdminAddColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getcolumnrolecruds":
                        this.OnAdminGetColumnRoleCRUDsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatecolumnrolecrud":
                        this.OnAdminUpdateColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletecolumnrolecrud":
                        this.OnAdminDeleteColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addcolumnrolecrud":
                        this.OnCRUDCoordinatorAddColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getcolumnrolecruds":
                        this.OnCRUDCoordinatorGetColumnRoleCRUDsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updatecolumnrolecrud":
                        this.OnCRUDCoordinatorUpdateColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deletecolumnrolecrud":
                        this.OnCRUDCoordinatorDeleteColumnRoleCRUDReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.getsdklanguages":
                        this.OnGuestGetSDKLanguagesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addsdklanguage":
                        this.OnEffortlessProxyDataCoordinatorAddSDKLanguageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getsdklanguages":
                        this.OnEffortlessProxyDataCoordinatorGetSDKLanguagesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updatesdklanguage":
                        this.OnEffortlessProxyDataCoordinatorUpdateSDKLanguageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deletesdklanguage":
                        this.OnEffortlessProxyDataCoordinatorDeleteSDKLanguageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addsdklanguage":
                        this.OnAdminAddSDKLanguageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getsdklanguages":
                        this.OnAdminGetSDKLanguagesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatesdklanguage":
                        this.OnAdminUpdateSDKLanguageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletesdklanguage":
                        this.OnAdminDeleteSDKLanguageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addsdklanguage":
                        this.OnCRUDCoordinatorAddSDKLanguageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getsdklanguages":
                        this.OnCRUDCoordinatorGetSDKLanguagesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updatesdklanguage":
                        this.OnCRUDCoordinatorUpdateSDKLanguageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deletesdklanguage":
                        this.OnCRUDCoordinatorDeleteSDKLanguageReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addservicekey":
                        this.OnEffortlessProxyDataCoordinatorAddServiceKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getservicekeys":
                        this.OnEffortlessProxyDataCoordinatorGetServiceKeysReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updateservicekey":
                        this.OnEffortlessProxyDataCoordinatorUpdateServiceKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deleteservicekey":
                        this.OnEffortlessProxyDataCoordinatorDeleteServiceKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addservicekey":
                        this.OnAdminAddServiceKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getservicekeys":
                        this.OnAdminGetServiceKeysReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateservicekey":
                        this.OnAdminUpdateServiceKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteservicekey":
                        this.OnAdminDeleteServiceKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addservicekey":
                        this.OnCRUDCoordinatorAddServiceKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getservicekeys":
                        this.OnCRUDCoordinatorGetServiceKeysReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updateservicekey":
                        this.OnCRUDCoordinatorUpdateServiceKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deleteservicekey":
                        this.OnCRUDCoordinatorDeleteServiceKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.addcustomertype":
                        this.OnEffortlessProxyDataCoordinatorAddCustomerTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.getcustomertypes":
                        this.OnEffortlessProxyDataCoordinatorGetCustomerTypesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.updatecustomertype":
                        this.OnEffortlessProxyDataCoordinatorUpdateCustomerTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.effortlessproxydatacoordinator.deletecustomertype":
                        this.OnEffortlessProxyDataCoordinatorDeleteCustomerTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addcustomertype":
                        this.OnAdminAddCustomerTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getcustomertypes":
                        this.OnAdminGetCustomerTypesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatecustomertype":
                        this.OnAdminUpdateCustomerTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletecustomertype":
                        this.OnAdminDeleteCustomerTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.addcustomertype":
                        this.OnCRUDCoordinatorAddCustomerTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.getcustomertypes":
                        this.OnCRUDCoordinatorGetCustomerTypesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.updatecustomertype":
                        this.OnCRUDCoordinatorUpdateCustomerTypeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.crudcoordinator.deletecustomertype":
                        this.OnCRUDCoordinatorDeleteCustomerTypeReceived(payload, bdea);
                        break;
                    
                }

            }
            catch (Exception ex)
            {
                payload.ErrorMessage = ex.Message;
            }
            var reply = payload.ReplyPayload is null ? payload  : payload.ReplyPayload;
            reply.IsHandled = payload.IsHandled;
            if (reply.AccessToken == originalAccessToken) reply.AccessToken = null;            
            this.Reply(reply, bdea.BasicProperties);
        }

        
        /// <summary>
        /// Responds to: RequestToken from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestRequestTokenReceived;
        protected virtual void OnGuestRequestTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestRequestTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestRequestTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ValidateTemporaryAccessToken from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestValidateTemporaryAccessTokenReceived;
        protected virtual void OnGuestValidateTemporaryAccessTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestValidateTemporaryAccessTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestValidateTemporaryAccessTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: WhoAmI from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestWhoAmIReceived;
        protected virtual void OnGuestWhoAmIReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestWhoAmIReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestWhoAmIReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: WhoAreYou from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestWhoAreYouReceived;
        protected virtual void OnGuestWhoAreYouReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestWhoAreYouReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestWhoAreYouReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: StoreTempFile from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestStoreTempFileReceived;
        protected virtual void OnGuestStoreTempFileReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestStoreTempFileReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestStoreTempFileReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ResetRabbitSassyMQConfiguration from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorResetRabbitSassyMQConfigurationReceived;
        protected virtual void OnCRUDCoordinatorResetRabbitSassyMQConfigurationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorResetRabbitSassyMQConfigurationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorResetRabbitSassyMQConfigurationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ResetJWTSecretKey from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorResetJWTSecretKeyReceived;
        protected virtual void OnCRUDCoordinatorResetJWTSecretKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorResetJWTSecretKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorResetJWTSecretKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: CancelBuild from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperCancelBuildReceived;
        protected virtual void OnDeveloperCancelBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperCancelBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperCancelBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEndpointDetails from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetEndpointDetailsReceived;
        protected virtual void OnDeveloperGetEndpointDetailsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetEndpointDetailsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetEndpointDetailsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: StopEndpoint from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperStopEndpointReceived;
        protected virtual void OnDeveloperStopEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperStopEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperStopEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ProxyStatusReport from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperProxyStatusReportReceived;
        protected virtual void OnDeveloperProxyStatusReportReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperProxyStatusReportReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperProxyStatusReportReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: SynchronizeSchema from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperSynchronizeSchemaReceived;
        protected virtual void OnDeveloperSynchronizeSchemaReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperSynchronizeSchemaReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperSynchronizeSchemaReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: MoveEndpoint from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperMoveEndpointReceived;
        protected virtual void OnDeveloperMoveEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperMoveEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperMoveEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: Publish from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperPublishReceived;
        protected virtual void OnDeveloperPublishReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperPublishReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperPublishReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: StartEndpoint from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperStartEndpointReceived;
        protected virtual void OnDeveloperStartEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperStartEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperStartEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: SynchronizeWithAirtable from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperSynchronizeWithAirtableReceived;
        protected virtual void OnDeveloperSynchronizeWithAirtableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperSynchronizeWithAirtableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperSynchronizeWithAirtableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DoSomethingElse from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDoSomethingElseReceived;
        protected virtual void OnDeveloperDoSomethingElseReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDoSomethingElseReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDoSomethingElseReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPlanProducts from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetPlanProductsReceived;
        protected virtual void OnGuestGetPlanProductsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetPlanProductsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetPlanProductsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPlanProduct from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddPlanProductReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddPlanProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddPlanProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddPlanProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPlanProducts from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetPlanProductsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetPlanProductsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetPlanProductsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetPlanProductsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePlanProduct from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdatePlanProductReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdatePlanProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdatePlanProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdatePlanProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePlanProduct from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeletePlanProductReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeletePlanProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeletePlanProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeletePlanProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPlanProducts from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetPlanProductsReceived;
        protected virtual void OnDeveloperGetPlanProductsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetPlanProductsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetPlanProductsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPlanProduct from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddPlanProductReceived;
        protected virtual void OnAdminAddPlanProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddPlanProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddPlanProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPlanProducts from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetPlanProductsReceived;
        protected virtual void OnAdminGetPlanProductsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetPlanProductsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetPlanProductsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePlanProduct from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdatePlanProductReceived;
        protected virtual void OnAdminUpdatePlanProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdatePlanProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdatePlanProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePlanProduct from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeletePlanProductReceived;
        protected virtual void OnAdminDeletePlanProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeletePlanProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeletePlanProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPlanProduct from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddPlanProductReceived;
        protected virtual void OnCRUDCoordinatorAddPlanProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddPlanProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddPlanProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPlanProducts from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetPlanProductsReceived;
        protected virtual void OnCRUDCoordinatorGetPlanProductsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetPlanProductsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetPlanProductsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePlanProduct from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdatePlanProductReceived;
        protected virtual void OnCRUDCoordinatorUpdatePlanProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdatePlanProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdatePlanProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePlanProduct from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeletePlanProductReceived;
        protected virtual void OnCRUDCoordinatorDeletePlanProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeletePlanProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeletePlanProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectTable from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProjectTableReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectTables from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProjectTablesReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProjectTablesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProjectTablesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProjectTablesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectTable from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProjectTableReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectTable from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProjectTableReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectTable from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddProjectTableReceived;
        protected virtual void OnDeveloperAddProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectTables from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetProjectTablesReceived;
        protected virtual void OnDeveloperGetProjectTablesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetProjectTablesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetProjectTablesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectTable from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateProjectTableReceived;
        protected virtual void OnDeveloperUpdateProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectTable from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteProjectTableReceived;
        protected virtual void OnDeveloperDeleteProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectTable from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProjectTableReceived;
        protected virtual void OnAdminAddProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectTables from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProjectTablesReceived;
        protected virtual void OnAdminGetProjectTablesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProjectTablesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProjectTablesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectTable from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProjectTableReceived;
        protected virtual void OnAdminUpdateProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectTable from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProjectTableReceived;
        protected virtual void OnAdminDeleteProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectTable from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProjectTableReceived;
        protected virtual void OnCRUDCoordinatorAddProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectTables from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProjectTablesReceived;
        protected virtual void OnCRUDCoordinatorGetProjectTablesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProjectTablesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProjectTablesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectTable from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProjectTableReceived;
        protected virtual void OnCRUDCoordinatorUpdateProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectTable from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProjectTableReceived;
        protected virtual void OnCRUDCoordinatorDeleteProjectTableReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProjectTableReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProjectTableReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceHostSize from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddServiceHostSizeReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddServiceHostSizeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddServiceHostSizeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddServiceHostSizeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostSizes from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetServiceHostSizesReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetServiceHostSizesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetServiceHostSizesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetServiceHostSizesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceHostSize from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateServiceHostSizeReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateServiceHostSizeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateServiceHostSizeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateServiceHostSizeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceHostSize from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteServiceHostSizeReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteServiceHostSizeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteServiceHostSizeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteServiceHostSizeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceHostSize from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddServiceHostSizeReceived;
        protected virtual void OnAdminAddServiceHostSizeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddServiceHostSizeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddServiceHostSizeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostSizes from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetServiceHostSizesReceived;
        protected virtual void OnAdminGetServiceHostSizesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetServiceHostSizesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetServiceHostSizesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceHostSize from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateServiceHostSizeReceived;
        protected virtual void OnAdminUpdateServiceHostSizeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateServiceHostSizeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateServiceHostSizeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceHostSize from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteServiceHostSizeReceived;
        protected virtual void OnAdminDeleteServiceHostSizeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteServiceHostSizeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteServiceHostSizeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceHostSize from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddServiceHostSizeReceived;
        protected virtual void OnCRUDCoordinatorAddServiceHostSizeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddServiceHostSizeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddServiceHostSizeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostSizes from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetServiceHostSizesReceived;
        protected virtual void OnCRUDCoordinatorGetServiceHostSizesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetServiceHostSizesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetServiceHostSizesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceHostSize from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateServiceHostSizeReceived;
        protected virtual void OnCRUDCoordinatorUpdateServiceHostSizeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateServiceHostSizeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateServiceHostSizeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceHostSize from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteServiceHostSizeReceived;
        protected virtual void OnCRUDCoordinatorDeleteServiceHostSizeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteServiceHostSizeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteServiceHostSizeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddColumnValue from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddColumnValueReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddColumnValueReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddColumnValueReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddColumnValueReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetColumnValues from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetColumnValuesReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetColumnValuesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetColumnValuesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetColumnValuesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateColumnValue from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateColumnValueReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateColumnValueReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateColumnValueReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateColumnValueReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteColumnValue from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteColumnValueReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteColumnValueReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteColumnValueReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteColumnValueReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddColumnValue from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddColumnValueReceived;
        protected virtual void OnAdminAddColumnValueReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddColumnValueReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddColumnValueReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetColumnValues from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetColumnValuesReceived;
        protected virtual void OnAdminGetColumnValuesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetColumnValuesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetColumnValuesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateColumnValue from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateColumnValueReceived;
        protected virtual void OnAdminUpdateColumnValueReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateColumnValueReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateColumnValueReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteColumnValue from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteColumnValueReceived;
        protected virtual void OnAdminDeleteColumnValueReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteColumnValueReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteColumnValueReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddColumnValue from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddColumnValueReceived;
        protected virtual void OnCRUDCoordinatorAddColumnValueReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddColumnValueReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddColumnValueReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetColumnValues from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetColumnValuesReceived;
        protected virtual void OnCRUDCoordinatorGetColumnValuesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetColumnValuesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetColumnValuesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateColumnValue from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateColumnValueReceived;
        protected virtual void OnCRUDCoordinatorUpdateColumnValueReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateColumnValueReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateColumnValueReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteColumnValue from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteColumnValueReceived;
        protected virtual void OnCRUDCoordinatorDeleteColumnValueReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteColumnValueReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteColumnValueReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPortfolioItemRETIRED from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddPortfolioItemRETIREDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddPortfolioItemRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddPortfolioItemRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddPortfolioItemRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPortfolioItemsRETIRED from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetPortfolioItemsRETIREDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetPortfolioItemsRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetPortfolioItemsRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetPortfolioItemsRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePortfolioItemRETIRED from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdatePortfolioItemRETIREDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdatePortfolioItemRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdatePortfolioItemRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdatePortfolioItemRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePortfolioItemRETIRED from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeletePortfolioItemRETIREDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeletePortfolioItemRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeletePortfolioItemRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeletePortfolioItemRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPortfolioItemRETIRED from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddPortfolioItemRETIREDReceived;
        protected virtual void OnAdminAddPortfolioItemRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddPortfolioItemRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddPortfolioItemRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPortfolioItemsRETIRED from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetPortfolioItemsRETIREDReceived;
        protected virtual void OnAdminGetPortfolioItemsRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetPortfolioItemsRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetPortfolioItemsRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePortfolioItemRETIRED from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdatePortfolioItemRETIREDReceived;
        protected virtual void OnAdminUpdatePortfolioItemRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdatePortfolioItemRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdatePortfolioItemRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePortfolioItemRETIRED from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeletePortfolioItemRETIREDReceived;
        protected virtual void OnAdminDeletePortfolioItemRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeletePortfolioItemRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeletePortfolioItemRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPortfolioItemRETIRED from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddPortfolioItemRETIREDReceived;
        protected virtual void OnCRUDCoordinatorAddPortfolioItemRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddPortfolioItemRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddPortfolioItemRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPortfolioItemsRETIRED from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetPortfolioItemsRETIREDReceived;
        protected virtual void OnCRUDCoordinatorGetPortfolioItemsRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetPortfolioItemsRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetPortfolioItemsRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePortfolioItemRETIRED from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdatePortfolioItemRETIREDReceived;
        protected virtual void OnCRUDCoordinatorUpdatePortfolioItemRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdatePortfolioItemRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdatePortfolioItemRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePortfolioItemRETIRED from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeletePortfolioItemRETIREDReceived;
        protected virtual void OnCRUDCoordinatorDeletePortfolioItemRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeletePortfolioItemRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeletePortfolioItemRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectStage from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProjectStageReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectStages from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProjectStagesReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProjectStagesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProjectStagesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProjectStagesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectStage from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProjectStageReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectStage from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProjectStageReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectStage from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddProjectStageReceived;
        protected virtual void OnDeveloperAddProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectStages from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetProjectStagesReceived;
        protected virtual void OnDeveloperGetProjectStagesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetProjectStagesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetProjectStagesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectStage from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateProjectStageReceived;
        protected virtual void OnDeveloperUpdateProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectStage from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteProjectStageReceived;
        protected virtual void OnDeveloperDeleteProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectStage from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProjectStageReceived;
        protected virtual void OnAdminAddProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectStages from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProjectStagesReceived;
        protected virtual void OnAdminGetProjectStagesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProjectStagesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProjectStagesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectStage from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProjectStageReceived;
        protected virtual void OnAdminUpdateProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectStage from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProjectStageReceived;
        protected virtual void OnAdminDeleteProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectStage from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProjectStageReceived;
        protected virtual void OnCRUDCoordinatorAddProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectStages from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProjectStagesReceived;
        protected virtual void OnCRUDCoordinatorGetProjectStagesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProjectStagesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProjectStagesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectStage from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProjectStageReceived;
        protected virtual void OnCRUDCoordinatorUpdateProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectStage from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProjectStageReceived;
        protected virtual void OnCRUDCoordinatorDeleteProjectStageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProjectStageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProjectStageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectVersionBuild from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProjectVersionBuildReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectVersionBuilds from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProjectVersionBuildsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProjectVersionBuildsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProjectVersionBuildsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProjectVersionBuildsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectVersionBuild from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProjectVersionBuildReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectVersionBuild from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProjectVersionBuildReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectVersionBuild from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddProjectVersionBuildReceived;
        protected virtual void OnDeveloperAddProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectVersionBuilds from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetProjectVersionBuildsReceived;
        protected virtual void OnDeveloperGetProjectVersionBuildsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetProjectVersionBuildsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetProjectVersionBuildsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectVersionBuild from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateProjectVersionBuildReceived;
        protected virtual void OnDeveloperUpdateProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectVersionBuild from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProjectVersionBuildReceived;
        protected virtual void OnAdminAddProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectVersionBuilds from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProjectVersionBuildsReceived;
        protected virtual void OnAdminGetProjectVersionBuildsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProjectVersionBuildsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProjectVersionBuildsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectVersionBuild from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProjectVersionBuildReceived;
        protected virtual void OnAdminUpdateProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectVersionBuild from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProjectVersionBuildReceived;
        protected virtual void OnAdminDeleteProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectVersionBuild from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProjectVersionBuildReceived;
        protected virtual void OnCRUDCoordinatorAddProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectVersionBuilds from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProjectVersionBuildsReceived;
        protected virtual void OnCRUDCoordinatorGetProjectVersionBuildsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProjectVersionBuildsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProjectVersionBuildsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectVersionBuild from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProjectVersionBuildReceived;
        protected virtual void OnCRUDCoordinatorUpdateProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectVersionBuild from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProjectVersionBuildReceived;
        protected virtual void OnCRUDCoordinatorDeleteProjectVersionBuildReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProjectVersionBuildReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProjectVersionBuildReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectRole from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProjectRoleReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectRoles from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProjectRolesReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProjectRolesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProjectRolesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProjectRolesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectRole from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProjectRoleReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectRole from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProjectRoleReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectRole from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddProjectRoleReceived;
        protected virtual void OnDeveloperAddProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectRoles from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetProjectRolesReceived;
        protected virtual void OnDeveloperGetProjectRolesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetProjectRolesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetProjectRolesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectRole from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateProjectRoleReceived;
        protected virtual void OnDeveloperUpdateProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectRole from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteProjectRoleReceived;
        protected virtual void OnDeveloperDeleteProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectRole from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProjectRoleReceived;
        protected virtual void OnAdminAddProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectRoles from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProjectRolesReceived;
        protected virtual void OnAdminGetProjectRolesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProjectRolesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProjectRolesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectRole from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProjectRoleReceived;
        protected virtual void OnAdminUpdateProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectRole from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProjectRoleReceived;
        protected virtual void OnAdminDeleteProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectRole from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProjectRoleReceived;
        protected virtual void OnCRUDCoordinatorAddProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectRoles from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProjectRolesReceived;
        protected virtual void OnCRUDCoordinatorGetProjectRolesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProjectRolesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProjectRolesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectRole from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProjectRoleReceived;
        protected virtual void OnCRUDCoordinatorUpdateProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectRole from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProjectRoleReceived;
        protected virtual void OnCRUDCoordinatorDeleteProjectRoleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProjectRoleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProjectRoleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostEndpoints from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetServiceHostEndpointsReceived;
        protected virtual void OnGuestGetServiceHostEndpointsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetServiceHostEndpointsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetServiceHostEndpointsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceHostEndpoint from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddServiceHostEndpointReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddServiceHostEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddServiceHostEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddServiceHostEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostEndpoints from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetServiceHostEndpointsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetServiceHostEndpointsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetServiceHostEndpointsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetServiceHostEndpointsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceHostEndpoint from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateServiceHostEndpointReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateServiceHostEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateServiceHostEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateServiceHostEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceHostEndpoint from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteServiceHostEndpointReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteServiceHostEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteServiceHostEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteServiceHostEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostEndpoints from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetServiceHostEndpointsReceived;
        protected virtual void OnDeveloperGetServiceHostEndpointsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetServiceHostEndpointsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetServiceHostEndpointsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceHostEndpoint from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddServiceHostEndpointReceived;
        protected virtual void OnAdminAddServiceHostEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddServiceHostEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddServiceHostEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostEndpoints from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetServiceHostEndpointsReceived;
        protected virtual void OnAdminGetServiceHostEndpointsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetServiceHostEndpointsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetServiceHostEndpointsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceHostEndpoint from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateServiceHostEndpointReceived;
        protected virtual void OnAdminUpdateServiceHostEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateServiceHostEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateServiceHostEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceHostEndpoint from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteServiceHostEndpointReceived;
        protected virtual void OnAdminDeleteServiceHostEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteServiceHostEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteServiceHostEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceHostEndpoint from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddServiceHostEndpointReceived;
        protected virtual void OnCRUDCoordinatorAddServiceHostEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddServiceHostEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddServiceHostEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostEndpoints from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetServiceHostEndpointsReceived;
        protected virtual void OnCRUDCoordinatorGetServiceHostEndpointsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetServiceHostEndpointsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetServiceHostEndpointsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceHostEndpoint from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateServiceHostEndpointReceived;
        protected virtual void OnCRUDCoordinatorUpdateServiceHostEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateServiceHostEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateServiceHostEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceHostEndpoint from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteServiceHostEndpointReceived;
        protected virtual void OnCRUDCoordinatorDeleteServiceHostEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteServiceHostEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteServiceHostEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIServices from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetEffortlessAPIServicesReceived;
        protected virtual void OnGuestGetEffortlessAPIServicesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetEffortlessAPIServicesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetEffortlessAPIServicesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIService from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddEffortlessAPIServiceReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddEffortlessAPIServiceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddEffortlessAPIServiceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddEffortlessAPIServiceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIServices from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetEffortlessAPIServicesReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetEffortlessAPIServicesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetEffortlessAPIServicesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetEffortlessAPIServicesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIService from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateEffortlessAPIServiceReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateEffortlessAPIServiceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateEffortlessAPIServiceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateEffortlessAPIServiceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIService from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteEffortlessAPIServiceReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteEffortlessAPIServiceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteEffortlessAPIServiceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteEffortlessAPIServiceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIServices from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetEffortlessAPIServicesReceived;
        protected virtual void OnDeveloperGetEffortlessAPIServicesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetEffortlessAPIServicesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetEffortlessAPIServicesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIService from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddEffortlessAPIServiceReceived;
        protected virtual void OnAdminAddEffortlessAPIServiceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddEffortlessAPIServiceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddEffortlessAPIServiceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIServices from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetEffortlessAPIServicesReceived;
        protected virtual void OnAdminGetEffortlessAPIServicesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetEffortlessAPIServicesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetEffortlessAPIServicesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIService from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateEffortlessAPIServiceReceived;
        protected virtual void OnAdminUpdateEffortlessAPIServiceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateEffortlessAPIServiceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateEffortlessAPIServiceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIService from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteEffortlessAPIServiceReceived;
        protected virtual void OnAdminDeleteEffortlessAPIServiceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteEffortlessAPIServiceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteEffortlessAPIServiceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIService from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddEffortlessAPIServiceReceived;
        protected virtual void OnCRUDCoordinatorAddEffortlessAPIServiceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddEffortlessAPIServiceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddEffortlessAPIServiceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIServices from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetEffortlessAPIServicesReceived;
        protected virtual void OnCRUDCoordinatorGetEffortlessAPIServicesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetEffortlessAPIServicesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetEffortlessAPIServicesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIService from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateEffortlessAPIServiceReceived;
        protected virtual void OnCRUDCoordinatorUpdateEffortlessAPIServiceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateEffortlessAPIServiceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateEffortlessAPIServiceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIService from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteEffortlessAPIServiceReceived;
        protected virtual void OnCRUDCoordinatorDeleteEffortlessAPIServiceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteEffortlessAPIServiceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteEffortlessAPIServiceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectConnection from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProjectConnectionReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectConnections from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProjectConnectionsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProjectConnectionsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProjectConnectionsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProjectConnectionsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectConnection from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProjectConnectionReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectConnection from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProjectConnectionReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectConnection from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddProjectConnectionReceived;
        protected virtual void OnDeveloperAddProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectConnections from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetProjectConnectionsReceived;
        protected virtual void OnDeveloperGetProjectConnectionsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetProjectConnectionsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetProjectConnectionsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectConnection from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateProjectConnectionReceived;
        protected virtual void OnDeveloperUpdateProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectConnection from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteProjectConnectionReceived;
        protected virtual void OnDeveloperDeleteProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectConnection from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProjectConnectionReceived;
        protected virtual void OnAdminAddProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectConnections from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProjectConnectionsReceived;
        protected virtual void OnAdminGetProjectConnectionsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProjectConnectionsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProjectConnectionsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectConnection from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProjectConnectionReceived;
        protected virtual void OnAdminUpdateProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectConnection from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProjectConnectionReceived;
        protected virtual void OnAdminDeleteProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectConnection from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProjectConnectionReceived;
        protected virtual void OnCRUDCoordinatorAddProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectConnections from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProjectConnectionsReceived;
        protected virtual void OnCRUDCoordinatorGetProjectConnectionsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProjectConnectionsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProjectConnectionsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectConnection from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProjectConnectionReceived;
        protected virtual void OnCRUDCoordinatorUpdateProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectConnection from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProjectConnectionReceived;
        protected virtual void OnCRUDCoordinatorDeleteProjectConnectionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProjectConnectionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProjectConnectionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectLexiconTerm from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProjectLexiconTermReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectLexiconTerms from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProjectLexiconTermsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProjectLexiconTermsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProjectLexiconTermsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProjectLexiconTermsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectLexiconTerm from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProjectLexiconTermReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectLexiconTerm from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProjectLexiconTermReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectLexiconTerm from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddProjectLexiconTermReceived;
        protected virtual void OnDeveloperAddProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectLexiconTerms from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetProjectLexiconTermsReceived;
        protected virtual void OnDeveloperGetProjectLexiconTermsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetProjectLexiconTermsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetProjectLexiconTermsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectLexiconTerm from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateProjectLexiconTermReceived;
        protected virtual void OnDeveloperUpdateProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectLexiconTerm from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteProjectLexiconTermReceived;
        protected virtual void OnDeveloperDeleteProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectLexiconTerm from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProjectLexiconTermReceived;
        protected virtual void OnAdminAddProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectLexiconTerms from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProjectLexiconTermsReceived;
        protected virtual void OnAdminGetProjectLexiconTermsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProjectLexiconTermsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProjectLexiconTermsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectLexiconTerm from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProjectLexiconTermReceived;
        protected virtual void OnAdminUpdateProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectLexiconTerm from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProjectLexiconTermReceived;
        protected virtual void OnAdminDeleteProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectLexiconTerm from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProjectLexiconTermReceived;
        protected virtual void OnCRUDCoordinatorAddProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectLexiconTerms from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProjectLexiconTermsReceived;
        protected virtual void OnCRUDCoordinatorGetProjectLexiconTermsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProjectLexiconTermsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProjectLexiconTermsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectLexiconTerm from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProjectLexiconTermReceived;
        protected virtual void OnCRUDCoordinatorUpdateProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectLexiconTerm from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProjectLexiconTermReceived;
        protected virtual void OnCRUDCoordinatorDeleteProjectLexiconTermReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProjectLexiconTermReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProjectLexiconTermReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPortfolioRETIRED from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddPortfolioRETIREDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddPortfolioRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddPortfolioRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddPortfolioRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPortfoliosRETIRED from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetPortfoliosRETIREDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetPortfoliosRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetPortfoliosRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetPortfoliosRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePortfolioRETIRED from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdatePortfolioRETIREDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdatePortfolioRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdatePortfolioRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdatePortfolioRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePortfolioRETIRED from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeletePortfolioRETIREDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeletePortfolioRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeletePortfolioRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeletePortfolioRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPortfolioRETIRED from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddPortfolioRETIREDReceived;
        protected virtual void OnAdminAddPortfolioRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddPortfolioRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddPortfolioRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPortfoliosRETIRED from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetPortfoliosRETIREDReceived;
        protected virtual void OnAdminGetPortfoliosRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetPortfoliosRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetPortfoliosRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePortfolioRETIRED from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdatePortfolioRETIREDReceived;
        protected virtual void OnAdminUpdatePortfolioRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdatePortfolioRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdatePortfolioRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePortfolioRETIRED from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeletePortfolioRETIREDReceived;
        protected virtual void OnAdminDeletePortfolioRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeletePortfolioRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeletePortfolioRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPortfolioRETIRED from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddPortfolioRETIREDReceived;
        protected virtual void OnCRUDCoordinatorAddPortfolioRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddPortfolioRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddPortfolioRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPortfoliosRETIRED from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetPortfoliosRETIREDReceived;
        protected virtual void OnCRUDCoordinatorGetPortfoliosRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetPortfoliosRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetPortfoliosRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePortfolioRETIRED from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdatePortfolioRETIREDReceived;
        protected virtual void OnCRUDCoordinatorUpdatePortfolioRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdatePortfolioRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdatePortfolioRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePortfolioRETIRED from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeletePortfolioRETIREDReceived;
        protected virtual void OnCRUDCoordinatorDeletePortfolioRETIREDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeletePortfolioRETIREDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeletePortfolioRETIREDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectEmail from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProjectEmailReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectEmails from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProjectEmailsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProjectEmailsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProjectEmailsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProjectEmailsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectEmail from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProjectEmailReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectEmail from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProjectEmailReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectEmail from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddProjectEmailReceived;
        protected virtual void OnDeveloperAddProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectEmails from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetProjectEmailsReceived;
        protected virtual void OnDeveloperGetProjectEmailsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetProjectEmailsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetProjectEmailsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectEmail from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateProjectEmailReceived;
        protected virtual void OnDeveloperUpdateProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectEmail from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteProjectEmailReceived;
        protected virtual void OnDeveloperDeleteProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectEmail from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProjectEmailReceived;
        protected virtual void OnAdminAddProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectEmails from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProjectEmailsReceived;
        protected virtual void OnAdminGetProjectEmailsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProjectEmailsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProjectEmailsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectEmail from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProjectEmailReceived;
        protected virtual void OnAdminUpdateProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectEmail from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProjectEmailReceived;
        protected virtual void OnAdminDeleteProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectEmail from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProjectEmailReceived;
        protected virtual void OnCRUDCoordinatorAddProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectEmails from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProjectEmailsReceived;
        protected virtual void OnCRUDCoordinatorGetProjectEmailsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProjectEmailsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProjectEmailsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectEmail from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProjectEmailReceived;
        protected virtual void OnCRUDCoordinatorUpdateProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectEmail from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProjectEmailReceived;
        protected virtual void OnCRUDCoordinatorDeleteProjectEmailReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProjectEmailReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProjectEmailReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectVersion from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProjectVersionReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectVersions from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProjectVersionsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProjectVersionsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProjectVersionsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProjectVersionsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectVersion from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProjectVersionReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectVersion from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProjectVersionReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectVersion from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddProjectVersionReceived;
        protected virtual void OnDeveloperAddProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectVersions from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetProjectVersionsReceived;
        protected virtual void OnDeveloperGetProjectVersionsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetProjectVersionsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetProjectVersionsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectVersion from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateProjectVersionReceived;
        protected virtual void OnDeveloperUpdateProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectVersion from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProjectVersionReceived;
        protected virtual void OnAdminAddProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectVersions from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProjectVersionsReceived;
        protected virtual void OnAdminGetProjectVersionsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProjectVersionsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProjectVersionsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectVersion from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProjectVersionReceived;
        protected virtual void OnAdminUpdateProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectVersion from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProjectVersionReceived;
        protected virtual void OnAdminDeleteProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectVersion from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProjectVersionReceived;
        protected virtual void OnCRUDCoordinatorAddProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectVersions from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProjectVersionsReceived;
        protected virtual void OnCRUDCoordinatorGetProjectVersionsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProjectVersionsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProjectVersionsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectVersion from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProjectVersionReceived;
        protected virtual void OnCRUDCoordinatorUpdateProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectVersion from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProjectVersionReceived;
        protected virtual void OnCRUDCoordinatorDeleteProjectVersionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProjectVersionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProjectVersionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostTypes from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetServiceHostTypesReceived;
        protected virtual void OnGuestGetServiceHostTypesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetServiceHostTypesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetServiceHostTypesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceHostType from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddServiceHostTypeReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddServiceHostTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddServiceHostTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddServiceHostTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostTypes from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetServiceHostTypesReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetServiceHostTypesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetServiceHostTypesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetServiceHostTypesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceHostType from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateServiceHostTypeReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateServiceHostTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateServiceHostTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateServiceHostTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceHostType from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteServiceHostTypeReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteServiceHostTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteServiceHostTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteServiceHostTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceHostType from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddServiceHostTypeReceived;
        protected virtual void OnAdminAddServiceHostTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddServiceHostTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddServiceHostTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostTypes from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetServiceHostTypesReceived;
        protected virtual void OnAdminGetServiceHostTypesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetServiceHostTypesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetServiceHostTypesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceHostType from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateServiceHostTypeReceived;
        protected virtual void OnAdminUpdateServiceHostTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateServiceHostTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateServiceHostTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceHostType from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteServiceHostTypeReceived;
        protected virtual void OnAdminDeleteServiceHostTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteServiceHostTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteServiceHostTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceHostType from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddServiceHostTypeReceived;
        protected virtual void OnCRUDCoordinatorAddServiceHostTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddServiceHostTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddServiceHostTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceHostTypes from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetServiceHostTypesReceived;
        protected virtual void OnCRUDCoordinatorGetServiceHostTypesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetServiceHostTypesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetServiceHostTypesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceHostType from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateServiceHostTypeReceived;
        protected virtual void OnCRUDCoordinatorUpdateServiceHostTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateServiceHostTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateServiceHostTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceHostType from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteServiceHostTypeReceived;
        protected virtual void OnCRUDCoordinatorDeleteServiceHostTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteServiceHostTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteServiceHostTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddRemoteEndpoint from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddRemoteEndpointReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddRemoteEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddRemoteEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddRemoteEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetRemoteEndpoints from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetRemoteEndpointsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetRemoteEndpointsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetRemoteEndpointsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetRemoteEndpointsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateRemoteEndpoint from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateRemoteEndpointReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateRemoteEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateRemoteEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateRemoteEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteRemoteEndpoint from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteRemoteEndpointReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteRemoteEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteRemoteEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteRemoteEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddRemoteEndpoint from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddRemoteEndpointReceived;
        protected virtual void OnAdminAddRemoteEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddRemoteEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddRemoteEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetRemoteEndpoints from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetRemoteEndpointsReceived;
        protected virtual void OnAdminGetRemoteEndpointsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetRemoteEndpointsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetRemoteEndpointsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateRemoteEndpoint from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateRemoteEndpointReceived;
        protected virtual void OnAdminUpdateRemoteEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateRemoteEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateRemoteEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteRemoteEndpoint from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteRemoteEndpointReceived;
        protected virtual void OnAdminDeleteRemoteEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteRemoteEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteRemoteEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddRemoteEndpoint from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddRemoteEndpointReceived;
        protected virtual void OnCRUDCoordinatorAddRemoteEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddRemoteEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddRemoteEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetRemoteEndpoints from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetRemoteEndpointsReceived;
        protected virtual void OnCRUDCoordinatorGetRemoteEndpointsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetRemoteEndpointsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetRemoteEndpointsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateRemoteEndpoint from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateRemoteEndpointReceived;
        protected virtual void OnCRUDCoordinatorUpdateRemoteEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateRemoteEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateRemoteEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteRemoteEndpoint from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteRemoteEndpointReceived;
        protected virtual void OnCRUDCoordinatorDeleteRemoteEndpointReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteRemoteEndpointReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteRemoteEndpointReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIAccount from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddEffortlessAPIAccountReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIAccounts from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetEffortlessAPIAccountsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetEffortlessAPIAccountsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetEffortlessAPIAccountsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetEffortlessAPIAccountsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIAccount from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateEffortlessAPIAccountReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIAccount from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteEffortlessAPIAccountReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIAccount from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddEffortlessAPIAccountReceived;
        protected virtual void OnDeveloperAddEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIAccounts from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetEffortlessAPIAccountsReceived;
        protected virtual void OnDeveloperGetEffortlessAPIAccountsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetEffortlessAPIAccountsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetEffortlessAPIAccountsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIAccount from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateEffortlessAPIAccountReceived;
        protected virtual void OnDeveloperUpdateEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIAccount from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteEffortlessAPIAccountReceived;
        protected virtual void OnDeveloperDeleteEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIAccount from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddEffortlessAPIAccountReceived;
        protected virtual void OnAdminAddEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIAccounts from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetEffortlessAPIAccountsReceived;
        protected virtual void OnAdminGetEffortlessAPIAccountsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetEffortlessAPIAccountsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetEffortlessAPIAccountsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIAccount from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateEffortlessAPIAccountReceived;
        protected virtual void OnAdminUpdateEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIAccount from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteEffortlessAPIAccountReceived;
        protected virtual void OnAdminDeleteEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIAccount from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddEffortlessAPIAccountReceived;
        protected virtual void OnCRUDCoordinatorAddEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIAccounts from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetEffortlessAPIAccountsReceived;
        protected virtual void OnCRUDCoordinatorGetEffortlessAPIAccountsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetEffortlessAPIAccountsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetEffortlessAPIAccountsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIAccount from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateEffortlessAPIAccountReceived;
        protected virtual void OnCRUDCoordinatorUpdateEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIAccount from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteEffortlessAPIAccountReceived;
        protected virtual void OnCRUDCoordinatorDeleteEffortlessAPIAccountReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteEffortlessAPIAccountReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteEffortlessAPIAccountReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceProducts from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetServiceProductsReceived;
        protected virtual void OnGuestGetServiceProductsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetServiceProductsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetServiceProductsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceProduct from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddServiceProductReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddServiceProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddServiceProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddServiceProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceProducts from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetServiceProductsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetServiceProductsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetServiceProductsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetServiceProductsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceProduct from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateServiceProductReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateServiceProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateServiceProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateServiceProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceProduct from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteServiceProductReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteServiceProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteServiceProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteServiceProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceProducts from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetServiceProductsReceived;
        protected virtual void OnDeveloperGetServiceProductsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetServiceProductsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetServiceProductsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceProduct from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddServiceProductReceived;
        protected virtual void OnAdminAddServiceProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddServiceProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddServiceProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceProducts from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetServiceProductsReceived;
        protected virtual void OnAdminGetServiceProductsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetServiceProductsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetServiceProductsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceProduct from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateServiceProductReceived;
        protected virtual void OnAdminUpdateServiceProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateServiceProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateServiceProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceProduct from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteServiceProductReceived;
        protected virtual void OnAdminDeleteServiceProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteServiceProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteServiceProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceProduct from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddServiceProductReceived;
        protected virtual void OnCRUDCoordinatorAddServiceProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddServiceProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddServiceProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceProducts from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetServiceProductsReceived;
        protected virtual void OnCRUDCoordinatorGetServiceProductsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetServiceProductsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetServiceProductsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceProduct from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateServiceProductReceived;
        protected virtual void OnCRUDCoordinatorUpdateServiceProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateServiceProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateServiceProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceProduct from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteServiceProductReceived;
        protected virtual void OnCRUDCoordinatorDeleteServiceProductReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteServiceProductReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteServiceProductReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProxyRelativeUrl from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProxyRelativeUrlReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProxyRelativeUrlReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProxyRelativeUrlReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProxyRelativeUrlReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProxyRelativeUrls from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProxyRelativeUrlsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProxyRelativeUrlsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProxyRelativeUrlsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProxyRelativeUrlsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProxyRelativeUrl from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProxyRelativeUrlReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProxyRelativeUrlReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProxyRelativeUrlReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProxyRelativeUrlReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProxyRelativeUrl from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProxyRelativeUrlReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProxyRelativeUrlReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProxyRelativeUrlReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProxyRelativeUrlReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProxyRelativeUrl from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProxyRelativeUrlReceived;
        protected virtual void OnAdminAddProxyRelativeUrlReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProxyRelativeUrlReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProxyRelativeUrlReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProxyRelativeUrls from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProxyRelativeUrlsReceived;
        protected virtual void OnAdminGetProxyRelativeUrlsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProxyRelativeUrlsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProxyRelativeUrlsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProxyRelativeUrl from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProxyRelativeUrlReceived;
        protected virtual void OnAdminUpdateProxyRelativeUrlReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProxyRelativeUrlReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProxyRelativeUrlReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProxyRelativeUrl from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProxyRelativeUrlReceived;
        protected virtual void OnAdminDeleteProxyRelativeUrlReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProxyRelativeUrlReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProxyRelativeUrlReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProxyRelativeUrl from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProxyRelativeUrlReceived;
        protected virtual void OnCRUDCoordinatorAddProxyRelativeUrlReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProxyRelativeUrlReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProxyRelativeUrlReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProxyRelativeUrls from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProxyRelativeUrlsReceived;
        protected virtual void OnCRUDCoordinatorGetProxyRelativeUrlsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProxyRelativeUrlsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProxyRelativeUrlsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProxyRelativeUrl from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProxyRelativeUrlReceived;
        protected virtual void OnCRUDCoordinatorUpdateProxyRelativeUrlReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProxyRelativeUrlReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProxyRelativeUrlReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProxyRelativeUrl from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProxyRelativeUrlReceived;
        protected virtual void OnCRUDCoordinatorDeleteProxyRelativeUrlReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProxyRelativeUrlReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProxyRelativeUrlReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectRequestSummary from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProjectRequestSummaryReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProjectRequestSummaryReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProjectRequestSummaryReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProjectRequestSummaryReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectRequestSummaries from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProjectRequestSummariesReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProjectRequestSummariesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProjectRequestSummariesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProjectRequestSummariesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectRequestSummary from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProjectRequestSummaryReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProjectRequestSummaryReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProjectRequestSummaryReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProjectRequestSummaryReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectRequestSummary from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProjectRequestSummaryReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProjectRequestSummaryReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProjectRequestSummaryReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProjectRequestSummaryReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectRequestSummary from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProjectRequestSummaryReceived;
        protected virtual void OnAdminAddProjectRequestSummaryReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProjectRequestSummaryReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProjectRequestSummaryReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectRequestSummaries from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProjectRequestSummariesReceived;
        protected virtual void OnAdminGetProjectRequestSummariesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProjectRequestSummariesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProjectRequestSummariesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectRequestSummary from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProjectRequestSummaryReceived;
        protected virtual void OnAdminUpdateProjectRequestSummaryReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProjectRequestSummaryReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProjectRequestSummaryReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectRequestSummary from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProjectRequestSummaryReceived;
        protected virtual void OnAdminDeleteProjectRequestSummaryReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProjectRequestSummaryReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProjectRequestSummaryReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectRequestSummary from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProjectRequestSummaryReceived;
        protected virtual void OnCRUDCoordinatorAddProjectRequestSummaryReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProjectRequestSummaryReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProjectRequestSummaryReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectRequestSummaries from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProjectRequestSummariesReceived;
        protected virtual void OnCRUDCoordinatorGetProjectRequestSummariesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProjectRequestSummariesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProjectRequestSummariesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectRequestSummary from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProjectRequestSummaryReceived;
        protected virtual void OnCRUDCoordinatorUpdateProjectRequestSummaryReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProjectRequestSummaryReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProjectRequestSummaryReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectRequestSummary from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProjectRequestSummaryReceived;
        protected virtual void OnCRUDCoordinatorDeleteProjectRequestSummaryReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProjectRequestSummaryReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProjectRequestSummaryReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServicePlans from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetServicePlansReceived;
        protected virtual void OnGuestGetServicePlansReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetServicePlansReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetServicePlansReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServicePlan from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddServicePlanReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddServicePlanReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddServicePlanReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddServicePlanReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServicePlans from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetServicePlansReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetServicePlansReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetServicePlansReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetServicePlansReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServicePlan from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateServicePlanReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateServicePlanReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateServicePlanReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateServicePlanReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServicePlan from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteServicePlanReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteServicePlanReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteServicePlanReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteServicePlanReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServicePlans from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetServicePlansReceived;
        protected virtual void OnDeveloperGetServicePlansReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetServicePlansReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetServicePlansReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServicePlan from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddServicePlanReceived;
        protected virtual void OnAdminAddServicePlanReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddServicePlanReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddServicePlanReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServicePlans from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetServicePlansReceived;
        protected virtual void OnAdminGetServicePlansReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetServicePlansReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetServicePlansReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServicePlan from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateServicePlanReceived;
        protected virtual void OnAdminUpdateServicePlanReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateServicePlanReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateServicePlanReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServicePlan from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteServicePlanReceived;
        protected virtual void OnAdminDeleteServicePlanReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteServicePlanReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteServicePlanReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServicePlan from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddServicePlanReceived;
        protected virtual void OnCRUDCoordinatorAddServicePlanReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddServicePlanReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddServicePlanReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServicePlans from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetServicePlansReceived;
        protected virtual void OnCRUDCoordinatorGetServicePlansReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetServicePlansReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetServicePlansReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServicePlan from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateServicePlanReceived;
        protected virtual void OnCRUDCoordinatorUpdateServicePlanReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateServicePlanReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateServicePlanReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServicePlan from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteServicePlanReceived;
        protected virtual void OnCRUDCoordinatorDeleteServicePlanReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteServicePlanReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteServicePlanReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectIcon from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddProjectIconReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddProjectIconReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddProjectIconReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddProjectIconReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectIcons from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetProjectIconsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetProjectIconsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetProjectIconsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetProjectIconsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectIcon from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateProjectIconReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateProjectIconReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateProjectIconReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateProjectIconReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectIcon from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteProjectIconReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteProjectIconReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteProjectIconReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteProjectIconReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectIcon from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddProjectIconReceived;
        protected virtual void OnAdminAddProjectIconReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddProjectIconReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddProjectIconReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectIcons from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetProjectIconsReceived;
        protected virtual void OnAdminGetProjectIconsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetProjectIconsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetProjectIconsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectIcon from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateProjectIconReceived;
        protected virtual void OnAdminUpdateProjectIconReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateProjectIconReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateProjectIconReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectIcon from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteProjectIconReceived;
        protected virtual void OnAdminDeleteProjectIconReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteProjectIconReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteProjectIconReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddProjectIcon from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddProjectIconReceived;
        protected virtual void OnCRUDCoordinatorAddProjectIconReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddProjectIconReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddProjectIconReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetProjectIcons from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetProjectIconsReceived;
        protected virtual void OnCRUDCoordinatorGetProjectIconsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetProjectIconsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetProjectIconsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateProjectIcon from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateProjectIconReceived;
        protected virtual void OnCRUDCoordinatorUpdateProjectIconReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateProjectIconReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateProjectIconReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteProjectIcon from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteProjectIconReceived;
        protected virtual void OnCRUDCoordinatorDeleteProjectIconReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteProjectIconReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteProjectIconReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTableColumn from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddTableColumnReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTableColumns from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetTableColumnsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetTableColumnsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetTableColumnsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetTableColumnsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTableColumn from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateTableColumnReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTableColumn from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteTableColumnReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTableColumn from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddTableColumnReceived;
        protected virtual void OnDeveloperAddTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTableColumns from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetTableColumnsReceived;
        protected virtual void OnDeveloperGetTableColumnsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetTableColumnsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetTableColumnsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTableColumn from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateTableColumnReceived;
        protected virtual void OnDeveloperUpdateTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTableColumn from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteTableColumnReceived;
        protected virtual void OnDeveloperDeleteTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTableColumn from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddTableColumnReceived;
        protected virtual void OnAdminAddTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTableColumns from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetTableColumnsReceived;
        protected virtual void OnAdminGetTableColumnsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetTableColumnsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetTableColumnsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTableColumn from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateTableColumnReceived;
        protected virtual void OnAdminUpdateTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTableColumn from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteTableColumnReceived;
        protected virtual void OnAdminDeleteTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTableColumn from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddTableColumnReceived;
        protected virtual void OnCRUDCoordinatorAddTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTableColumns from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetTableColumnsReceived;
        protected virtual void OnCRUDCoordinatorGetTableColumnsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetTableColumnsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetTableColumnsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTableColumn from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateTableColumnReceived;
        protected virtual void OnCRUDCoordinatorUpdateTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTableColumn from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteTableColumnReceived;
        protected virtual void OnCRUDCoordinatorDeleteTableColumnReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteTableColumnReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteTableColumnReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTableRoleWhere from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddTableRoleWhereReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTableRoleWheres from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetTableRoleWheresReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetTableRoleWheresReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetTableRoleWheresReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetTableRoleWheresReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTableRoleWhere from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateTableRoleWhereReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTableRoleWhere from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteTableRoleWhereReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTableRoleWhere from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddTableRoleWhereReceived;
        protected virtual void OnDeveloperAddTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTableRoleWheres from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetTableRoleWheresReceived;
        protected virtual void OnDeveloperGetTableRoleWheresReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetTableRoleWheresReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetTableRoleWheresReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTableRoleWhere from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateTableRoleWhereReceived;
        protected virtual void OnDeveloperUpdateTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTableRoleWhere from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteTableRoleWhereReceived;
        protected virtual void OnDeveloperDeleteTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTableRoleWhere from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddTableRoleWhereReceived;
        protected virtual void OnAdminAddTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTableRoleWheres from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetTableRoleWheresReceived;
        protected virtual void OnAdminGetTableRoleWheresReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetTableRoleWheresReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetTableRoleWheresReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTableRoleWhere from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateTableRoleWhereReceived;
        protected virtual void OnAdminUpdateTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTableRoleWhere from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteTableRoleWhereReceived;
        protected virtual void OnAdminDeleteTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTableRoleWhere from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddTableRoleWhereReceived;
        protected virtual void OnCRUDCoordinatorAddTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTableRoleWheres from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetTableRoleWheresReceived;
        protected virtual void OnCRUDCoordinatorGetTableRoleWheresReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetTableRoleWheresReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetTableRoleWheresReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTableRoleWhere from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateTableRoleWhereReceived;
        protected virtual void OnCRUDCoordinatorUpdateTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTableRoleWhere from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteTableRoleWhereReceived;
        protected virtual void OnCRUDCoordinatorDeleteTableRoleWhereReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteTableRoleWhereReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteTableRoleWhereReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIProject from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddEffortlessAPIProjectReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIProjects from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetEffortlessAPIProjectsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetEffortlessAPIProjectsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetEffortlessAPIProjectsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetEffortlessAPIProjectsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIProject from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateEffortlessAPIProjectReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIProject from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteEffortlessAPIProjectReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIProject from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddEffortlessAPIProjectReceived;
        protected virtual void OnDeveloperAddEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIProjects from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetEffortlessAPIProjectsReceived;
        protected virtual void OnDeveloperGetEffortlessAPIProjectsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetEffortlessAPIProjectsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetEffortlessAPIProjectsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIProject from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateEffortlessAPIProjectReceived;
        protected virtual void OnDeveloperUpdateEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIProject from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteEffortlessAPIProjectReceived;
        protected virtual void OnDeveloperDeleteEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIProject from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddEffortlessAPIProjectReceived;
        protected virtual void OnAdminAddEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIProjects from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetEffortlessAPIProjectsReceived;
        protected virtual void OnAdminGetEffortlessAPIProjectsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetEffortlessAPIProjectsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetEffortlessAPIProjectsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIProject from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateEffortlessAPIProjectReceived;
        protected virtual void OnAdminUpdateEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIProject from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteEffortlessAPIProjectReceived;
        protected virtual void OnAdminDeleteEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEffortlessAPIProject from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddEffortlessAPIProjectReceived;
        protected virtual void OnCRUDCoordinatorAddEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEffortlessAPIProjects from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetEffortlessAPIProjectsReceived;
        protected virtual void OnCRUDCoordinatorGetEffortlessAPIProjectsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetEffortlessAPIProjectsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetEffortlessAPIProjectsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEffortlessAPIProject from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateEffortlessAPIProjectReceived;
        protected virtual void OnCRUDCoordinatorUpdateEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEffortlessAPIProject from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteEffortlessAPIProjectReceived;
        protected virtual void OnCRUDCoordinatorDeleteEffortlessAPIProjectReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteEffortlessAPIProjectReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteEffortlessAPIProjectReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddColumnRoleCRUD from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddColumnRoleCRUDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetColumnRoleCRUDs from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetColumnRoleCRUDsReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetColumnRoleCRUDsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetColumnRoleCRUDsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetColumnRoleCRUDsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateColumnRoleCRUD from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateColumnRoleCRUDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteColumnRoleCRUD from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteColumnRoleCRUDReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddColumnRoleCRUD from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperAddColumnRoleCRUDReceived;
        protected virtual void OnDeveloperAddColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperAddColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperAddColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetColumnRoleCRUDs from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperGetColumnRoleCRUDsReceived;
        protected virtual void OnDeveloperGetColumnRoleCRUDsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperGetColumnRoleCRUDsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperGetColumnRoleCRUDsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateColumnRoleCRUD from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperUpdateColumnRoleCRUDReceived;
        protected virtual void OnDeveloperUpdateColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperUpdateColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperUpdateColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteColumnRoleCRUD from Developer
        /// </summary>
        public event EventHandler<PayloadEventArgs> DeveloperDeleteColumnRoleCRUDReceived;
        protected virtual void OnDeveloperDeleteColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.DeveloperDeleteColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.DeveloperDeleteColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddColumnRoleCRUD from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddColumnRoleCRUDReceived;
        protected virtual void OnAdminAddColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetColumnRoleCRUDs from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetColumnRoleCRUDsReceived;
        protected virtual void OnAdminGetColumnRoleCRUDsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetColumnRoleCRUDsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetColumnRoleCRUDsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateColumnRoleCRUD from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateColumnRoleCRUDReceived;
        protected virtual void OnAdminUpdateColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteColumnRoleCRUD from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteColumnRoleCRUDReceived;
        protected virtual void OnAdminDeleteColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddColumnRoleCRUD from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddColumnRoleCRUDReceived;
        protected virtual void OnCRUDCoordinatorAddColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetColumnRoleCRUDs from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetColumnRoleCRUDsReceived;
        protected virtual void OnCRUDCoordinatorGetColumnRoleCRUDsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetColumnRoleCRUDsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetColumnRoleCRUDsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateColumnRoleCRUD from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateColumnRoleCRUDReceived;
        protected virtual void OnCRUDCoordinatorUpdateColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteColumnRoleCRUD from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteColumnRoleCRUDReceived;
        protected virtual void OnCRUDCoordinatorDeleteColumnRoleCRUDReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteColumnRoleCRUDReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteColumnRoleCRUDReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetSDKLanguages from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetSDKLanguagesReceived;
        protected virtual void OnGuestGetSDKLanguagesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetSDKLanguagesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetSDKLanguagesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddSDKLanguage from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddSDKLanguageReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddSDKLanguageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddSDKLanguageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddSDKLanguageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetSDKLanguages from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetSDKLanguagesReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetSDKLanguagesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetSDKLanguagesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetSDKLanguagesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateSDKLanguage from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateSDKLanguageReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateSDKLanguageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateSDKLanguageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateSDKLanguageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteSDKLanguage from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteSDKLanguageReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteSDKLanguageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteSDKLanguageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteSDKLanguageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddSDKLanguage from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddSDKLanguageReceived;
        protected virtual void OnAdminAddSDKLanguageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddSDKLanguageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddSDKLanguageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetSDKLanguages from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetSDKLanguagesReceived;
        protected virtual void OnAdminGetSDKLanguagesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetSDKLanguagesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetSDKLanguagesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateSDKLanguage from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateSDKLanguageReceived;
        protected virtual void OnAdminUpdateSDKLanguageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateSDKLanguageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateSDKLanguageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteSDKLanguage from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteSDKLanguageReceived;
        protected virtual void OnAdminDeleteSDKLanguageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteSDKLanguageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteSDKLanguageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddSDKLanguage from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddSDKLanguageReceived;
        protected virtual void OnCRUDCoordinatorAddSDKLanguageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddSDKLanguageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddSDKLanguageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetSDKLanguages from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetSDKLanguagesReceived;
        protected virtual void OnCRUDCoordinatorGetSDKLanguagesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetSDKLanguagesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetSDKLanguagesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateSDKLanguage from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateSDKLanguageReceived;
        protected virtual void OnCRUDCoordinatorUpdateSDKLanguageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateSDKLanguageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateSDKLanguageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteSDKLanguage from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteSDKLanguageReceived;
        protected virtual void OnCRUDCoordinatorDeleteSDKLanguageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteSDKLanguageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteSDKLanguageReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceKey from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddServiceKeyReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddServiceKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddServiceKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddServiceKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceKeys from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetServiceKeysReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetServiceKeysReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetServiceKeysReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetServiceKeysReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceKey from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateServiceKeyReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateServiceKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateServiceKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateServiceKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceKey from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteServiceKeyReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteServiceKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteServiceKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteServiceKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceKey from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddServiceKeyReceived;
        protected virtual void OnAdminAddServiceKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddServiceKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddServiceKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceKeys from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetServiceKeysReceived;
        protected virtual void OnAdminGetServiceKeysReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetServiceKeysReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetServiceKeysReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceKey from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateServiceKeyReceived;
        protected virtual void OnAdminUpdateServiceKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateServiceKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateServiceKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceKey from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteServiceKeyReceived;
        protected virtual void OnAdminDeleteServiceKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteServiceKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteServiceKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddServiceKey from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddServiceKeyReceived;
        protected virtual void OnCRUDCoordinatorAddServiceKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddServiceKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddServiceKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetServiceKeys from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetServiceKeysReceived;
        protected virtual void OnCRUDCoordinatorGetServiceKeysReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetServiceKeysReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetServiceKeysReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateServiceKey from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateServiceKeyReceived;
        protected virtual void OnCRUDCoordinatorUpdateServiceKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateServiceKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateServiceKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteServiceKey from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteServiceKeyReceived;
        protected virtual void OnCRUDCoordinatorDeleteServiceKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteServiceKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteServiceKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCustomerType from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorAddCustomerTypeReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorAddCustomerTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorAddCustomerTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorAddCustomerTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCustomerTypes from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorGetCustomerTypesReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorGetCustomerTypesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorGetCustomerTypesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorGetCustomerTypesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCustomerType from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorUpdateCustomerTypeReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorUpdateCustomerTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorUpdateCustomerTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorUpdateCustomerTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCustomerType from EffortlessProxyDataCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> EffortlessProxyDataCoordinatorDeleteCustomerTypeReceived;
        protected virtual void OnEffortlessProxyDataCoordinatorDeleteCustomerTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.EffortlessProxyDataCoordinatorDeleteCustomerTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.EffortlessProxyDataCoordinatorDeleteCustomerTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCustomerType from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddCustomerTypeReceived;
        protected virtual void OnAdminAddCustomerTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddCustomerTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddCustomerTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCustomerTypes from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetCustomerTypesReceived;
        protected virtual void OnAdminGetCustomerTypesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetCustomerTypesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetCustomerTypesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCustomerType from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateCustomerTypeReceived;
        protected virtual void OnAdminUpdateCustomerTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateCustomerTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateCustomerTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCustomerType from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteCustomerTypeReceived;
        protected virtual void OnAdminDeleteCustomerTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteCustomerTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteCustomerTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCustomerType from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorAddCustomerTypeReceived;
        protected virtual void OnCRUDCoordinatorAddCustomerTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorAddCustomerTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorAddCustomerTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCustomerTypes from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetCustomerTypesReceived;
        protected virtual void OnCRUDCoordinatorGetCustomerTypesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetCustomerTypesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetCustomerTypesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCustomerType from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorUpdateCustomerTypeReceived;
        protected virtual void OnCRUDCoordinatorUpdateCustomerTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorUpdateCustomerTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorUpdateCustomerTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCustomerType from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorDeleteCustomerTypeReceived;
        protected virtual void OnCRUDCoordinatorDeleteCustomerTypeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorDeleteCustomerTypeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorDeleteCustomerTypeReceived(this, plea);
            }
        }

        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ResetRabbitSassyMQConfiguration(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ResetRabbitSassyMQConfiguration(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.crudcoordinator.resetrabbitsassymqconfiguration", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ResetJWTSecretKey(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ResetJWTSecretKey(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.crudcoordinator.resetjwtsecretkey", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetSchema - 
        /// </summary>
        public Task GetSchema(DMProxy dmp, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetSchema(dmp, this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetSchema - 
        /// </summary>
        public Task GetSchema(DMProxy dmp, String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetSchema(dmp, payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        /// <summary>
        /// GetSchema - 
        /// </summary>
        public Task GetSchema(DMProxy dmp, StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("developer.custom.crudcoordinator.getschema", payload, replyHandler, timeoutHandler, waitTimeout, dmp.RoutingKey);
        }
        
        
        /// <summary>
        /// GetSchemas - 
        /// </summary>
        public Task GetSchemas(DMProxy dmp, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetSchemas(dmp, this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetSchemas - 
        /// </summary>
        public Task GetSchemas(DMProxy dmp, String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetSchemas(dmp, payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        /// <summary>
        /// GetSchemas - 
        /// </summary>
        public Task GetSchemas(DMProxy dmp, StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("developer.custom.crudcoordinator.getschemas", payload, replyHandler, timeoutHandler, waitTimeout, dmp.RoutingKey);
        }
        
        
        /// <summary>
        /// AddPlanProduct - 
        /// </summary>
        public Task AddPlanProduct(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddPlanProduct(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddPlanProduct - 
        /// </summary>
        public Task AddPlanProduct(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddPlanProduct(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddPlanProduct - 
        /// </summary>
        public Task AddPlanProduct(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addplanproduct", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetPlanProducts - 
        /// </summary>
        public Task GetPlanProducts(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetPlanProducts(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetPlanProducts - 
        /// </summary>
        public Task GetPlanProducts(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetPlanProducts(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetPlanProducts - 
        /// </summary>
        public Task GetPlanProducts(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getplanproducts", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdatePlanProduct - 
        /// </summary>
        public Task UpdatePlanProduct(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdatePlanProduct(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdatePlanProduct - 
        /// </summary>
        public Task UpdatePlanProduct(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdatePlanProduct(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdatePlanProduct - 
        /// </summary>
        public Task UpdatePlanProduct(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateplanproduct", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeletePlanProduct - 
        /// </summary>
        public Task DeletePlanProduct(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeletePlanProduct(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeletePlanProduct - 
        /// </summary>
        public Task DeletePlanProduct(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeletePlanProduct(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeletePlanProduct - 
        /// </summary>
        public Task DeletePlanProduct(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteplanproduct", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProjectTable - 
        /// </summary>
        public Task AddProjectTable(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProjectTable(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProjectTable - 
        /// </summary>
        public Task AddProjectTable(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProjectTable(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProjectTable - 
        /// </summary>
        public Task AddProjectTable(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addprojecttable", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProjectTables - 
        /// </summary>
        public Task GetProjectTables(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProjectTables(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProjectTables - 
        /// </summary>
        public Task GetProjectTables(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProjectTables(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProjectTables - 
        /// </summary>
        public Task GetProjectTables(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getprojecttables", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProjectTable - 
        /// </summary>
        public Task UpdateProjectTable(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProjectTable(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProjectTable - 
        /// </summary>
        public Task UpdateProjectTable(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProjectTable(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProjectTable - 
        /// </summary>
        public Task UpdateProjectTable(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateprojecttable", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProjectTable - 
        /// </summary>
        public Task DeleteProjectTable(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProjectTable(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProjectTable - 
        /// </summary>
        public Task DeleteProjectTable(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProjectTable(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProjectTable - 
        /// </summary>
        public Task DeleteProjectTable(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteprojecttable", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddServiceHostSize - 
        /// </summary>
        public Task AddServiceHostSize(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddServiceHostSize(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddServiceHostSize - 
        /// </summary>
        public Task AddServiceHostSize(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddServiceHostSize(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddServiceHostSize - 
        /// </summary>
        public Task AddServiceHostSize(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addservicehostsize", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetServiceHostSizes - 
        /// </summary>
        public Task GetServiceHostSizes(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetServiceHostSizes(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetServiceHostSizes - 
        /// </summary>
        public Task GetServiceHostSizes(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetServiceHostSizes(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetServiceHostSizes - 
        /// </summary>
        public Task GetServiceHostSizes(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getservicehostsizes", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateServiceHostSize - 
        /// </summary>
        public Task UpdateServiceHostSize(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateServiceHostSize(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateServiceHostSize - 
        /// </summary>
        public Task UpdateServiceHostSize(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateServiceHostSize(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateServiceHostSize - 
        /// </summary>
        public Task UpdateServiceHostSize(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateservicehostsize", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteServiceHostSize - 
        /// </summary>
        public Task DeleteServiceHostSize(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteServiceHostSize(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteServiceHostSize - 
        /// </summary>
        public Task DeleteServiceHostSize(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteServiceHostSize(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteServiceHostSize - 
        /// </summary>
        public Task DeleteServiceHostSize(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteservicehostsize", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddColumnValue - 
        /// </summary>
        public Task AddColumnValue(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddColumnValue(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddColumnValue - 
        /// </summary>
        public Task AddColumnValue(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddColumnValue(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddColumnValue - 
        /// </summary>
        public Task AddColumnValue(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addcolumnvalue", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetColumnValues - 
        /// </summary>
        public Task GetColumnValues(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetColumnValues(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetColumnValues - 
        /// </summary>
        public Task GetColumnValues(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetColumnValues(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetColumnValues - 
        /// </summary>
        public Task GetColumnValues(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getcolumnvalues", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateColumnValue - 
        /// </summary>
        public Task UpdateColumnValue(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateColumnValue(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateColumnValue - 
        /// </summary>
        public Task UpdateColumnValue(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateColumnValue(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateColumnValue - 
        /// </summary>
        public Task UpdateColumnValue(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updatecolumnvalue", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteColumnValue - 
        /// </summary>
        public Task DeleteColumnValue(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteColumnValue(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteColumnValue - 
        /// </summary>
        public Task DeleteColumnValue(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteColumnValue(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteColumnValue - 
        /// </summary>
        public Task DeleteColumnValue(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deletecolumnvalue", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddPortfolioItemRETIRED - 
        /// </summary>
        public Task AddPortfolioItemRETIRED(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddPortfolioItemRETIRED(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddPortfolioItemRETIRED - 
        /// </summary>
        public Task AddPortfolioItemRETIRED(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddPortfolioItemRETIRED(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddPortfolioItemRETIRED - 
        /// </summary>
        public Task AddPortfolioItemRETIRED(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addportfolioitemretired", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetPortfolioItemsRETIRED - 
        /// </summary>
        public Task GetPortfolioItemsRETIRED(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetPortfolioItemsRETIRED(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetPortfolioItemsRETIRED - 
        /// </summary>
        public Task GetPortfolioItemsRETIRED(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetPortfolioItemsRETIRED(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetPortfolioItemsRETIRED - 
        /// </summary>
        public Task GetPortfolioItemsRETIRED(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getportfolioitemsretired", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdatePortfolioItemRETIRED - 
        /// </summary>
        public Task UpdatePortfolioItemRETIRED(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdatePortfolioItemRETIRED(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdatePortfolioItemRETIRED - 
        /// </summary>
        public Task UpdatePortfolioItemRETIRED(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdatePortfolioItemRETIRED(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdatePortfolioItemRETIRED - 
        /// </summary>
        public Task UpdatePortfolioItemRETIRED(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateportfolioitemretired", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeletePortfolioItemRETIRED - 
        /// </summary>
        public Task DeletePortfolioItemRETIRED(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeletePortfolioItemRETIRED(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeletePortfolioItemRETIRED - 
        /// </summary>
        public Task DeletePortfolioItemRETIRED(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeletePortfolioItemRETIRED(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeletePortfolioItemRETIRED - 
        /// </summary>
        public Task DeletePortfolioItemRETIRED(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteportfolioitemretired", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProjectStage - 
        /// </summary>
        public Task AddProjectStage(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProjectStage(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProjectStage - 
        /// </summary>
        public Task AddProjectStage(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProjectStage(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProjectStage - 
        /// </summary>
        public Task AddProjectStage(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addprojectstage", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProjectStages - 
        /// </summary>
        public Task GetProjectStages(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProjectStages(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProjectStages - 
        /// </summary>
        public Task GetProjectStages(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProjectStages(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProjectStages - 
        /// </summary>
        public Task GetProjectStages(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getprojectstages", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProjectStage - 
        /// </summary>
        public Task UpdateProjectStage(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProjectStage(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProjectStage - 
        /// </summary>
        public Task UpdateProjectStage(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProjectStage(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProjectStage - 
        /// </summary>
        public Task UpdateProjectStage(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateprojectstage", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProjectStage - 
        /// </summary>
        public Task DeleteProjectStage(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProjectStage(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProjectStage - 
        /// </summary>
        public Task DeleteProjectStage(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProjectStage(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProjectStage - 
        /// </summary>
        public Task DeleteProjectStage(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteprojectstage", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProjectVersionBuild - 
        /// </summary>
        public Task AddProjectVersionBuild(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProjectVersionBuild(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProjectVersionBuild - 
        /// </summary>
        public Task AddProjectVersionBuild(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProjectVersionBuild(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProjectVersionBuild - 
        /// </summary>
        public Task AddProjectVersionBuild(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addprojectversionbuild", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProjectVersionBuilds - 
        /// </summary>
        public Task GetProjectVersionBuilds(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProjectVersionBuilds(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProjectVersionBuilds - 
        /// </summary>
        public Task GetProjectVersionBuilds(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProjectVersionBuilds(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProjectVersionBuilds - 
        /// </summary>
        public Task GetProjectVersionBuilds(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getprojectversionbuilds", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProjectVersionBuild - 
        /// </summary>
        public Task UpdateProjectVersionBuild(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProjectVersionBuild(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProjectVersionBuild - 
        /// </summary>
        public Task UpdateProjectVersionBuild(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProjectVersionBuild(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProjectVersionBuild - 
        /// </summary>
        public Task UpdateProjectVersionBuild(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateprojectversionbuild", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProjectVersionBuild - 
        /// </summary>
        public Task DeleteProjectVersionBuild(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProjectVersionBuild(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProjectVersionBuild - 
        /// </summary>
        public Task DeleteProjectVersionBuild(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProjectVersionBuild(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProjectVersionBuild - 
        /// </summary>
        public Task DeleteProjectVersionBuild(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteprojectversionbuild", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProjectRole - 
        /// </summary>
        public Task AddProjectRole(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProjectRole(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProjectRole - 
        /// </summary>
        public Task AddProjectRole(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProjectRole(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProjectRole - 
        /// </summary>
        public Task AddProjectRole(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addprojectrole", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProjectRoles - 
        /// </summary>
        public Task GetProjectRoles(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProjectRoles(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProjectRoles - 
        /// </summary>
        public Task GetProjectRoles(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProjectRoles(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProjectRoles - 
        /// </summary>
        public Task GetProjectRoles(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getprojectroles", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProjectRole - 
        /// </summary>
        public Task UpdateProjectRole(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProjectRole(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProjectRole - 
        /// </summary>
        public Task UpdateProjectRole(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProjectRole(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProjectRole - 
        /// </summary>
        public Task UpdateProjectRole(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateprojectrole", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProjectRole - 
        /// </summary>
        public Task DeleteProjectRole(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProjectRole(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProjectRole - 
        /// </summary>
        public Task DeleteProjectRole(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProjectRole(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProjectRole - 
        /// </summary>
        public Task DeleteProjectRole(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteprojectrole", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddServiceHostEndpoint - 
        /// </summary>
        public Task AddServiceHostEndpoint(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddServiceHostEndpoint(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddServiceHostEndpoint - 
        /// </summary>
        public Task AddServiceHostEndpoint(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddServiceHostEndpoint(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddServiceHostEndpoint - 
        /// </summary>
        public Task AddServiceHostEndpoint(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addservicehostendpoint", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetServiceHostEndpoints - 
        /// </summary>
        public Task GetServiceHostEndpoints(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetServiceHostEndpoints(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetServiceHostEndpoints - 
        /// </summary>
        public Task GetServiceHostEndpoints(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetServiceHostEndpoints(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetServiceHostEndpoints - 
        /// </summary>
        public Task GetServiceHostEndpoints(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getservicehostendpoints", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateServiceHostEndpoint - 
        /// </summary>
        public Task UpdateServiceHostEndpoint(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateServiceHostEndpoint(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateServiceHostEndpoint - 
        /// </summary>
        public Task UpdateServiceHostEndpoint(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateServiceHostEndpoint(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateServiceHostEndpoint - 
        /// </summary>
        public Task UpdateServiceHostEndpoint(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateservicehostendpoint", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteServiceHostEndpoint - 
        /// </summary>
        public Task DeleteServiceHostEndpoint(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteServiceHostEndpoint(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteServiceHostEndpoint - 
        /// </summary>
        public Task DeleteServiceHostEndpoint(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteServiceHostEndpoint(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteServiceHostEndpoint - 
        /// </summary>
        public Task DeleteServiceHostEndpoint(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteservicehostendpoint", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddEffortlessAPIService - 
        /// </summary>
        public Task AddEffortlessAPIService(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddEffortlessAPIService(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddEffortlessAPIService - 
        /// </summary>
        public Task AddEffortlessAPIService(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddEffortlessAPIService(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddEffortlessAPIService - 
        /// </summary>
        public Task AddEffortlessAPIService(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addeffortlessapiservice", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetEffortlessAPIServices - 
        /// </summary>
        public Task GetEffortlessAPIServices(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetEffortlessAPIServices(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetEffortlessAPIServices - 
        /// </summary>
        public Task GetEffortlessAPIServices(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetEffortlessAPIServices(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetEffortlessAPIServices - 
        /// </summary>
        public Task GetEffortlessAPIServices(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.geteffortlessapiservices", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateEffortlessAPIService - 
        /// </summary>
        public Task UpdateEffortlessAPIService(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateEffortlessAPIService(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateEffortlessAPIService - 
        /// </summary>
        public Task UpdateEffortlessAPIService(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateEffortlessAPIService(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateEffortlessAPIService - 
        /// </summary>
        public Task UpdateEffortlessAPIService(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateeffortlessapiservice", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteEffortlessAPIService - 
        /// </summary>
        public Task DeleteEffortlessAPIService(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteEffortlessAPIService(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteEffortlessAPIService - 
        /// </summary>
        public Task DeleteEffortlessAPIService(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteEffortlessAPIService(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteEffortlessAPIService - 
        /// </summary>
        public Task DeleteEffortlessAPIService(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteeffortlessapiservice", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProjectConnection - 
        /// </summary>
        public Task AddProjectConnection(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProjectConnection(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProjectConnection - 
        /// </summary>
        public Task AddProjectConnection(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProjectConnection(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProjectConnection - 
        /// </summary>
        public Task AddProjectConnection(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addprojectconnection", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProjectConnections - 
        /// </summary>
        public Task GetProjectConnections(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProjectConnections(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProjectConnections - 
        /// </summary>
        public Task GetProjectConnections(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProjectConnections(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProjectConnections - 
        /// </summary>
        public Task GetProjectConnections(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getprojectconnections", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProjectConnection - 
        /// </summary>
        public Task UpdateProjectConnection(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProjectConnection(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProjectConnection - 
        /// </summary>
        public Task UpdateProjectConnection(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProjectConnection(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProjectConnection - 
        /// </summary>
        public Task UpdateProjectConnection(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateprojectconnection", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProjectConnection - 
        /// </summary>
        public Task DeleteProjectConnection(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProjectConnection(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProjectConnection - 
        /// </summary>
        public Task DeleteProjectConnection(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProjectConnection(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProjectConnection - 
        /// </summary>
        public Task DeleteProjectConnection(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteprojectconnection", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProjectLexiconTerm - 
        /// </summary>
        public Task AddProjectLexiconTerm(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProjectLexiconTerm(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProjectLexiconTerm - 
        /// </summary>
        public Task AddProjectLexiconTerm(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProjectLexiconTerm(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProjectLexiconTerm - 
        /// </summary>
        public Task AddProjectLexiconTerm(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addprojectlexiconterm", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProjectLexiconTerms - 
        /// </summary>
        public Task GetProjectLexiconTerms(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProjectLexiconTerms(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProjectLexiconTerms - 
        /// </summary>
        public Task GetProjectLexiconTerms(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProjectLexiconTerms(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProjectLexiconTerms - 
        /// </summary>
        public Task GetProjectLexiconTerms(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getprojectlexiconterms", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProjectLexiconTerm - 
        /// </summary>
        public Task UpdateProjectLexiconTerm(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProjectLexiconTerm(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProjectLexiconTerm - 
        /// </summary>
        public Task UpdateProjectLexiconTerm(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProjectLexiconTerm(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProjectLexiconTerm - 
        /// </summary>
        public Task UpdateProjectLexiconTerm(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateprojectlexiconterm", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProjectLexiconTerm - 
        /// </summary>
        public Task DeleteProjectLexiconTerm(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProjectLexiconTerm(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProjectLexiconTerm - 
        /// </summary>
        public Task DeleteProjectLexiconTerm(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProjectLexiconTerm(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProjectLexiconTerm - 
        /// </summary>
        public Task DeleteProjectLexiconTerm(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteprojectlexiconterm", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddPortfolioRETIRED - 
        /// </summary>
        public Task AddPortfolioRETIRED(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddPortfolioRETIRED(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddPortfolioRETIRED - 
        /// </summary>
        public Task AddPortfolioRETIRED(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddPortfolioRETIRED(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddPortfolioRETIRED - 
        /// </summary>
        public Task AddPortfolioRETIRED(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addportfolioretired", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetPortfoliosRETIRED - 
        /// </summary>
        public Task GetPortfoliosRETIRED(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetPortfoliosRETIRED(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetPortfoliosRETIRED - 
        /// </summary>
        public Task GetPortfoliosRETIRED(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetPortfoliosRETIRED(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetPortfoliosRETIRED - 
        /// </summary>
        public Task GetPortfoliosRETIRED(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getportfoliosretired", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdatePortfolioRETIRED - 
        /// </summary>
        public Task UpdatePortfolioRETIRED(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdatePortfolioRETIRED(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdatePortfolioRETIRED - 
        /// </summary>
        public Task UpdatePortfolioRETIRED(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdatePortfolioRETIRED(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdatePortfolioRETIRED - 
        /// </summary>
        public Task UpdatePortfolioRETIRED(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateportfolioretired", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeletePortfolioRETIRED - 
        /// </summary>
        public Task DeletePortfolioRETIRED(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeletePortfolioRETIRED(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeletePortfolioRETIRED - 
        /// </summary>
        public Task DeletePortfolioRETIRED(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeletePortfolioRETIRED(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeletePortfolioRETIRED - 
        /// </summary>
        public Task DeletePortfolioRETIRED(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteportfolioretired", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProjectEmail - 
        /// </summary>
        public Task AddProjectEmail(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProjectEmail(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProjectEmail - 
        /// </summary>
        public Task AddProjectEmail(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProjectEmail(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProjectEmail - 
        /// </summary>
        public Task AddProjectEmail(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addprojectemail", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProjectEmails - 
        /// </summary>
        public Task GetProjectEmails(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProjectEmails(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProjectEmails - 
        /// </summary>
        public Task GetProjectEmails(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProjectEmails(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProjectEmails - 
        /// </summary>
        public Task GetProjectEmails(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getprojectemails", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProjectEmail - 
        /// </summary>
        public Task UpdateProjectEmail(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProjectEmail(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProjectEmail - 
        /// </summary>
        public Task UpdateProjectEmail(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProjectEmail(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProjectEmail - 
        /// </summary>
        public Task UpdateProjectEmail(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateprojectemail", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProjectEmail - 
        /// </summary>
        public Task DeleteProjectEmail(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProjectEmail(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProjectEmail - 
        /// </summary>
        public Task DeleteProjectEmail(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProjectEmail(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProjectEmail - 
        /// </summary>
        public Task DeleteProjectEmail(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteprojectemail", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProjectVersion - 
        /// </summary>
        public Task AddProjectVersion(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProjectVersion(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProjectVersion - 
        /// </summary>
        public Task AddProjectVersion(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProjectVersion(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProjectVersion - 
        /// </summary>
        public Task AddProjectVersion(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addprojectversion", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProjectVersions - 
        /// </summary>
        public Task GetProjectVersions(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProjectVersions(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProjectVersions - 
        /// </summary>
        public Task GetProjectVersions(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProjectVersions(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProjectVersions - 
        /// </summary>
        public Task GetProjectVersions(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getprojectversions", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProjectVersion - 
        /// </summary>
        public Task UpdateProjectVersion(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProjectVersion(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProjectVersion - 
        /// </summary>
        public Task UpdateProjectVersion(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProjectVersion(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProjectVersion - 
        /// </summary>
        public Task UpdateProjectVersion(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateprojectversion", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProjectVersion - 
        /// </summary>
        public Task DeleteProjectVersion(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProjectVersion(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProjectVersion - 
        /// </summary>
        public Task DeleteProjectVersion(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProjectVersion(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProjectVersion - 
        /// </summary>
        public Task DeleteProjectVersion(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteprojectversion", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddServiceHostType - 
        /// </summary>
        public Task AddServiceHostType(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddServiceHostType(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddServiceHostType - 
        /// </summary>
        public Task AddServiceHostType(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddServiceHostType(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddServiceHostType - 
        /// </summary>
        public Task AddServiceHostType(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addservicehosttype", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetServiceHostTypes - 
        /// </summary>
        public Task GetServiceHostTypes(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetServiceHostTypes(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetServiceHostTypes - 
        /// </summary>
        public Task GetServiceHostTypes(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetServiceHostTypes(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetServiceHostTypes - 
        /// </summary>
        public Task GetServiceHostTypes(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getservicehosttypes", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateServiceHostType - 
        /// </summary>
        public Task UpdateServiceHostType(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateServiceHostType(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateServiceHostType - 
        /// </summary>
        public Task UpdateServiceHostType(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateServiceHostType(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateServiceHostType - 
        /// </summary>
        public Task UpdateServiceHostType(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateservicehosttype", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteServiceHostType - 
        /// </summary>
        public Task DeleteServiceHostType(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteServiceHostType(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteServiceHostType - 
        /// </summary>
        public Task DeleteServiceHostType(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteServiceHostType(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteServiceHostType - 
        /// </summary>
        public Task DeleteServiceHostType(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteservicehosttype", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddRemoteEndpoint - 
        /// </summary>
        public Task AddRemoteEndpoint(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddRemoteEndpoint(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddRemoteEndpoint - 
        /// </summary>
        public Task AddRemoteEndpoint(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddRemoteEndpoint(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddRemoteEndpoint - 
        /// </summary>
        public Task AddRemoteEndpoint(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addremoteendpoint", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetRemoteEndpoints - 
        /// </summary>
        public Task GetRemoteEndpoints(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetRemoteEndpoints(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetRemoteEndpoints - 
        /// </summary>
        public Task GetRemoteEndpoints(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetRemoteEndpoints(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetRemoteEndpoints - 
        /// </summary>
        public Task GetRemoteEndpoints(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getremoteendpoints", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateRemoteEndpoint - 
        /// </summary>
        public Task UpdateRemoteEndpoint(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateRemoteEndpoint(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateRemoteEndpoint - 
        /// </summary>
        public Task UpdateRemoteEndpoint(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateRemoteEndpoint(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateRemoteEndpoint - 
        /// </summary>
        public Task UpdateRemoteEndpoint(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateremoteendpoint", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteRemoteEndpoint - 
        /// </summary>
        public Task DeleteRemoteEndpoint(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteRemoteEndpoint(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteRemoteEndpoint - 
        /// </summary>
        public Task DeleteRemoteEndpoint(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteRemoteEndpoint(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteRemoteEndpoint - 
        /// </summary>
        public Task DeleteRemoteEndpoint(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteremoteendpoint", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddEffortlessAPIAccount - 
        /// </summary>
        public Task AddEffortlessAPIAccount(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddEffortlessAPIAccount(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddEffortlessAPIAccount - 
        /// </summary>
        public Task AddEffortlessAPIAccount(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddEffortlessAPIAccount(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddEffortlessAPIAccount - 
        /// </summary>
        public Task AddEffortlessAPIAccount(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addeffortlessapiaccount", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetEffortlessAPIAccounts - 
        /// </summary>
        public Task GetEffortlessAPIAccounts(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetEffortlessAPIAccounts(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetEffortlessAPIAccounts - 
        /// </summary>
        public Task GetEffortlessAPIAccounts(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetEffortlessAPIAccounts(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetEffortlessAPIAccounts - 
        /// </summary>
        public Task GetEffortlessAPIAccounts(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.geteffortlessapiaccounts", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateEffortlessAPIAccount - 
        /// </summary>
        public Task UpdateEffortlessAPIAccount(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateEffortlessAPIAccount(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateEffortlessAPIAccount - 
        /// </summary>
        public Task UpdateEffortlessAPIAccount(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateEffortlessAPIAccount(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateEffortlessAPIAccount - 
        /// </summary>
        public Task UpdateEffortlessAPIAccount(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateeffortlessapiaccount", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteEffortlessAPIAccount - 
        /// </summary>
        public Task DeleteEffortlessAPIAccount(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteEffortlessAPIAccount(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteEffortlessAPIAccount - 
        /// </summary>
        public Task DeleteEffortlessAPIAccount(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteEffortlessAPIAccount(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteEffortlessAPIAccount - 
        /// </summary>
        public Task DeleteEffortlessAPIAccount(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteeffortlessapiaccount", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddServiceProduct - 
        /// </summary>
        public Task AddServiceProduct(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddServiceProduct(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddServiceProduct - 
        /// </summary>
        public Task AddServiceProduct(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddServiceProduct(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddServiceProduct - 
        /// </summary>
        public Task AddServiceProduct(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addserviceproduct", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetServiceProducts - 
        /// </summary>
        public Task GetServiceProducts(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetServiceProducts(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetServiceProducts - 
        /// </summary>
        public Task GetServiceProducts(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetServiceProducts(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetServiceProducts - 
        /// </summary>
        public Task GetServiceProducts(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getserviceproducts", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateServiceProduct - 
        /// </summary>
        public Task UpdateServiceProduct(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateServiceProduct(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateServiceProduct - 
        /// </summary>
        public Task UpdateServiceProduct(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateServiceProduct(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateServiceProduct - 
        /// </summary>
        public Task UpdateServiceProduct(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateserviceproduct", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteServiceProduct - 
        /// </summary>
        public Task DeleteServiceProduct(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteServiceProduct(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteServiceProduct - 
        /// </summary>
        public Task DeleteServiceProduct(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteServiceProduct(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteServiceProduct - 
        /// </summary>
        public Task DeleteServiceProduct(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteserviceproduct", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProxyRelativeUrl - 
        /// </summary>
        public Task AddProxyRelativeUrl(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProxyRelativeUrl(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProxyRelativeUrl - 
        /// </summary>
        public Task AddProxyRelativeUrl(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProxyRelativeUrl(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProxyRelativeUrl - 
        /// </summary>
        public Task AddProxyRelativeUrl(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addproxyrelativeurl", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProxyRelativeUrls - 
        /// </summary>
        public Task GetProxyRelativeUrls(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProxyRelativeUrls(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProxyRelativeUrls - 
        /// </summary>
        public Task GetProxyRelativeUrls(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProxyRelativeUrls(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProxyRelativeUrls - 
        /// </summary>
        public Task GetProxyRelativeUrls(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getproxyrelativeurls", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProxyRelativeUrl - 
        /// </summary>
        public Task UpdateProxyRelativeUrl(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProxyRelativeUrl(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProxyRelativeUrl - 
        /// </summary>
        public Task UpdateProxyRelativeUrl(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProxyRelativeUrl(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProxyRelativeUrl - 
        /// </summary>
        public Task UpdateProxyRelativeUrl(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateproxyrelativeurl", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProxyRelativeUrl - 
        /// </summary>
        public Task DeleteProxyRelativeUrl(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProxyRelativeUrl(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProxyRelativeUrl - 
        /// </summary>
        public Task DeleteProxyRelativeUrl(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProxyRelativeUrl(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProxyRelativeUrl - 
        /// </summary>
        public Task DeleteProxyRelativeUrl(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteproxyrelativeurl", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProjectRequestSummary - 
        /// </summary>
        public Task AddProjectRequestSummary(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProjectRequestSummary(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProjectRequestSummary - 
        /// </summary>
        public Task AddProjectRequestSummary(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProjectRequestSummary(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProjectRequestSummary - 
        /// </summary>
        public Task AddProjectRequestSummary(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addprojectrequestsummary", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProjectRequestSummaries - 
        /// </summary>
        public Task GetProjectRequestSummaries(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProjectRequestSummaries(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProjectRequestSummaries - 
        /// </summary>
        public Task GetProjectRequestSummaries(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProjectRequestSummaries(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProjectRequestSummaries - 
        /// </summary>
        public Task GetProjectRequestSummaries(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getprojectrequestsummaries", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProjectRequestSummary - 
        /// </summary>
        public Task UpdateProjectRequestSummary(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProjectRequestSummary(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProjectRequestSummary - 
        /// </summary>
        public Task UpdateProjectRequestSummary(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProjectRequestSummary(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProjectRequestSummary - 
        /// </summary>
        public Task UpdateProjectRequestSummary(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateprojectrequestsummary", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProjectRequestSummary - 
        /// </summary>
        public Task DeleteProjectRequestSummary(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProjectRequestSummary(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProjectRequestSummary - 
        /// </summary>
        public Task DeleteProjectRequestSummary(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProjectRequestSummary(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProjectRequestSummary - 
        /// </summary>
        public Task DeleteProjectRequestSummary(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteprojectrequestsummary", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddServicePlan - 
        /// </summary>
        public Task AddServicePlan(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddServicePlan(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddServicePlan - 
        /// </summary>
        public Task AddServicePlan(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddServicePlan(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddServicePlan - 
        /// </summary>
        public Task AddServicePlan(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addserviceplan", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetServicePlans - 
        /// </summary>
        public Task GetServicePlans(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetServicePlans(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetServicePlans - 
        /// </summary>
        public Task GetServicePlans(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetServicePlans(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetServicePlans - 
        /// </summary>
        public Task GetServicePlans(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getserviceplans", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateServicePlan - 
        /// </summary>
        public Task UpdateServicePlan(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateServicePlan(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateServicePlan - 
        /// </summary>
        public Task UpdateServicePlan(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateServicePlan(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateServicePlan - 
        /// </summary>
        public Task UpdateServicePlan(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateserviceplan", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteServicePlan - 
        /// </summary>
        public Task DeleteServicePlan(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteServicePlan(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteServicePlan - 
        /// </summary>
        public Task DeleteServicePlan(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteServicePlan(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteServicePlan - 
        /// </summary>
        public Task DeleteServicePlan(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteserviceplan", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddProjectIcon - 
        /// </summary>
        public Task AddProjectIcon(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddProjectIcon(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddProjectIcon - 
        /// </summary>
        public Task AddProjectIcon(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddProjectIcon(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddProjectIcon - 
        /// </summary>
        public Task AddProjectIcon(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addprojecticon", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetProjectIcons - 
        /// </summary>
        public Task GetProjectIcons(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetProjectIcons(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetProjectIcons - 
        /// </summary>
        public Task GetProjectIcons(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetProjectIcons(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetProjectIcons - 
        /// </summary>
        public Task GetProjectIcons(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getprojecticons", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateProjectIcon - 
        /// </summary>
        public Task UpdateProjectIcon(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateProjectIcon(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateProjectIcon - 
        /// </summary>
        public Task UpdateProjectIcon(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateProjectIcon(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateProjectIcon - 
        /// </summary>
        public Task UpdateProjectIcon(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateprojecticon", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteProjectIcon - 
        /// </summary>
        public Task DeleteProjectIcon(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteProjectIcon(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteProjectIcon - 
        /// </summary>
        public Task DeleteProjectIcon(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteProjectIcon(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteProjectIcon - 
        /// </summary>
        public Task DeleteProjectIcon(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteprojecticon", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddTableColumn - 
        /// </summary>
        public Task AddTableColumn(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddTableColumn(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddTableColumn - 
        /// </summary>
        public Task AddTableColumn(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddTableColumn(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddTableColumn - 
        /// </summary>
        public Task AddTableColumn(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addtablecolumn", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetTableColumns - 
        /// </summary>
        public Task GetTableColumns(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetTableColumns(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetTableColumns - 
        /// </summary>
        public Task GetTableColumns(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetTableColumns(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetTableColumns - 
        /// </summary>
        public Task GetTableColumns(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.gettablecolumns", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateTableColumn - 
        /// </summary>
        public Task UpdateTableColumn(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateTableColumn(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateTableColumn - 
        /// </summary>
        public Task UpdateTableColumn(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateTableColumn(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateTableColumn - 
        /// </summary>
        public Task UpdateTableColumn(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updatetablecolumn", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteTableColumn - 
        /// </summary>
        public Task DeleteTableColumn(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteTableColumn(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteTableColumn - 
        /// </summary>
        public Task DeleteTableColumn(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteTableColumn(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteTableColumn - 
        /// </summary>
        public Task DeleteTableColumn(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deletetablecolumn", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddTableRoleWhere - 
        /// </summary>
        public Task AddTableRoleWhere(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddTableRoleWhere(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddTableRoleWhere - 
        /// </summary>
        public Task AddTableRoleWhere(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddTableRoleWhere(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddTableRoleWhere - 
        /// </summary>
        public Task AddTableRoleWhere(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addtablerolewhere", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetTableRoleWheres - 
        /// </summary>
        public Task GetTableRoleWheres(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetTableRoleWheres(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetTableRoleWheres - 
        /// </summary>
        public Task GetTableRoleWheres(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetTableRoleWheres(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetTableRoleWheres - 
        /// </summary>
        public Task GetTableRoleWheres(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.gettablerolewheres", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateTableRoleWhere - 
        /// </summary>
        public Task UpdateTableRoleWhere(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateTableRoleWhere(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateTableRoleWhere - 
        /// </summary>
        public Task UpdateTableRoleWhere(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateTableRoleWhere(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateTableRoleWhere - 
        /// </summary>
        public Task UpdateTableRoleWhere(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updatetablerolewhere", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteTableRoleWhere - 
        /// </summary>
        public Task DeleteTableRoleWhere(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteTableRoleWhere(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteTableRoleWhere - 
        /// </summary>
        public Task DeleteTableRoleWhere(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteTableRoleWhere(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteTableRoleWhere - 
        /// </summary>
        public Task DeleteTableRoleWhere(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deletetablerolewhere", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddEffortlessAPIProject - 
        /// </summary>
        public Task AddEffortlessAPIProject(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddEffortlessAPIProject(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddEffortlessAPIProject - 
        /// </summary>
        public Task AddEffortlessAPIProject(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddEffortlessAPIProject(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddEffortlessAPIProject - 
        /// </summary>
        public Task AddEffortlessAPIProject(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addeffortlessapiproject", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetEffortlessAPIProjects - 
        /// </summary>
        public Task GetEffortlessAPIProjects(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetEffortlessAPIProjects(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetEffortlessAPIProjects - 
        /// </summary>
        public Task GetEffortlessAPIProjects(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetEffortlessAPIProjects(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetEffortlessAPIProjects - 
        /// </summary>
        public Task GetEffortlessAPIProjects(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.geteffortlessapiprojects", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateEffortlessAPIProject - 
        /// </summary>
        public Task UpdateEffortlessAPIProject(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateEffortlessAPIProject(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateEffortlessAPIProject - 
        /// </summary>
        public Task UpdateEffortlessAPIProject(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateEffortlessAPIProject(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateEffortlessAPIProject - 
        /// </summary>
        public Task UpdateEffortlessAPIProject(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateeffortlessapiproject", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteEffortlessAPIProject - 
        /// </summary>
        public Task DeleteEffortlessAPIProject(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteEffortlessAPIProject(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteEffortlessAPIProject - 
        /// </summary>
        public Task DeleteEffortlessAPIProject(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteEffortlessAPIProject(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteEffortlessAPIProject - 
        /// </summary>
        public Task DeleteEffortlessAPIProject(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteeffortlessapiproject", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddColumnRoleCRUD - 
        /// </summary>
        public Task AddColumnRoleCRUD(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddColumnRoleCRUD(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddColumnRoleCRUD - 
        /// </summary>
        public Task AddColumnRoleCRUD(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddColumnRoleCRUD(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddColumnRoleCRUD - 
        /// </summary>
        public Task AddColumnRoleCRUD(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addcolumnrolecrud", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetColumnRoleCRUDs - 
        /// </summary>
        public Task GetColumnRoleCRUDs(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetColumnRoleCRUDs(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetColumnRoleCRUDs - 
        /// </summary>
        public Task GetColumnRoleCRUDs(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetColumnRoleCRUDs(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetColumnRoleCRUDs - 
        /// </summary>
        public Task GetColumnRoleCRUDs(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getcolumnrolecruds", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateColumnRoleCRUD - 
        /// </summary>
        public Task UpdateColumnRoleCRUD(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateColumnRoleCRUD(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateColumnRoleCRUD - 
        /// </summary>
        public Task UpdateColumnRoleCRUD(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateColumnRoleCRUD(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateColumnRoleCRUD - 
        /// </summary>
        public Task UpdateColumnRoleCRUD(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updatecolumnrolecrud", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteColumnRoleCRUD - 
        /// </summary>
        public Task DeleteColumnRoleCRUD(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteColumnRoleCRUD(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteColumnRoleCRUD - 
        /// </summary>
        public Task DeleteColumnRoleCRUD(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteColumnRoleCRUD(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteColumnRoleCRUD - 
        /// </summary>
        public Task DeleteColumnRoleCRUD(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deletecolumnrolecrud", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddSDKLanguage - 
        /// </summary>
        public Task AddSDKLanguage(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddSDKLanguage(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddSDKLanguage - 
        /// </summary>
        public Task AddSDKLanguage(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddSDKLanguage(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddSDKLanguage - 
        /// </summary>
        public Task AddSDKLanguage(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addsdklanguage", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetSDKLanguages - 
        /// </summary>
        public Task GetSDKLanguages(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetSDKLanguages(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetSDKLanguages - 
        /// </summary>
        public Task GetSDKLanguages(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetSDKLanguages(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetSDKLanguages - 
        /// </summary>
        public Task GetSDKLanguages(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getsdklanguages", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateSDKLanguage - 
        /// </summary>
        public Task UpdateSDKLanguage(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateSDKLanguage(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateSDKLanguage - 
        /// </summary>
        public Task UpdateSDKLanguage(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateSDKLanguage(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateSDKLanguage - 
        /// </summary>
        public Task UpdateSDKLanguage(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updatesdklanguage", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteSDKLanguage - 
        /// </summary>
        public Task DeleteSDKLanguage(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteSDKLanguage(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteSDKLanguage - 
        /// </summary>
        public Task DeleteSDKLanguage(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteSDKLanguage(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteSDKLanguage - 
        /// </summary>
        public Task DeleteSDKLanguage(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deletesdklanguage", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddServiceKey - 
        /// </summary>
        public Task AddServiceKey(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddServiceKey(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddServiceKey - 
        /// </summary>
        public Task AddServiceKey(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddServiceKey(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddServiceKey - 
        /// </summary>
        public Task AddServiceKey(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addservicekey", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetServiceKeys - 
        /// </summary>
        public Task GetServiceKeys(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetServiceKeys(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetServiceKeys - 
        /// </summary>
        public Task GetServiceKeys(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetServiceKeys(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetServiceKeys - 
        /// </summary>
        public Task GetServiceKeys(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getservicekeys", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateServiceKey - 
        /// </summary>
        public Task UpdateServiceKey(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateServiceKey(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateServiceKey - 
        /// </summary>
        public Task UpdateServiceKey(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateServiceKey(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateServiceKey - 
        /// </summary>
        public Task UpdateServiceKey(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updateservicekey", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteServiceKey - 
        /// </summary>
        public Task DeleteServiceKey(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteServiceKey(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteServiceKey - 
        /// </summary>
        public Task DeleteServiceKey(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteServiceKey(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteServiceKey - 
        /// </summary>
        public Task DeleteServiceKey(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deleteservicekey", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// AddCustomerType - 
        /// </summary>
        public Task AddCustomerType(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddCustomerType(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddCustomerType - 
        /// </summary>
        public Task AddCustomerType(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddCustomerType(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// AddCustomerType - 
        /// </summary>
        public Task AddCustomerType(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.addcustomertype", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetCustomerTypes - 
        /// </summary>
        public Task GetCustomerTypes(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetCustomerTypes(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetCustomerTypes - 
        /// </summary>
        public Task GetCustomerTypes(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetCustomerTypes(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetCustomerTypes - 
        /// </summary>
        public Task GetCustomerTypes(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.getcustomertypes", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// UpdateCustomerType - 
        /// </summary>
        public Task UpdateCustomerType(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateCustomerType(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateCustomerType - 
        /// </summary>
        public Task UpdateCustomerType(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateCustomerType(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// UpdateCustomerType - 
        /// </summary>
        public Task UpdateCustomerType(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.updatecustomertype", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DeleteCustomerType - 
        /// </summary>
        public Task DeleteCustomerType(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteCustomerType(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteCustomerType - 
        /// </summary>
        public Task DeleteCustomerType(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteCustomerType(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DeleteCustomerType - 
        /// </summary>
        public Task DeleteCustomerType(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.crud.crudcoordinator.deletecustomertype", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
    }
}

                    
