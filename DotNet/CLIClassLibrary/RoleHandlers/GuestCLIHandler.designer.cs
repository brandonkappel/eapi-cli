using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using EAPI.CLI.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class GuestCLIHandler
    {
        public override void AddHelp(StringBuilder sb, string helpTerm)
        {
            sb.AppendLine($"Help for Guest.");
            
            helpTerm = helpTerm.ToLower();
            var found = helpTerm == "general";
            
            if (helpTerm == "general")
            {
                sb.AppendLine();
                
                sb.AppendLine($"void: RequestToken");
                sb.AppendLine($"void: ValidateTemporaryAccessToken");
                sb.AppendLine($"void: WhoAmI");
                sb.AppendLine($"void: WhoAreYou");
                sb.AppendLine($"void: StoreTempFile");
                sb.AppendLine($"PlanProduct: GetPlanProducts");
                sb.AppendLine($"ServiceHostEndpoint: GetServiceHostEndpoints");
                sb.AppendLine($"EffortlessAPIService: GetEffortlessAPIServices");
                sb.AppendLine($"ServiceHostType: GetServiceHostTypes");
                sb.AppendLine($"ServiceProduct: GetServiceProducts");
                sb.AppendLine($"ServicePlan: GetServicePlans");
                sb.AppendLine($"SDKLanguage: GetSDKLanguages");                                            
            }
            
            sb.AppendLine($"{Environment.NewLine}Available Actions Matching: {helpTerm}");
            
            if ("requesttoken".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - RequestToken");
                if ("requesttoken".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintRequestTokenHelp(sb);
                }
                found = true;
            }
            if ("validatetemporaryaccesstoken".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - ValidateTemporaryAccessToken");
                if ("validatetemporaryaccesstoken".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintValidateTemporaryAccessTokenHelp(sb);
                }
                found = true;
            }
            if ("whoami".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - WhoAmI");
                if ("whoami".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintWhoAmIHelp(sb);
                }
                found = true;
            }
            if ("whoareyou".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - WhoAreYou");
                if ("whoareyou".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintWhoAreYouHelp(sb);
                }
                found = true;
            }
            if ("storetempfile".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - StoreTempFile");
                if ("storetempfile".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintStoreTempFileHelp(sb);
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
            if ("getservicehosttypes".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetServiceHostTypes");
                if ("getservicehosttypes".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetServiceHostTypesHelp(sb);
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
            if ("getsdklanguages".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetSDKLanguages");
                if ("getsdklanguages".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetSDKLanguagesHelp(sb);
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
            payload.MaxPages = 99;

            switch (invokeRequest.ToLower())
            {
                case "requesttoken":
                    this.SMQActor.RequestToken(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "validatetemporaryaccesstoken":
                    this.SMQActor.ValidateTemporaryAccessToken(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "whoami":
                    this.SMQActor.WhoAmI(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "whoareyou":
                    this.SMQActor.WhoAreYou(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "storetempfile":
                    this.SMQActor.StoreTempFile(payload, (reply, bdea) =>
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

                case "getservicehosttypes":
                    this.SMQActor.GetServiceHostTypes(payload, (reply, bdea) =>
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

                case "getsdklanguages":
                    this.SMQActor.GetSDKLanguages(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                default:
                    throw new Exception($"Invalid request: {invokeRequest}");
            }

            return result;
        }
        
        
        public void PrintRequestTokenHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintValidateTemporaryAccessTokenHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintWhoAmIHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintWhoAreYouHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintStoreTempFileHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintGetPlanProductsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: PlanProduct     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"R      - IsActive");
                    sb.AppendLine($"R      - IsIncludedByDefault");
                    sb.AppendLine($"R      - Max");
                    sb.AppendLine($"R      - Min");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                    sb.AppendLine($"R      - PlanDiscount");
                    sb.AppendLine($"R      - PlanPrice");
                    sb.AppendLine($"R      - ServicePlan");
                    sb.AppendLine($"R      - ServicePlanName");
                
            
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
                    sb.AppendLine($"R      - IsEC2");
                    sb.AppendLine($"R      - MaxCPU");
                    sb.AppendLine($"R      - MaxMemory");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                    sb.AppendLine($"R      - ProjectTasks");
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
                    sb.AppendLine($"R      - Attachments");
                    sb.AppendLine($"R      - DisplayName");
                    sb.AppendLine($"R      - IsActive");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                    sb.AppendLine($"R      - ServiceStatus");
                    sb.AppendLine($"R      - ServiceType");
                    sb.AppendLine($"R      - SortOrder");
                
            
        }
        
        public void PrintGetServiceHostTypesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ServiceHostType     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"R      - ServiceHostTypeId");
                    sb.AppendLine($"R      - Attachments");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                    sb.AppendLine($"R      - IsEAPIEndpoint");
                
            
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
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
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
                    sb.AppendLine($"R      - DisplayName");
                    sb.AppendLine($"R      - IsActive");
                    sb.AppendLine($"R      - IsDeveloperPlan");
                    sb.AppendLine($"R      - MonthlyPrice");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                    sb.AppendLine($"R      - ServicePlanProducts");
                    sb.AppendLine($"R      - SortOrder");
                
            
        }
        
        public void PrintGetSDKLanguagesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: SDKLanguage     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"R      - SDKLanguageId");
                    sb.AppendLine($"R      - Attachments");
                    sb.AppendLine($"R      - Name");
                    sb.AppendLine($"R      - Notes");
                
            
        }
        

    }
}
