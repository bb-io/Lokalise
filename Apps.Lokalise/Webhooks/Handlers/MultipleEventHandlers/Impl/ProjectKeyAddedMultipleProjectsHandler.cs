using Apps.Lokalise.Webhooks.Bridge.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.MultipleEventHandlers.Impl
{
    public class ProjectKeyAddedMultipleProjectsHandler : MultipleBaseWebhookBridgeHandler
    {
        public static readonly IEnumerable<string> DefaultSubscriptionEvents = new[]
       {
            "project.task.created",
            "project.key.modified",
            "project.keys.added",
            "project.key.added"
        };
        public ProjectKeyAddedMultipleProjectsHandler(
            InvocationContext invocationContext,
            [WebhookParameter] WebhookUserInput input)
            : base(invocationContext, DefaultSubscriptionEvents, input.Projects)
        {
        }
    }
}