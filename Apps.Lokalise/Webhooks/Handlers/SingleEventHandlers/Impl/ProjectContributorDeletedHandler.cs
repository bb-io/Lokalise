using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectContributorDeletedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.contributor.deleted";

    public ProjectContributorDeletedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}