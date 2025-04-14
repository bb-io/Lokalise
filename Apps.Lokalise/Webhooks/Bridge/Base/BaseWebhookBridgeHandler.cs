using Apps.Lokalise.RestSharp;
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

        protected readonly IEnumerable<string> ProjectIds;

        public BaseWebhookBridgeHandler(InvocationContext invocationContext, string subEvent, IEnumerable<string> projectIds) : base(invocationContext)
        {
            SubscriptionEvent = subEvent;
            _bridgeServiceUrl = $"{invocationContext.UriInfo.BridgeServiceUrl.ToString().TrimEnd('/')}/webhooks/lokalise";
            Client = new LokaliseClient();
            ProjectIds = projectIds;
        }

        public async Task SubscribeAsync(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            foreach (var projectId in ProjectIds)
            {
                var bridge = new BridgeService(authenticationCredentialsProvider, _bridgeServiceUrl);
                bridge.Subscribe(SubscriptionEvent, projectId, values["payloadUrl"]);

                var lokaliseWebhookUrl = _bridgeServiceUrl;
                var getRequest = new LokaliseRequest($"/projects/{projectId}/webhooks", Method.Get, authenticationCredentialsProvider);
                var existingWebhooksResponse = await Client.ExecuteAsync<LokaliseWebhookResponseDto>(getRequest);
                var existingWebhooks = existingWebhooksResponse.Data?.Webhooks;
                bool alreadyExists = existingWebhooks.Any(w =>
                    w.Url == lokaliseWebhookUrl &&
                    w.Events != null &&
                    w.Events.Contains(SubscriptionEvent));

                if (alreadyExists)
                {
                    continue;
                }

                var createWebhookRequest = new CreateWebhookRequest(lokaliseWebhookUrl, new[] { SubscriptionEvent });
                var postRequest = new LokaliseRequest($"/projects/{projectId}/webhooks", Method.Post, authenticationCredentialsProvider)
                    .WithJsonBody(createWebhookRequest, null);
                await Client.ExecuteAsync(postRequest);
            }
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            foreach (var projectId in ProjectIds)
            {
                var bridge = new BridgeService(authenticationCredentialsProvider, _bridgeServiceUrl);
                bridge.Unsubscribe(SubscriptionEvent, projectId, values["payloadUrl"]);
            }
        }
    }
}
