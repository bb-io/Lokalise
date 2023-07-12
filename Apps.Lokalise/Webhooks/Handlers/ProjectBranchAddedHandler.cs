namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectBranchAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.branch.added";

        public ProjectBranchAddedHandler() : base(SubscriptionEvent) { }
    }
}