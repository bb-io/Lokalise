using Apps.Lokalise.Webhooks.Bridge.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.MultipleEventHandlers.Impl
{
    public class ProjectKeysAddedOrModifiedHandler : MultipleBaseWebhookBridgeHandler
    {
        public static readonly IEnumerable<string> DefaultSubscriptionEvents = new[]
        {
            "project.keys.added",
            "project.keys.modified"
        };
        public ProjectKeysAddedOrModifiedHandler(
            InvocationContext invocationContext,
            [WebhookParameter] WebhookUserInput input)
            : base(invocationContext, DefaultSubscriptionEvents, input.Projects)
        {
        }
    }
}