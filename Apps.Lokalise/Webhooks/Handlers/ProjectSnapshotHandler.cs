using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectSnapshotHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.snapshot";

        public ProjectSnapshotHandler() : base(SubscriptionEvent) { }
    }
}