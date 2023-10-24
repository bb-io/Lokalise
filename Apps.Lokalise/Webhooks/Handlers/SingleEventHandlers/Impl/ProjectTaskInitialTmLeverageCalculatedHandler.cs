using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectTaskInitialTmLeverageCalculatedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.task.initial_tm_leverage.calculated";

    public ProjectTaskInitialTmLeverageCalculatedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}