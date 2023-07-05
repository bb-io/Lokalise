using Apps.Localise.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectContributorAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.contributor.added";

        public ProjectContributorAddedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}