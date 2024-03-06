using Apps.Lokalise.Dtos;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;

public class TaskWebhookHandler : IWebhookEventHandler<WebhookInput>
{
    #region Fields

    private string _subscriptionEvent;
    private readonly LokaliseClient _client;
    private readonly TaskWebhookInput _webhookInput;

    #endregion

    #region Constructors

    public TaskWebhookHandler(string subEvent, [WebhookParameter] TaskWebhookInput input)
    {
        _subscriptionEvent = subEvent;
        _webhookInput = input;
        _client = new();
    }

    #endregion

    #region Subscriptions

    public async Task SubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
        Dictionary<string, string> values)
    {
        foreach (var project in _webhookInput.Projects)
        {
            var endpoint = $"/projects/{project}/webhooks";
            var request = new LokaliseRequest(endpoint, Method.Post, authenticationCredentialsProvider)
                .WithJsonBody(new
                {
                    url = values["payloadUrl"].Replace("https://localhost:44390",
                        "https://25e9-178-211-106-141.ngrok-free.app"),
                    events = new[] { _subscriptionEvent }
                });
            await _client.ExecuteWithHandling(request);
        }
    }

    public async Task UnsubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
        Dictionary<string, string> values)
    {
        var creds = authenticationCredentialsProvider.ToArray();

        foreach(var project in _webhookInput.Projects)
        {
            var webhook = await GetWebhook(creds, project, values);

            if (webhook is null)
                return;

            await DeleteWebhook(creds, values, webhook.WebhookId, project);
        }        
    }

    #endregion

    #region Utils

    private Task DeleteWebhook(
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