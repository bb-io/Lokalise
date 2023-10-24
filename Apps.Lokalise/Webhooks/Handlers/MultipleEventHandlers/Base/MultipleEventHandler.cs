using Apps.Lokalise.Dtos;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Lokalise.Webhooks.Handlers.MultipleEventHandlers.Base;

public abstract class MultipleEventHandler : IWebhookEventHandler<WebhookInput>
{
    #region Fields

    protected abstract string[] SubscriptionEvents { get; }
    private readonly LokaliseClient _client;
    private readonly WebhookUserInput _webhookInput;

    #endregion

    #region Constructors

    public MultipleEventHandler([WebhookParameter] WebhookUserInput input)
    {
        _webhookInput = input;
        _client = new();
    }

    #endregion

    #region Subscriptions

    public Task SubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var endpoint = $"/projects/{_webhookInput.ProjectId}/webhooks";
        var request = new LokaliseRequest(endpoint, Method.Post, creds)
            .WithJsonBody(new
            {
                url = values["payloadUrl"],
                events = SubscriptionEvents
            });

        return _client.ExecuteWithHandling(request);
    }

    public async Task UnsubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var authCreds = creds.ToArray();
        var allWebhooks = await GetAllWebhooks(authCreds, _webhookInput.ProjectId, values);

        var webhookToDelete = allWebhooks.Webhooks
            .FirstOrDefault(x => x.Url == values["payloadUrl"]);

        if (webhookToDelete is null)
            return;

        await DeleteWebhook(authCreds, values, webhookToDelete.WebhookId, _webhookInput.ProjectId);
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

    private Task<WebhooksResponseWrapper> GetAllWebhooks(AuthenticationCredentialsProvider[] creds,
        string projectId,
        Dictionary<string, string> values)
    {
        var endpoint = $"/projects/{projectId}/webhooks?limit=5000";
        var request = new LokaliseRequest(endpoint, Method.Get, creds);

        return _client.ExecuteWithHandling<WebhooksResponseWrapper>(request);
    }

    #endregion
}