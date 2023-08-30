using Apps.Lokalise.Dtos;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using RestSharp;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class BaseWebhookHandler : IWebhookEventHandler<WebhookInput>
    {
        #region Fields

        private string _subscriptionEvent;
        private readonly LokaliseClient _client;
        private readonly WebhookInput _webhookInput;

        #endregion

        #region Constructors

        public BaseWebhookHandler(string subEvent, [WebhookParameter] WebhookInput input)
        {
            _subscriptionEvent = subEvent;
            _webhookInput = input;
            _client = new();
        }

        #endregion

        #region Subscriptions

        public async System.Threading.Tasks.Task SubscribeAsync(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            var endpoint = $"/projects/{_webhookInput.ProjectId}/webhooks";
            var request = new LokaliseRequest(endpoint, Method.Post, authenticationCredentialsProvider)
                .WithJsonBody(new
                {
                    url = values["payloadUrl"].Replace("https://localhost:44390", "https://25e9-178-211-106-141.ngrok-free.app"),
                    events = new[] { _subscriptionEvent }
                });
            await _client.ExecuteWithHandling(request);
            //return System.Threading.Tasks.Task.Run(async () =>
            //{
            //    await System.Threading.Tasks.Task.Delay(1000);
            //    await _client.ExecuteWithHandling(request);
            //});

            //var client = new RestClient();
            //var request = new RestRequest("https://webhook.site/065e88df-c57c-4934-b191-3861290680cd", Method.Post);
            //request.AddJsonBody(new
            //{
            //    url = values["payloadUrl"]
            //});
            //await client.ExecuteAsync(request);
        }

        public async System.Threading.Tasks.Task UnsubscribeAsync(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
            Dictionary<string, string> values)
        {
            var creds = authenticationCredentialsProvider.ToArray();

            var webhook = await GetWebhook(creds, _webhookInput.ProjectId, values);

            if (webhook is null)
                return;

            await DeleteWebhook(creds, values, webhook.WebhookId, _webhookInput.ProjectId);
        }

        #endregion

        #region Utils

        private System.Threading.Tasks.Task DeleteWebhook(
            AuthenticationCredentialsProvider[] creds,
            Dictionary<string, string> values,
            string webhookId,
            string projectId)
        {
            var endpoint = $"/projects/{projectId}/webhooks/{webhookId}";
            var request = new LokaliseRequest(endpoint, Method.Delete, creds);

            return _client.ExecuteWithHandling(request);
        }

        private async Task<WebhookDto?> GetWebhook(AuthenticationCredentialsProvider[] creds,
            string projectId,
            Dictionary<string, string> values)
        {
            var endpoint = $"/projects/{projectId}/webhooks?limit=5000";
            var request = new LokaliseRequest(endpoint, Method.Get, creds);

            var response = await _client.ExecuteWithHandling<WebhooksResponseWrapper>(request);
            return response?.Webhooks.FirstOrDefault(w => w.Url == values["payloadUrl"]);
        }

        #endregion
    }
}