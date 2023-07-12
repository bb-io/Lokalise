namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.deleted";

        public ProjectDeletedHandler() : base(SubscriptionEvent) { }
    }
}