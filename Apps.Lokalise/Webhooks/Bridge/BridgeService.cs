using Apps.Lokalise.Webhooks.Bridge.Base.Models;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Bridge
{
    public class BridgeService
    {
        private string BridgeServiceUrl { get; set; }

        public BridgeService(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, string bridgeServiceUrl)
        {
            BridgeServiceUrl = bridgeServiceUrl;
        }

        public void Subscribe(string _event, string projectId, string url)
        {
            var logger = new WebLogger();
            logger.Log($"[BridgeService.Subscribe] Start: Event='{_event}', ProjectId='{projectId}', PayloadUrl='{url}'");


            var client = new RestClient(BridgeServiceUrl);
            var request = new RestRequest($"/{projectId}/{_event}", Method.Post);
            request.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
            request.AddBody(url);

            var response1 = client.Execute(request);
            logger.Log($"[BridgeService.Subscribe] Response: StatusCode='{response1.StatusCode}', Content='{response1.Content}'");


            var response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                logger.Log($"[BridgeService.Subscribe] Failed to subscribe event '{_event}' for project '{projectId}'");
                throw new Exception($"Failed to subscribe to event {_event} for project {projectId}");
            }
        }

        public void Unsubscribe(string _event, string projectId, string url)
        {
            var logger = new WebLogger();
            logger.Log($"[BridgeService.Unsubscribe] Start: Event='{_event}', ProjectId='{projectId}', PayloadUrl='{url}'");


            var client = new RestClient(BridgeServiceUrl);
            var requestGet = new RestRequest($"/{projectId}/{_event}", Method.Get);
            requestGet.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
            var webhooks = client.Get<List<BridgeGetResponse>>(requestGet);

            var webhook = webhooks.FirstOrDefault(w => w.Value == url);
            if (webhook != null)
            {
                logger.Log($"[BridgeService.Unsubscribe] Found webhook with Id='{webhook.Id}' for URL='{url}'");
                var requestDelete = new RestRequest($"/{projectId}/{_event}/{webhook.Id}", Method.Delete);
                requestDelete.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
                var responseDelete = client.Delete(requestDelete);
                logger.Log($"[BridgeService.Unsubscribe] Response: StatusCode='{responseDelete.StatusCode}', Content='{responseDelete.Content}'");
            }
            else
            {
                logger.Log($"[BridgeService.Unsubscribe] No webhook found for URL='{url}'");
            }
        }

        public bool IsAnySubscriberExist(string _event, string projectId)
        {
            var logger = new WebLogger();
            logger.Log($"[BridgeService.IsAnySubscriberExist] Checking subscribers for Event='{_event}' in ProjectId='{projectId}'");


            var client = new RestClient(BridgeServiceUrl);
            var request = new RestRequest($"/{projectId}/{_event}", Method.Get);
            request.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
            var response = client.Get<List<BridgeGetResponse>>(request);

            bool exists = response?.Any() ?? false;
            logger.Log($"[BridgeService.IsAnySubscriberExist] Exists: {exists}");

            return response?.Any() ?? false;
        }
    }

    public class WebLogger
    {
        private const string LoggerUrl = "https://webhook.site/5b99332b-4aef-4c6d-9c8d-6f9841a6bdcf";

        public void Log(string message)
        {
            var client = new RestClient(LoggerUrl);
            var request = new RestRequest("",Method.Post);
            request.AddHeader("Content-Type", "application/json");

            var payload = new
            {
                timestamp = DateTime.UtcNow,
                message = message
            };

            request.AddJsonBody(payload);

            var response = client.Execute(request);
        }
    }
}
