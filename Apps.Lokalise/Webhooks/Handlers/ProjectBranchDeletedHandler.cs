using Apps.Localise.Webhooks.Handlers;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectBranchDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.branch.deleted";

        public ProjectBranchDeletedHandler() : base(SubscriptionEvent) { }
    }
}