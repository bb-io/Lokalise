using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectKeysAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.keys.added";

        public ProjectKeysAddedHandler() : base(SubscriptionEvent) { }
    }
}