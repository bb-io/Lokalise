using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTaskInitial_tm_leverageCalculatedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.task.initial_tm_leverage.calculated";

        public ProjectTaskInitial_tm_leverageCalculatedHandler() : base(SubscriptionEvent) { }
    }
}