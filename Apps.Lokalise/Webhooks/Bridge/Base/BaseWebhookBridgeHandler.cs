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
            //subscribe to bridge service
            var bridge = new BridgeService(authenticationCredentialsProvider, _bridgeServiceUrl);
            string eventType = SubscriptionEvent;
            bridge.Subscribe(eventType, ProjectId, values["payloadUrl"]);

            var lokaliseWebhookUrl = _bridgeServiceUrl;

            var getRequest = new LokaliseRequest($"/projects/{ProjectId}/webhooks", Method.Get, authenticationCredentialsProvider);
            var existingWebhooksResponse = await Client.ExecuteAsync<LokaliseWebhookResponseDto>(getRequest);

            var existingWebhooks = existingWebhooksResponse.Data?.Webhooks;
            bool alreadyExists = existingWebhooks.Any(w =>
                 w.Url == lokaliseWebhookUrl &&
                 w.Events != null &&
                 w.Events.Contains(SubscriptionEvent));


            if (alreadyExists)
            {
                return;
            }

            //subscribe to lokalise
            var createWebhookRequest = new CreateWebhookRequest(lokaliseWebhookUrl, new[] { SubscriptionEvent });
            var postRequest = new LokaliseRequest($"/projects/{ProjectId}/webhooks", Method.Post, authenticationCredentialsProvider)
                  .WithJsonBody(createWebhookRequest, null);

            await Client.ExecuteAsync(postRequest);
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            var bridge = new BridgeService(authenticationCredentialsProvider, _bridgeServiceUrl);
            bridge.Unsubscribe(SubscriptionEvent, ProjectId, values["payloadUrl"]);
        }
    }
}
