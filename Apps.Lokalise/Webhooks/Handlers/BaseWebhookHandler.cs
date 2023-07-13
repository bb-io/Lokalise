using Apps.Lokalise.Dtos;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using RestSharp;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class BaseWebhookHandler : IWebhookEventHandler
    {
        #region Fields

        private string SubscriptionEvent;
        private readonly LokaliseClient _client;

        #endregion

        #region Constructors

        public BaseWebhookHandler(string subEvent)
        {
            SubscriptionEvent = subEvent;
            _client = new();
        }

        #endregion

        #region Subscriptions

        public Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            var endpoint = $"/projects/{values["projectIdForWebhooks"]}/webhooks";
            var request = new LokaliseRequest(endpoint, Method.Post, authenticationCredentialsProvider)
                .WithJsonBody(new
                {
                    url = values["payloadUrl"],
                    events = new[] { SubscriptionEvent }
                });

            return Task.Run(async () =>
            {
                await Task.Delay(1000);
                await _client.ExecuteWithHandling(request);
            });
        }

        public async Task UnsubscribeAsync(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            var creds = authenticationCredentialsProvider.ToArray();

            var webhook = await GetWebhook(creds, values);

            if (webhook is null)
                return;

            await DeleteWebhook(creds, values, webhook.WebhookId);
        }

        #endregion

        #region Utils

        private Task DeleteWebhook(
            AuthenticationCredentialsProvider[] creds,
            Dictionary<string, string> values,
            string webhookId)
        {
            var endpoint = $"/projects/{values["projectIdForWebhooks"]}/webhooks/{webhookId}";
            var request = new LokaliseRequest(endpoint, Method.Delete, creds);

            return _client.ExecuteWithHandling(request);
        }

        private async Task<WebhookDto?> GetWebhook(
            AuthenticationCredentialsProvider[] creds,
            Dictionary<string, string> values)
        {
            var endpoint = $"/projects/{values["projectIdForWebhooks"]}/webhooks?limit=5000";
            var request = new LokaliseRequest(endpoint, Method.Get, creds);

            var response = await _client.ExecuteWithHandling<WebhooksResponseWrapper>(request);
            return response?.Webhooks.FirstOrDefault(w => w.Url == values["payloadUrl"]);
        }

        #endregion
    }
}