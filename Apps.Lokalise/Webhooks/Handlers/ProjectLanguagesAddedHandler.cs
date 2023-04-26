using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectLanguagesAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.languages.added";

        public ProjectLanguagesAddedHandler() : base(SubscriptionEvent) { }
    }
}