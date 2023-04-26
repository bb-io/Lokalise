using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTaskCreatedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.task.created";

        public ProjectTaskCreatedHandler() : base(SubscriptionEvent) { }
    }
}