using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectContributorDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.contributor.deleted";

        public ProjectContributorDeletedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}