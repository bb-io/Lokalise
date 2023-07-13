using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectBranchAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.branch.added";

        public ProjectBranchAddedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input)
        {
        }
    }
}