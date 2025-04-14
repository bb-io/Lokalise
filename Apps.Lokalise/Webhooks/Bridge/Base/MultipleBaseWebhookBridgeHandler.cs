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
    public class MultipleBaseWebhookBridgeHandler : BaseInvocable, IWebhookEventHandler
    {
        private readonly string _bridgeServiceUrl;
        private readonly IEnumerable<string> SubscriptionEvents;
        private readonly IEnumerable<string> ProjectIds;

        protected readonly LokaliseClient Client;

        public MultipleBaseWebhookBridgeHandler(
            InvocationContext invocationContext,
            IEnumerable<string> subscriptionEvents,
            IEnumerable<string> projectIds) : base(invocationContext)
        {
            SubscriptionEvents = subscriptionEvents.ToList();
            ProjectIds = projectIds.ToList();
            _bridgeServiceUrl = $"{invocationContext.UriInfo.BridgeServiceUrl.ToString().TrimEnd('/')}/webhooks/lokalise";
            Client = new LokaliseClient();
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            var logger = new WebLogger();
            foreach (var projectId in ProjectIds)
            {
                foreach (var eventType in SubscriptionEvents)
                {
                    logger.Log($"[MultipleBaseWebhookBridgeHandler.SubscribeAsync] Start subscription for event '{eventType}' on project '{projectId}'");

                    var bridge = new BridgeService(authenticationCredentialsProvider, _bridgeServiceUrl);
                    bridge.Subscribe(eventType, projectId, values["payloadUrl"]);

                    var lokaliseWebhookUrl = _bridgeServiceUrl;

                    var getRequest = new LokaliseRequest($"/projects/{projectId}/webhooks", Method.Get, authenticationCredentialsProvider);
                    var existingWebhooksResponse = await Client.ExecuteAsync<LokaliseWebhookResponseDto>(getRequest);
                    var existingWebhooks = existingWebhooksResponse.Data?.Webhooks;
                    bool alreadyExists = existingWebhooks.Any(w =>
                         w.Url == lokaliseWebhookUrl &&
                         w.Events != null &&
                         w.Events.Contains(eventType));

                    logger.Log($"[MultipleBaseWebhookBridgeHandler.SubscribeAsync] For event '{eventType}' on project '{projectId}' already exists: {alreadyExists}");

                    if (alreadyExists)
                        continue;

                    var createWebhookRequest = new CreateWebhookRequest(lokaliseWebhookUrl, new[] { eventType });
                    var postRequest = new LokaliseRequest($"/projects/{projectId}/webhooks", Method.Post, authenticationCredentialsProvider)
                          .WithJsonBody(createWebhookRequest, null);

                    await Client.ExecuteAsync(postRequest);
                    logger.Log($"[MultipleBaseWebhookBridgeHandler.SubscribeAsync] Lokalise subscription completed for event '{eventType}' on project '{projectId}'.");
                }
            }
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            var logger = new WebLogger();
            foreach (var projectId in ProjectIds)
            {
                foreach (var eventType in SubscriptionEvents)
                {
                    logger.Log($"[MultipleBaseWebhookBridgeHandler.UnsubscribeAsync] Start unsubscription for event '{eventType}' on project '{projectId}'");

                    var bridge = new BridgeService(authenticationCredentialsProvider, _bridgeServiceUrl);
                    bridge.Unsubscribe(eventType, projectId, values["payloadUrl"]);

                    logger.Log($"[MultipleBaseWebhookBridgeHandler.UnsubscribeAsync] Unsubscription completed for event '{eventType}' on project '{projectId}'.");
                }
            }
        }
    }
}
