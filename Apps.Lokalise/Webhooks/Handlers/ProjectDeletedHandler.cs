using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.deleted";

        public ProjectDeletedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}