using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using dc = EAPI.CLI.Lib.DataClasses;
using System.Collections.Generic;


namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class StandardPayload
    {
        public string RoutingKey { get; set; }
        
        private StandardPayload(SMQActorBase actor, string content, bool final)
        {
            this.PayloadId = Guid.NewGuid().ToString();

            this.__Actor = actor;
            if (!ReferenceEquals(this.__Actor, null))
            {
                this.SenderId = actor.SenderId.ToString();
                this.SenderName = actor.SenderName;
                this.AccessToken = actor.AccessToken;
            }
            else
            {
                this.SenderId = Guid.NewGuid().ToString();
                this.SenderName = "Unnamed Actor";
                this.AccessToken = null;
            }

            this.Content = content;
        }

        // 29 odxml properties
        
        public String ColumnValueId { get; set; }
        
        public dc.ColumnValue ColumnValue { get; set; }
        
        public List<dc.ColumnValue> ColumnValues { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String RemoteEndpointId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.RemoteEndpoint RemoteEndpoint { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.RemoteEndpoint> RemoteEndpoints { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ServiceHostSizeId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ServiceHostSize ServiceHostSize { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ServiceHostSize> ServiceHostSizes { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ServiceHostTypeId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ServiceHostType ServiceHostType { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ServiceHostType> ServiceHostTypes { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ColumnRoleCRUDId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ColumnRoleCRUD ColumnRoleCRUD { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ColumnRoleCRUD> ColumnRoleCRUDs { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProxyRelativeUrlId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProxyRelativeUrl ProxyRelativeUrl { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProxyRelativeUrl> ProxyRelativeUrls { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String TableRoleWhereId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.TableRoleWhere TableRoleWhere { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.TableRoleWhere> TableRoleWheres { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String TableColumnId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.TableColumn TableColumn { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.TableColumn> TableColumns { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProjectTableId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProjectTable ProjectTable { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProjectTable> ProjectTables { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProjectVersionBuildId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProjectVersionBuild ProjectVersionBuild { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProjectVersionBuild> ProjectVersionBuilds { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProjectRoleId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProjectRole ProjectRole { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProjectRole> ProjectRoles { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ServiceHostEndpointId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ServiceHostEndpoint ServiceHostEndpoint { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ServiceHostEndpoint> ServiceHostEndpoints { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProjectStageId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProjectStage ProjectStage { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProjectStage> ProjectStages { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProjectLexiconTermId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProjectLexiconTerm ProjectLexiconTerm { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProjectLexiconTerm> ProjectLexiconTerms { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProjectEmailId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProjectEmail ProjectEmail { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProjectEmail> ProjectEmails { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProjectVersionId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProjectVersion ProjectVersion { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProjectVersion> ProjectVersions { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String EffortlessAPIProjectId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.EffortlessAPIProject EffortlessAPIProject { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.EffortlessAPIProject> EffortlessAPIProjects { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProjectRequestSummaryId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProjectRequestSummary ProjectRequestSummary { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProjectRequestSummary> ProjectRequestSummaries { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProjectConnectionId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProjectConnection ProjectConnection { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProjectConnection> ProjectConnections { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ProjectIconId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ProjectIcon ProjectIcon { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ProjectIcon> ProjectIcons { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String PortfolioItemId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.PortfolioItem PortfolioItem { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.PortfolioItem> PortfolioItems { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ServiceKeyId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ServiceKey ServiceKey { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ServiceKey> ServiceKeys { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String EffortlessAPIAccountId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.EffortlessAPIAccount EffortlessAPIAccount { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.EffortlessAPIAccount> EffortlessAPIAccounts { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String PlanProductId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.PlanProduct PlanProduct { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.PlanProduct> PlanProducts { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String PortfolioId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.Portfolio Portfolio { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.Portfolio> Portfolios { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ServicePlanId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ServicePlan ServicePlan { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ServicePlan> ServicePlans { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String ServiceProductId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.ServiceProduct ServiceProduct { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.ServiceProduct> ServiceProducts { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String SDKLanguageId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.SDKLanguage SDKLanguage { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.SDKLanguage> SDKLanguages { get; set; }
        
        ///<summary>
        /// No table description. Identifier
        ///</summary>
        public String EffortlessAPIServiceId { get; set; }
        
        ///<summary>
        /// No table description.
        ///</summary>
        public dc.EffortlessAPIService EffortlessAPIService { get; set; }
        
        ///<summary>
        /// No table description. (LIST)
        ///</summary>
        public List<dc.EffortlessAPIService> EffortlessAPIServices { get; set; }
        
        
        public String ToJSON() 
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        private void HandleReplyTo(object sender, PayloadEventArgs e)
        {
            if (e.Payload.IsHandled && e.BasicDeliverEventArgs.BasicProperties.CorrelationId == this.PayloadId)
            {
                this.ReplyPayload = e.Payload;
                this.ReplyBDEA = e.BasicDeliverEventArgs;
                this.ReplyRecieved = true;
            }
        }

       
        public Task WaitForReply(PayloadHandler payloadHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var actor = this.__Actor;
            if (ReferenceEquals(actor, null)) throw new Exception("Can't handle response if payload.Actor is null");
            else
            {
                actor.ReplyTo += this.HandleReplyTo;
                var waitTask = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        if (waitTimeout > 0 && !ReferenceEquals(payloadHandler, null))
                        {

                            this.TimedOutWaiting = false;
                            var startedAt = DateTime.Now;

                            while (!this.ReplyRecieved && !this.TimedOutWaiting && DateTime.Now < startedAt.AddSeconds(waitTimeout))
                            {
                                Thread.Sleep(100);
                            }

                            if (!this.ReplyRecieved) this.TimedOutWaiting = true;

                            var errorMessageReceived = !ReferenceEquals(this.ReplyPayload, null) && !String.IsNullOrEmpty(this.ReplyPayload.ErrorMessage);

                            if (this.ReplyRecieved && (!errorMessageReceived || ReferenceEquals(timeoutHandler, null)))
                            {
                                this.ReplyPayload.__Actor = actor;
                                payloadHandler(this.ReplyPayload, this.ReplyBDEA);
                            }
                            else if (!ReferenceEquals(timeoutHandler, null)) timeoutHandler(this.ReplyPayload, default(BasicDeliverEventArgs));
                        }

                    }
                    finally
                    {
                        actor.ReplyTo -= this.HandleReplyTo;
                    }
                });
                return waitTask;
            }
        }
    }
}