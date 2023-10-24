using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectBranchDeletedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.branch.deleted";

    public ProjectBranchDeletedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}