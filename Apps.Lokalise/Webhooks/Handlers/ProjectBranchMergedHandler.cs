namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectBranchMergedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.branch.merged";

        public ProjectBranchMergedHandler() : base(SubscriptionEvent) { }
    }
}