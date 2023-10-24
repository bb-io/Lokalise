using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectTranslationProofreadHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.translation.proofread";

    public ProjectTranslationProofreadHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}