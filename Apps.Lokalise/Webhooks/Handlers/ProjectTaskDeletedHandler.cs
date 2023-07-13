using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTaskDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.task.deleted";

        public ProjectTaskDeletedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}