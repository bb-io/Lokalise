using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class TeamOrderCreatedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "team.order.created";

    public TeamOrderCreatedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}