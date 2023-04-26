using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectKeysDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.keys.deleted";

        public ProjectKeysDeletedHandler() : base(SubscriptionEvent) { }
    }
}