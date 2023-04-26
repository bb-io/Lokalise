using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectKeyModifiedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.key.modified";

        public ProjectKeyModifiedHandler() : base(SubscriptionEvent) { }
    }
}