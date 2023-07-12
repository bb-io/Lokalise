namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectImportedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.imported";

        public ProjectImportedHandler() : base(SubscriptionEvent) { }
    }
}