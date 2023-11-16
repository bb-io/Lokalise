using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectTaskCreatedHandler : TaskWebhookHandler
{
    const string SubscriptionEvent = "project.task.created";

    public ProjectTaskCreatedHandler([WebhookParameter] TaskWebhookInput input) : base(SubscriptionEvent, input) { }
}