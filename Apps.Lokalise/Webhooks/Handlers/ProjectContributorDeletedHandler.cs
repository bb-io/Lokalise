namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectContributorDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.contributor.deleted";

        public ProjectContributorDeletedHandler() : base(SubscriptionEvent) { }
    }
}