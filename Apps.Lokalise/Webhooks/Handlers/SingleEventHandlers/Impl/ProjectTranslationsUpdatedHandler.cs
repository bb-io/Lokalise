using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectTranslationsUpdatedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.translations.updated";

    public ProjectTranslationsUpdatedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}