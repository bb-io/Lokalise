using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers;

public class ProjectTaskLanguageClosedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.task.language.closed";

    public ProjectTaskLanguageClosedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}