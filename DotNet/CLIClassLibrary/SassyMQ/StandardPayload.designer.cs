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

        // 30 odxml properties
        
        ///<summary>
        /// List of EffortlessAPIProjects Identifier
        ///</summary>
        public String EffortlessAPIProjectId { get; set; }
        
        ///<summary>
        /// List of EffortlessAPIProjects
        ///</summary>
        public dc.EffortlessAPIProject EffortlessAPIProject { get; set; }
        
        ///<summary>
        /// List of EffortlessAPIProjects (LIST)
        ///</summary>
        public List<dc.EffortlessAPIProject> EffortlessAPIProjects { get; set; }
        
        ///<summary>
        /// List of ProjectTables Identifier
        ///</summary>
        public String ProjectTableId { get; set; }
        
        ///<summary>
        /// List of ProjectTables
        ///</summary>
        public dc.ProjectTable ProjectTable { get; set; }
        
        ///<summary>
        /// List of ProjectTables (LIST)
        ///</summary>
        public List<dc.ProjectTable> ProjectTables { get; set; }
        
        ///<summary>
        /// List of TableColumns Identifier
        ///</summary>
        public String TableColumnId { get; set; }
        
        ///<summary>
        /// List of TableColumns
        ///</summary>
        public dc.TableColumn TableColumn { get; set; }
        
        ///<summary>
        /// List of TableColumns (LIST)
        ///</summary>
        public List<dc.TableColumn> TableColumns { get; set; }
        
        ///<summary>
        /// List of TableRoleWheres Identifier
        ///</summary>
        public String TableRoleWhereId { get; set; }
        
        ///<summary>
        /// List of TableRoleWheres
        ///</summary>
        public dc.TableRoleWhere TableRoleWhere { get; set; }
        
        ///<summary>
        /// List of TableRoleWheres (LIST)
        ///</summary>
        public List<dc.TableRoleWhere> TableRoleWheres { get; set; }
        
        ///<summary>
        /// List of ColumnRoleCRUDs Identifier
        ///</summary>
        public String ColumnRoleCRUDId { get; set; }
        
        ///<summary>
        /// List of ColumnRoleCRUDs
        ///</summary>
        public dc.ColumnRoleCRUD ColumnRoleCRUD { get; set; }
        
        ///<summary>
        /// List of ColumnRoleCRUDs (LIST)
        ///</summary>
        public List<dc.ColumnRoleCRUD> ColumnRoleCRUDs { get; set; }
        
        ///<summary>
        /// List of ProjectRoles Identifier
        ///</summary>
        public String ProjectRoleId { get; set; }
        
        ///<summary>
        /// List of ProjectRoles
        ///</summary>
        public dc.ProjectRole ProjectRole { get; set; }
        
        ///<summary>
        /// List of ProjectRoles (LIST)
        ///</summary>
        public List<dc.ProjectRole> ProjectRoles { get; set; }
        
        ///<summary>
        /// List of ProxyRelativeUrls Identifier
        ///</summary>
        public String ProxyRelativeUrlId { get; set; }
        
        ///<summary>
        /// List of ProxyRelativeUrls
        ///</summary>
        public dc.ProxyRelativeUrl ProxyRelativeUrl { get; set; }
        
        ///<summary>
        /// List of ProxyRelativeUrls (LIST)
        ///</summary>
        public List<dc.ProxyRelativeUrl> ProxyRelativeUrls { get; set; }
        
        ///<summary>
        /// List of ProjectStages Identifier
        ///</summary>
        public String ProjectStageId { get; set; }
        
        ///<summary>
        /// List of ProjectStages
        ///</summary>
        public dc.ProjectStage ProjectStage { get; set; }
        
        ///<summary>
        /// List of ProjectStages (LIST)
        ///</summary>
        public List<dc.ProjectStage> ProjectStages { get; set; }
        
        ///<summary>
        /// List of RemoteEndpoints Identifier
        ///</summary>
        public String RemoteEndpointId { get; set; }
        
        ///<summary>
        /// List of RemoteEndpoints
        ///</summary>
        public dc.RemoteEndpoint RemoteEndpoint { get; set; }
        
        ///<summary>
        /// List of RemoteEndpoints (LIST)
        ///</summary>
        public List<dc.RemoteEndpoint> RemoteEndpoints { get; set; }
        
        ///<summary>
        /// List of ServiceHostSizes Identifier
        ///</summary>
        public String ServiceHostSizeId { get; set; }
        
        ///<summary>
        /// List of ServiceHostSizes
        ///</summary>
        public dc.ServiceHostSize ServiceHostSize { get; set; }
        
        ///<summary>
        /// List of ServiceHostSizes (LIST)
        ///</summary>
        public List<dc.ServiceHostSize> ServiceHostSizes { get; set; }
        
        ///<summary>
        /// List of ProjectEmails Identifier
        ///</summary>
        public String ProjectEmailId { get; set; }
        
        ///<summary>
        /// List of ProjectEmails
        ///</summary>
        public dc.ProjectEmail ProjectEmail { get; set; }
        
        ///<summary>
        /// List of ProjectEmails (LIST)
        ///</summary>
        public List<dc.ProjectEmail> ProjectEmails { get; set; }
        
        ///<summary>
        /// List of ProjectVersionBuilds Identifier
        ///</summary>
        public String ProjectVersionBuildId { get; set; }
        
        ///<summary>
        /// List of ProjectVersionBuilds
        ///</summary>
        public dc.ProjectVersionBuild ProjectVersionBuild { get; set; }
        
        ///<summary>
        /// List of ProjectVersionBuilds (LIST)
        ///</summary>
        public List<dc.ProjectVersionBuild> ProjectVersionBuilds { get; set; }
        
        ///<summary>
        /// List of ServiceHostEndpoints Identifier
        ///</summary>
        public String ServiceHostEndpointId { get; set; }
        
        ///<summary>
        /// List of ServiceHostEndpoints
        ///</summary>
        public dc.ServiceHostEndpoint ServiceHostEndpoint { get; set; }
        
        ///<summary>
        /// List of ServiceHostEndpoints (LIST)
        ///</summary>
        public List<dc.ServiceHostEndpoint> ServiceHostEndpoints { get; set; }
        
        ///<summary>
        /// List of ProjectLexiconTerms Identifier
        ///</summary>
        public String ProjectLexiconTermId { get; set; }
        
        ///<summary>
        /// List of ProjectLexiconTerms
        ///</summary>
        public dc.ProjectLexiconTerm ProjectLexiconTerm { get; set; }
        
        ///<summary>
        /// List of ProjectLexiconTerms (LIST)
        ///</summary>
        public List<dc.ProjectLexiconTerm> ProjectLexiconTerms { get; set; }
        
        ///<summary>
        /// List of ServiceHostTypes Identifier
        ///</summary>
        public String ServiceHostTypeId { get; set; }
        
        ///<summary>
        /// List of ServiceHostTypes
        ///</summary>
        public dc.ServiceHostType ServiceHostType { get; set; }
        
        ///<summary>
        /// List of ServiceHostTypes (LIST)
        ///</summary>
        public List<dc.ServiceHostType> ServiceHostTypes { get; set; }
        
        ///<summary>
        /// List of ProjectVersions Identifier
        ///</summary>
        public String ProjectVersionId { get; set; }
        
        ///<summary>
        /// List of ProjectVersions
        ///</summary>
        public dc.ProjectVersion ProjectVersion { get; set; }
        
        ///<summary>
        /// List of ProjectVersions (LIST)
        ///</summary>
        public List<dc.ProjectVersion> ProjectVersions { get; set; }
        
        ///<summary>
        /// List of ProjectRequestSummaries Identifier
        ///</summary>
        public String ProjectRequestSummaryId { get; set; }
        
        ///<summary>
        /// List of ProjectRequestSummaries
        ///</summary>
        public dc.ProjectRequestSummary ProjectRequestSummary { get; set; }
        
        ///<summary>
        /// List of ProjectRequestSummaries (LIST)
        ///</summary>
        public List<dc.ProjectRequestSummary> ProjectRequestSummaries { get; set; }
        
        ///<summary>
        /// List of ProjectConnections Identifier
        ///</summary>
        public String ProjectConnectionId { get; set; }
        
        ///<summary>
        /// List of ProjectConnections
        ///</summary>
        public dc.ProjectConnection ProjectConnection { get; set; }
        
        ///<summary>
        /// List of ProjectConnections (LIST)
        ///</summary>
        public List<dc.ProjectConnection> ProjectConnections { get; set; }
        
        ///<summary>
        /// List of ProjectIcons Identifier
        ///</summary>
        public String ProjectIconId { get; set; }
        
        ///<summary>
        /// List of ProjectIcons
        ///</summary>
        public dc.ProjectIcon ProjectIcon { get; set; }
        
        ///<summary>
        /// List of ProjectIcons (LIST)
        ///</summary>
        public List<dc.ProjectIcon> ProjectIcons { get; set; }
        
        ///<summary>
        /// List of PortfolioItems_RETIRED Identifier
        ///</summary>
        public String PortfolioItem_RETIREDId { get; set; }
        
        ///<summary>
        /// List of PortfolioItems_RETIRED
        ///</summary>
        public dc.PortfolioItem_RETIRED PortfolioItem_RETIRED { get; set; }
        
        ///<summary>
        /// List of PortfolioItems_RETIRED (LIST)
        ///</summary>
        public List<dc.PortfolioItem_RETIRED> PortfolioItems_RETIRED { get; set; }
        
        ///<summary>
        /// List of ServiceKeys Identifier
        ///</summary>
        public String ServiceKeyId { get; set; }
        
        ///<summary>
        /// List of ServiceKeys
        ///</summary>
        public dc.ServiceKey ServiceKey { get; set; }
        
        ///<summary>
        /// List of ServiceKeys (LIST)
        ///</summary>
        public List<dc.ServiceKey> ServiceKeys { get; set; }
        
        ///<summary>
        /// List of EffortlessAPIAccounts Identifier
        ///</summary>
        public String EffortlessAPIAccountId { get; set; }
        
        ///<summary>
        /// List of EffortlessAPIAccounts
        ///</summary>
        public dc.EffortlessAPIAccount EffortlessAPIAccount { get; set; }
        
        ///<summary>
        /// List of EffortlessAPIAccounts (LIST)
        ///</summary>
        public List<dc.EffortlessAPIAccount> EffortlessAPIAccounts { get; set; }
        
        ///<summary>
        /// List of PlanProducts Identifier
        ///</summary>
        public String PlanProductId { get; set; }
        
        ///<summary>
        /// List of PlanProducts
        ///</summary>
        public dc.PlanProduct PlanProduct { get; set; }
        
        ///<summary>
        /// List of PlanProducts (LIST)
        ///</summary>
        public List<dc.PlanProduct> PlanProducts { get; set; }
        
        ///<summary>
        /// List of Portfolios_RETIRED Identifier
        ///</summary>
        public String Portfolio_RETIREDId { get; set; }
        
        ///<summary>
        /// List of Portfolios_RETIRED
        ///</summary>
        public dc.Portfolio_RETIRED Portfolio_RETIRED { get; set; }
        
        ///<summary>
        /// List of Portfolios_RETIRED (LIST)
        ///</summary>
        public List<dc.Portfolio_RETIRED> Portfolios_RETIRED { get; set; }
        
        ///<summary>
        /// List of ServicePlans Identifier
        ///</summary>
        public String ServicePlanId { get; set; }
        
        ///<summary>
        /// List of ServicePlans
        ///</summary>
        public dc.ServicePlan ServicePlan { get; set; }
        
        ///<summary>
        /// List of ServicePlans (LIST)
        ///</summary>
        public List<dc.ServicePlan> ServicePlans { get; set; }
        
        ///<summary>
        /// List of ServiceProducts Identifier
        ///</summary>
        public String ServiceProductId { get; set; }
        
        ///<summary>
        /// List of ServiceProducts
        ///</summary>
        public dc.ServiceProduct ServiceProduct { get; set; }
        
        ///<summary>
        /// List of ServiceProducts (LIST)
        ///</summary>
        public List<dc.ServiceProduct> ServiceProducts { get; set; }
        
        ///<summary>
        /// List of SDKLanguages Identifier
        ///</summary>
        public String SDKLanguageId { get; set; }
        
        ///<summary>
        /// List of SDKLanguages
        ///</summary>
        public dc.SDKLanguage SDKLanguage { get; set; }
        
        ///<summary>
        /// List of SDKLanguages (LIST)
        ///</summary>
        public List<dc.SDKLanguage> SDKLanguages { get; set; }
        
        ///<summary>
        /// List of EffortlessAPIServices Identifier
        ///</summary>
        public String EffortlessAPIServiceId { get; set; }
        
        ///<summary>
        /// List of EffortlessAPIServices
        ///</summary>
        public dc.EffortlessAPIService EffortlessAPIService { get; set; }
        
        ///<summary>
        /// List of EffortlessAPIServices (LIST)
        ///</summary>
        public List<dc.EffortlessAPIService> EffortlessAPIServices { get; set; }
        
        ///<summary>
        /// List of ColumnValues Identifier
        ///</summary>
        public String ColumnValueId { get; set; }
        
        ///<summary>
        /// List of ColumnValues
        ///</summary>
        public dc.ColumnValue ColumnValue { get; set; }
        
        ///<summary>
        /// List of ColumnValues (LIST)
        ///</summary>
        public List<dc.ColumnValue> ColumnValues { get; set; }
        
        ///<summary>
        /// List of CustomerTypes Identifier
        ///</summary>
        public String CustomerTypeId { get; set; }
        
        ///<summary>
        /// List of CustomerTypes
        ///</summary>
        public dc.CustomerType CustomerType { get; set; }
        
        ///<summary>
        /// List of CustomerTypes (LIST)
        ///</summary>
        public List<dc.CustomerType> CustomerTypes { get; set; }
        
        
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
                var waitTask = System.Threading.Tasks.Task.Factory.StartNew(() =>
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