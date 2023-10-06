using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers;

public class ProjectTaskClosedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.task.closed";

    public ProjectTaskClosedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}