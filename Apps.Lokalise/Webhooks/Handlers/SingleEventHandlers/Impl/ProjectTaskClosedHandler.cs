using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectTaskClosedHandler : TaskWebhookHandler
{
    const string SubscriptionEvent = "project.task.closed";

    public ProjectTaskClosedHandler([WebhookParameter] TaskWebhookInput input) : base(SubscriptionEvent, input) { }
}