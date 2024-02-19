using System.Net;
using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;
using Apps.Lokalise.Webhooks.Lists.Base;
using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Input;
using Apps.Lokalise.Webhooks.Models.Payload;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using Task = System.Threading.Tasks.Task;

namespace Apps.Lokalise.Webhooks.Lists;

[WebhookList]
public class TaskWebhooks : WebhookList
{
    public TaskWebhooks(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Webhook("On task created", typeof(ProjectTaskCreatedHandler),
        Description = "Triggered when a new task is created in a project")]
    public Task<WebhookResponse<TaskEvent>> ProjectTaskCreatedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] TaskWebhookInput input)
    {
        return Task.FromResult(HandlePreflightAndMap<TaskEvent, TaskPayload>(webhookRequest, input));
    }

    [Webhook("On task closed", typeof(ProjectTaskClosedHandler),
        Description = "Triggered when a project task is closed")]
    public Task<WebhookResponse<TaskEvent>> ProjectTaskClosedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] TaskWebhookInput input)
    {
        return Task.FromResult(HandlePreflightAndMap<TaskEvent, TaskPayload>(webhookRequest, input));
    }

    [Webhook("On task deleted", typeof(ProjectTaskDeletedHandler),
        Description = "Triggered when a project task is deleted")]
    public Task<WebhookResponse<TaskEvent>> ProjectTaskDeletedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] TaskWebhookInput input)
    {
        return Task.FromResult(HandlePreflightAndMap<TaskEvent, TaskPayload>(webhookRequest, input));
    }

    [Webhook("On task language closed", typeof(ProjectTaskLanguageClosedHandler),
        Description = "Triggered when a specific language task closes")]
    public Task<WebhookResponse<TaskLanguageEvent>> ProjectTaskLanguageClosedHandler(
        WebhookRequest webhookRequest, [WebhookParameter(true)] TaskWebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<TaskLanguageEvent, ProjectTaskLanguageClosedPayload>(webhookRequest, input));
    }

    private WebhookResponse<T1> HandlePreflightAndMap<T1, T2>(WebhookRequest webhookRequest, TaskWebhookInput input)
        where T2 : TaskPayload where T1 : TaskEvent
    {
        var preflightResponse = new WebhookResponse<T1>()
        {
            HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
            Result = null,
            ReceivedWebhookRequestType = WebhookRequestType.Preflight
        };

        if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            return preflightResponse;

        var data = JsonConvert.DeserializeObject<T2>(webhookRequest.Body.ToString()!);

        if (data is null)
            throw new InvalidCastException(nameof(webhookRequest.Body));

        if (!input.Projects.Contains(data.Project.Id))
            return preflightResponse;

        if (input.UserEmail != null && data.User.Email != input.UserEmail)
            return preflightResponse;

        if (data.Task.Type != input.TaskType)
            return preflightResponse;

        return new()
        {
            HttpResponseMessage = null,
            Result = (T1)data.Convert()
        };
    }
}