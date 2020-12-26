using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQDeveloper : SMQActorBase
    {

        public SMQDeveloper(String amqpConnectionString)
            : base(amqpConnectionString, "developer")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            var originalAccessToken = payload.AccessToken;
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                    case "developer.custom.crudcoordinator.getschema":
                        this.OnCRUDCoordinatorGetSchemaReceived(payload, bdea);
                        break;
                    
                    case "developer.custom.crudcoordinator.getschemas":
                        this.OnCRUDCoordinatorGetSchemasReceived(payload, bdea);
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
        /// Responds to: GetSchema from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetSchemaReceived;
        protected virtual void OnCRUDCoordinatorGetSchemaReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetSchemaReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetSchemaReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetSchemas from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorGetSchemasReceived;
        protected virtual void OnCRUDCoordinatorGetSchemasReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorGetSchemasReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorGetSchemasReceived(this, plea);
            }
        }

        /// <summary>
        /// CancelBuild - 
        /// </summary>
        public Task CancelBuild(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.CancelBuild(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// CancelBuild - 
        /// </summary>
        public Task CancelBuild(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.CancelBuild(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// CancelBuild - 
        /// </summary>
        public Task CancelBuild(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.custom.developer.cancelbuild", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// GetEndpointDetails - 
        /// </summary>
        public Task GetEndpointDetails(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetEndpointDetails(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetEndpointDetails - 
        /// </summary>
        public Task GetEndpointDetails(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetEndpointDetails(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// GetEndpointDetails - 
        /// </summary>
        public Task GetEndpointDetails(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.custom.developer.getendpointdetails", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// StopEndpoint - 
        /// </summary>
        public Task StopEndpoint(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.StopEndpoint(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// StopEndpoint - 
        /// </summary>
        public Task StopEndpoint(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.StopEndpoint(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// StopEndpoint - 
        /// </summary>
        public Task StopEndpoint(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.custom.developer.stopendpoint", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// ProxyStatusReport - 
        /// </summary>
        public Task ProxyStatusReport(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ProxyStatusReport(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ProxyStatusReport - 
        /// </summary>
        public Task ProxyStatusReport(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ProxyStatusReport(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// ProxyStatusReport - 
        /// </summary>
        public Task ProxyStatusReport(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.custom.developer.proxystatusreport", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// SynchronizeSchema - 
        /// </summary>
        public Task SynchronizeSchema(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SynchronizeSchema(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// SynchronizeSchema - 
        /// </summary>
        public Task SynchronizeSchema(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.SynchronizeSchema(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// SynchronizeSchema - 
        /// </summary>
        public Task SynchronizeSchema(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.custom.developer.synchronizeschema", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// MoveEndpoint - 
        /// </summary>
        public Task MoveEndpoint(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.MoveEndpoint(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// MoveEndpoint - 
        /// </summary>
        public Task MoveEndpoint(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.MoveEndpoint(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// MoveEndpoint - 
        /// </summary>
        public Task MoveEndpoint(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.custom.developer.moveendpoint", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// Publish - 
        /// </summary>
        public Task Publish(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.Publish(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// Publish - 
        /// </summary>
        public Task Publish(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.Publish(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// Publish - 
        /// </summary>
        public Task Publish(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.custom.developer.publish", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// StartEndpoint - 
        /// </summary>
        public Task StartEndpoint(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.StartEndpoint(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// StartEndpoint - 
        /// </summary>
        public Task StartEndpoint(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.StartEndpoint(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// StartEndpoint - 
        /// </summary>
        public Task StartEndpoint(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.custom.developer.startendpoint", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// SynchronizeWithAirtable - 
        /// </summary>
        public Task SynchronizeWithAirtable(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SynchronizeWithAirtable(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// SynchronizeWithAirtable - 
        /// </summary>
        public Task SynchronizeWithAirtable(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.SynchronizeWithAirtable(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// SynchronizeWithAirtable - 
        /// </summary>
        public Task SynchronizeWithAirtable(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.custom.developer.synchronizewithairtable", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// DoSomethingElse - 
        /// </summary>
        public Task DoSomethingElse(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DoSomethingElse(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DoSomethingElse - 
        /// </summary>
        public Task DoSomethingElse(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DoSomethingElse(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// DoSomethingElse - 
        /// </summary>
        public Task DoSomethingElse(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.custom.developer.dosomethingelse", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getplanproducts", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addprojecttable", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getprojecttables", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updateprojecttable", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deleteprojecttable", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addprojectstage", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getprojectstages", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updateprojectstage", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deleteprojectstage", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addprojectversionbuild", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getprojectversionbuilds", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updateprojectversionbuild", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addprojectrole", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getprojectroles", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updateprojectrole", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deleteprojectrole", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getservicehostendpoints", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.geteffortlessapiservices", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addprojectconnection", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getprojectconnections", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updateprojectconnection", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deleteprojectconnection", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addprojectlexiconterm", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getprojectlexiconterms", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updateprojectlexiconterm", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deleteprojectlexiconterm", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addprojectemail", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getprojectemails", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updateprojectemail", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deleteprojectemail", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addprojectversion", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getprojectversions", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updateprojectversion", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addeffortlessapiaccount", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.geteffortlessapiaccounts", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updateeffortlessapiaccount", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deleteeffortlessapiaccount", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getserviceproducts", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getserviceplans", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addtablecolumn", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.gettablecolumns", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updatetablecolumn", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deletetablecolumn", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addtablerolewhere", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.gettablerolewheres", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updatetablerolewhere", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deletetablerolewhere", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addeffortlessapiproject", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.geteffortlessapiprojects", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updateeffortlessapiproject", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deleteeffortlessapiproject", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.addcolumnrolecrud", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.getcolumnrolecruds", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.updatecolumnrolecrud", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.developer.deletecolumnrolecrud", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
    }
}

                    
