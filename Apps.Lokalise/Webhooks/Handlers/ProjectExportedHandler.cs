using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectExportedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.exported";

        public ProjectExportedHandler() : base(SubscriptionEvent) { }
    }
}