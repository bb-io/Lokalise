using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectContributorAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.contributor.added";

        public ProjectContributorAddedHandler() : base(SubscriptionEvent) { }
    }
}