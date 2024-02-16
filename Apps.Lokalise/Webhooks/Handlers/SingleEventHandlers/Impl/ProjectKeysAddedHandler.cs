using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectKeysAddedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.key.added";

    public ProjectKeysAddedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}