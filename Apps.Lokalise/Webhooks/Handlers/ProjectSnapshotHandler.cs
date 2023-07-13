using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectSnapshotHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.snapshot";

        public ProjectSnapshotHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}