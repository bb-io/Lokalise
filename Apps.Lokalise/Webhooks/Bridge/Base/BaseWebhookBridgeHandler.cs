﻿using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Webhooks.Bridge.Base.Models;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Lokalise.Webhooks.Bridge.Base
{
    public class BaseWebhookBridgeHandler : BaseInvocable, IWebhookEventHandler
    {
        private readonly string _bridgeServiceUrl;

        private string SubscriptionEvent { get; set; }

        protected readonly LokaliseClient Client;

        protected readonly string ProjectId;

        public BaseWebhookBridgeHandler(InvocationContext invocationContext, string subEvent, string projectId) : base(invocationContext)
        {
            SubscriptionEvent = subEvent;
            _bridgeServiceUrl = $"{invocationContext.UriInfo.BridgeServiceUrl.ToString().TrimEnd('/')}/webhooks/lokalise";
            Client = new LokaliseClient();
            this.ProjectId = projectId;
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            var logger = new WebLogger();
            logger.Log($"[BaseWebhookBridgeHandler.SubscribeAsync] Start subscription for event '{SubscriptionEvent}' on project '{ProjectId}'");



            //subscrive to bridge service
            var bridge = new BridgeService(authenticationCredentialsProvider, _bridgeServiceUrl);
            string eventType = SubscriptionEvent;
            bridge.Subscribe(eventType, ProjectId, values["payloadUrl"]);
            logger.Log($"[BaseWebhookBridgeHandler.SubscribeAsync] Bridge service subscription completed.");

            var lokaliseWebhookUrl = _bridgeServiceUrl;


            var getRequest = new LokaliseRequest($"/projects/{ProjectId}/webhooks", Method.Get, authenticationCredentialsProvider);
            var existingWebhooksResponse = await Client.ExecuteAsync<LokaliseWebhookResponseDto>(getRequest);

            var existingWebhooks = existingWebhooksResponse.Data?.Webhooks;
            bool alreadyExists = existingWebhooks.Any(w =>
                 w.Url == lokaliseWebhookUrl &&
                 w.Events != null &&
                 w.Events.Contains(SubscriptionEvent));

            logger.Log($"[BaseWebhookBridgeHandler.SubscribeAsync] Already exists: {alreadyExists}");


            if (alreadyExists)
            {
                return;
            }

            //subscribe to lokalise
            var createWebhookRequest = new CreateWebhookRequest(lokaliseWebhookUrl, new[] { SubscriptionEvent });
            var postRequest = new LokaliseRequest($"/projects/{ProjectId}/webhooks", Method.Post, authenticationCredentialsProvider)
                  .WithJsonBody(createWebhookRequest, null);

            await Client.ExecuteAsync(postRequest);
            logger.Log($"[BaseWebhookBridgeHandler.SubscribeAsync] Lokalise subscription completed.");

        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            var logger = new WebLogger();
            logger.Log($"[BaseWebhookBridgeHandler.UnsubscribeAsync] Start unsubscription for event '{SubscriptionEvent}' on project '{ProjectId}'");

            var bridge = new BridgeService(authenticationCredentialsProvider, _bridgeServiceUrl);
            bridge.Unsubscribe(SubscriptionEvent, ProjectId, values["payloadUrl"]);
        }
    }
}
