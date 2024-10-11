using System.Net;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Lists.Base;

public class WebhookList(InvocationContext invocationContext) : BaseInvocable(invocationContext)
{
    protected const string LokalisePingRequestBody = "[\"ping\"]";

    protected WebhookResponse<T> GetPreflightResponse<T>() where T : class
    {
        return new WebhookResponse<T>
        {
            ReceivedWebhookRequestType = WebhookRequestType.Preflight,
            Result = null,
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        };
    }
}