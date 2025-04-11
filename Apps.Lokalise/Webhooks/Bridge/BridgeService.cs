﻿using Apps.Lokalise.Webhooks.Bridge.Base.Models;
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
            var client = new RestClient(BridgeServiceUrl);
            var request = new RestRequest($"/{projectId}/{_event}", Method.Post);
            request.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
            request.AddBody(url);

            var response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to subscribe to event {_event} for project {projectId}");
            }
        }

        public void Unsubscribe(string _event, string projectId, string url)
        {
            var client = new RestClient(BridgeServiceUrl);
            var requestGet = new RestRequest($"/{projectId}/{_event}", Method.Get);
            requestGet.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
            var webhooks = client.Get<List<BridgeGetResponse>>(requestGet);
            var webhook = webhooks.FirstOrDefault(w => w.Value == url);

            var requestDelete = new RestRequest($"/{projectId}/{_event}/{webhook.Id}", Method.Delete);
            requestDelete.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
            client.Delete(requestDelete);
        }

        public bool IsAnySubscriberExist(string _event, string projectId)
        {
            var client = new RestClient(BridgeServiceUrl);
            var request = new RestRequest($"/{projectId}/{_event}", Method.Get);
            request.AddHeader("Blackbird-Token", ApplicationConstants.BlackbirdToken);
            var response = client.Get<List<BridgeGetResponse>>(request);
            return response?.Any() ?? false;
        }
    }
}
