using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers;

public class ProjectTaskCreatedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.task.created";

    public ProjectTaskCreatedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}