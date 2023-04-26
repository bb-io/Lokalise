using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectKeyAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.key.added";

        public ProjectKeyAddedHandler() : base(SubscriptionEvent) { }
    }
}