using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTaskLanguageClosedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.task.language.closed";

        public ProjectTaskLanguageClosedHandler() : base(SubscriptionEvent) { }
    }
}