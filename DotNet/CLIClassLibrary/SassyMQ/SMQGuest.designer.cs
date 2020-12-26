using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQGuest : SMQActorBase
    {

        public SMQGuest(String amqpConnectionString)
            : base(amqpConnectionString, "guest")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            var originalAccessToken = payload.AccessToken;
            try
            {
                switch (bdea.RoutingKey)
                {
                    
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
        /// RequestToken - 
        /// </summary>
        public Task RequestToken(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.RequestToken(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// RequestToken - 
        /// </summary>
        public Task RequestToken(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.RequestToken(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// RequestToken - 
        /// </summary>
        public Task RequestToken(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.guest.requesttoken", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// ValidateTemporaryAccessToken - 
        /// </summary>
        public Task ValidateTemporaryAccessToken(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ValidateTemporaryAccessToken(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ValidateTemporaryAccessToken - 
        /// </summary>
        public Task ValidateTemporaryAccessToken(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ValidateTemporaryAccessToken(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// ValidateTemporaryAccessToken - 
        /// </summary>
        public Task ValidateTemporaryAccessToken(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.guest.validatetemporaryaccesstoken", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// WhoAmI - 
        /// </summary>
        public Task WhoAmI(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.WhoAmI(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// WhoAmI - 
        /// </summary>
        public Task WhoAmI(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.WhoAmI(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// WhoAmI - 
        /// </summary>
        public Task WhoAmI(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.guest.whoami", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// WhoAreYou - 
        /// </summary>
        public Task WhoAreYou(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.WhoAreYou(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// WhoAreYou - 
        /// </summary>
        public Task WhoAreYou(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.WhoAreYou(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// WhoAreYou - 
        /// </summary>
        public Task WhoAreYou(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.guest.whoareyou", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// StoreTempFile - 
        /// </summary>
        public Task StoreTempFile(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.StoreTempFile(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// StoreTempFile - 
        /// </summary>
        public Task StoreTempFile(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.StoreTempFile(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// StoreTempFile - 
        /// </summary>
        public Task StoreTempFile(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.utlity.guest.storetempfile", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.guest.getplanproducts", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.guest.getservicehostendpoints", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.guest.geteffortlessapiservices", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.guest.getservicehosttypes", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.guest.getserviceproducts", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.guest.getserviceplans", payload, replyHandler, timeoutHandler, waitTimeout);
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
            return this.SendMessage("crudcoordinator.crud.guest.getsdklanguages", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
    }
}

                    
