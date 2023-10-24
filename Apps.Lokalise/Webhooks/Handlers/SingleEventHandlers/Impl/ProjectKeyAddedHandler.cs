using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectKeyAddedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.key.added";

    public ProjectKeyAddedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}