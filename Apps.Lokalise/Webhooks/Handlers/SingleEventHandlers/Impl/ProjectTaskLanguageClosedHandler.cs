using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectTaskLanguageClosedHandler : TaskWebhookHandler
{
    const string SubscriptionEvent = "project.task.language.closed";

    public ProjectTaskLanguageClosedHandler([WebhookParameter] TaskWebhookInput input) : base(SubscriptionEvent, input) { }
}