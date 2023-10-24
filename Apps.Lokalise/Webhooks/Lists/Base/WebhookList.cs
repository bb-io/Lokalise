using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Lokalise.Webhooks.Lists.Base;

public class WebhookList : BaseInvocable
{
    protected const string LokalisePingRequestBody = "[\"ping\"]";

    public WebhookList(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}