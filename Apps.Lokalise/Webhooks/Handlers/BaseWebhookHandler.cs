using Apps.Lokalise;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Webhooks;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using RestSharp;

namespace Apps.Localise.Webhooks.Handlers
{
    public class BaseWebhookHandler : IWebhookEventHandler<WebhookInput>
    {

        private string SubscriptionEvent;
        private readonly WebhookInput _webhookInput;

        public BaseWebhookHandler(string subEvent, [WebhookParameter] WebhookInput input)
        {
            SubscriptionEvent = subEvent;
            _webhookInput = input;
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{_webhookInput.ProjectId}/webhooks", Method.Post, authenticationCredentialsProvider);
            request.AddJsonBody(new
            {
                url = values["payloadUrl"],
                events = new[] { SubscriptionEvent }
            });
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                client.Execute(request);
            });
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            var client = new LokaliseClient();
            var getRequest = new LokaliseRequest($"/projects/{_webhookInput.ProjectId}/webhooks?limit=5000", Method.Post, authenticationCredentialsProvider);
            var webhooks = await client.GetAsync<WebhooksResponseWrapper>(getRequest);
            var webhook = webhooks?.Webhooks.FirstOrDefault(w => w.Url == values["payloadUrl"]);

            if (webhook != null)
            {
                var deleteRequest = new LokaliseRequest($"/projects/{_webhookInput.ProjectId}/webhooks/{webhook.WebhookId}", Method.Delete, authenticationCredentialsProvider);
                await client.ExecuteAsync(deleteRequest);
            }

            await Task.CompletedTask;
        }
    }
}
