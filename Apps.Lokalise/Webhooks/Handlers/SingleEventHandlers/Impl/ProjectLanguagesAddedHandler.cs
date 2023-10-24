using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectLanguagesAddedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.languages.added";

    public ProjectLanguagesAddedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}