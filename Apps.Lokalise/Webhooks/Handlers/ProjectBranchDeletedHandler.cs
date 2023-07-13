using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectBranchDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.branch.deleted";

        public ProjectBranchDeletedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}