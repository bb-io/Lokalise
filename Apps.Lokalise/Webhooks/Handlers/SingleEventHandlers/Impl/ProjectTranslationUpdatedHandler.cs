using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectTranslationUpdatedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.translation.updated";

    public ProjectTranslationUpdatedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}