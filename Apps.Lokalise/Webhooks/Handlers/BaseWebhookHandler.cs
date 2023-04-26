using Apps.Lokalise;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            var request = new LokaliseRequest($"/projects/{values["projectIdForWebhooks"]}/webhooks", Method.Post, authenticationCredentialsProvider); //{values["projectIdForWebhooks"]}
            request.AddJsonBody(new
            {
                url = values["payloadUrl"],
                events = new[] { SubscriptionEvent }
            });
            await client.ExecuteAsync(request);
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            //var client = new ZendeskClient(authenticationCredentialsProvider);
            //var getRequest = new ZendeskRequest($"/api/v2/webhooks?filter[name_contains]={SubscriptionEvent}", Method.Get, authenticationCredentialsProvider);
            //var webhooks = await client.GetAsync<WebhooksListResponse>(getRequest);
            //var webhookId = webhooks.Webhooks.First().Id;

            //var deleteRequest = new ZendeskRequest($"/api/v2/webhooks/{webhookId}", Method.Delete, authenticationCredentialsProvider);
            //await client.ExecuteAsync(deleteRequest);
        }
    }
}
