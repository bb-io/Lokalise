using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers;

public class TeamOrderCreatedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "team.order.created";

    public TeamOrderCreatedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}