//using Apps.Lokalise.Webhooks.Bridge.Base.Models;
//using Apps.Lokalise.Webhooks.Bridge.Handlers;
//using Apps.Lokalise.Webhooks.Models.Payload;
//using Blackbird.Applications.Sdk.Common.Webhooks;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace Apps.Lokalise.Webhooks.Bridge
//{
//    [WebhookList]
//    public class WebhookList
//    {
//        [Webhook("[Bridge] On key added", typeof(ProjectKeyAddedHandler))]
//        public async Task<WebhookResponse<ProjectKeyAddedPayload>> OnProjectKeyAdded(WebhookRequest webhookRequest, [WebhookParameter] ProjectInputOption projectInfo)
//        {
//            var root = GetPayload<ProjectKeyAddedPayload>(webhookRequest);

//            if (projectInfo.ProjectId != null && root.Project.Id != projectInfo.ProjectId)
//                return GetPreflightResponse<ProjectKeyAddedPayload>();

//            return new WebhookResponse<ProjectKeyAddedPayload>()
//            {
//                Result = root
//            };
//        }

//        [Webhook("[Bridge] On project imported", typeof(ProjectImportedHandler))]
//        public async Task<WebhookResponse<ProjectImportedPayload>> OnProjectImprorted(WebhookRequest webhookRequest, [WebhookParameter] ProjectInputOption projectInfo)
//        {
//            var root = GetPayload<ProjectImportedPayload>(webhookRequest);

//            if (projectInfo.ProjectId != null && root.Project.Id != projectInfo.ProjectId)
//                return GetPreflightResponse<ProjectImportedPayload>();

//            return new WebhookResponse<ProjectImportedPayload>()
//            {
//                Result = root
//            };
//        }

//        [Webhook("[Bridge] On project exported", typeof(ProjectImportedHandler))]
//        public async Task<WebhookResponse<>> OnProjectExported(WebhookRequest webhookRequest, [WebhookParameter] ProjectInputOption projectInfo)
//        {
//            var root = GetPayload<ProjectExportedPayload>(webhookRequest);

//            if (projectInfo.ProjectId != null && root.Project.Id != projectInfo.ProjectId)
//                return GetPreflightResponse<ProjectExportedPayload>();

//            return new WebhookResponse<ProjectExportedPayload>()
//            {
//                Result = root
//            };
//        }


//        private T GetPayload<T>(WebhookRequest webhookRequest) where T : class
//        {
//            var payload = webhookRequest.Body.ToString();
//            ArgumentException.ThrowIfNullOrEmpty(payload, nameof(webhookRequest.Body));

//            return JsonConvert.DeserializeObject<T>(payload)!;
//        }

//        private WebhookResponse<T> GetPreflightResponse<T>() where T : class => new()
//        {
//            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
//            ReceivedWebhookRequestType = WebhookRequestType.Preflight
//        };
//    }
//}
