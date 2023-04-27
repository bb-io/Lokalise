﻿using Apps.Lokalise;
using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using RestSharp;

namespace Apps.Localise.Webhooks.Handlers
{
    public class BaseWebhookHandler : IWebhookEventHandler
    {

        private string SubscriptionEvent;

        public BaseWebhookHandler(string subEvent)
        {
            SubscriptionEvent = subEvent;
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{values["projectIdForWebhooks"]}/webhooks", Method.Post, authenticationCredentialsProvider);
            request.AddJsonBody(new
            {
                url = values["payloadUrl"],
                events = new[] { SubscriptionEvent }
            });
            Task.Run(async () =>
            {
                await Task.Delay(2000);
                client.Execute(request);
            });
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            var client = new LokaliseClient();
            var getRequest = new LokaliseRequest($"/projects/{values["projectIdForWebhooks"]}/webhooks?limit=5000", Method.Post, authenticationCredentialsProvider);
            var webhooks = await client.GetAsync<WebhooksResponseWrapper>(getRequest);
            var webhook = webhooks.Webhooks.FirstOrDefault(w => w.Url == values["payloadUrl"]);

            var deleteRequest = new LokaliseRequest($"/projects/{values["projectIdForWebhooks"]}/webhooks/{webhook.WebhookId}", Method.Delete, authenticationCredentialsProvider);
            await client.ExecuteAsync(deleteRequest);
        }
    }
}
