using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTaskClosedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.task.closed";

        public ProjectTaskClosedHandler() : base(SubscriptionEvent) { }
    }
}