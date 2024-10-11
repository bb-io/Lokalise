using System.Net;
using Apps.Lokalise.Actions;
using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.Models.Requests.Tasks;
using Apps.Lokalise.Models.Responses.Tasks;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;
using Apps.Lokalise.Webhooks.Lists.Base;
using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Input;
using Apps.Lokalise.Webhooks.Models.Payload;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using Task = System.Threading.Tasks.Task;

namespace Apps.Lokalise.Webhooks.Lists;

[WebhookList]
public class TaskWebhooks(InvocationContext invocationContext) : WebhookList(invocationContext)
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected LokaliseClient Client { get; } = new();

    [Webhook("On task created", typeof(ProjectTaskCreatedHandler),
        Description = "Triggered when a new task is created in a project")]
    public async Task<WebhookResponse<GetTaskEvent>> ProjectTaskCreatedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] TaskWebhookInput input,
        [WebhookParameter, Display("Team ID"), DataSource(typeof(TeamDataHandler))] string? teamId)
    {
        var response = HandlePreflightAndMap<TaskEvent, TaskPayload>(webhookRequest, input);
        return await MapToEventResponse(response, teamId);
    }

    [Webhook("On task closed", typeof(ProjectTaskClosedHandler),
        Description = "Triggered when a project task is closed")]
    public async Task<WebhookResponse<GetTaskEvent>> ProjectTaskClosedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] TaskWebhookInput input,
        [WebhookParameter, Display("Team ID"), DataSource(typeof(TeamDataHandler))] string? teamId,
        [WebhookParameter] GetTaskOptionalRequest optionalRequest)
    {
        var response = HandlePreflightAndMap<TaskEvent, TaskPayload>(webhookRequest, input);
        var result = await MapToEventResponse(response, teamId);
        
        if(optionalRequest.ProjectId != null && optionalRequest.ProjectId != result.Result?.ProjectId)
        {
            return GetPreflightResponse<GetTaskEvent>();
        }

        if (optionalRequest.TaskId != null && optionalRequest.TaskId != result.Result?.Task.TaskId)
        {
            return GetPreflightResponse<GetTaskEvent>();
        }
        
        return result;
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
    public async Task<WebhookResponse<GetTaskLanguageEvent>> ProjectTaskLanguageClosedHandler(
        WebhookRequest webhookRequest, [WebhookParameter(true)] TaskWebhookInput input,
        [WebhookParameter, Display("Team ID"), DataSource(typeof(TeamDataHandler))] string? teamId,
        [WebhookParameter] GetTaskOptionalRequest optionalRequest)
    {
        var response = HandlePreflightAndMap<TaskLanguageEvent, ProjectTaskLanguageClosedPayload>(webhookRequest, input);
        var taskResponse = await MapToEventResponse(response, teamId);

        if (taskResponse.ReceivedWebhookRequestType == WebhookRequestType.Preflight)
        {
            return new WebhookResponse<GetTaskLanguageEvent>()
            {
                HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                Result = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };
        }

        var taskLanguageEvent = new GetTaskLanguageEvent(response.Result, taskResponse.Result.Task);
        
        if(optionalRequest.ProjectId != null && optionalRequest.ProjectId != taskLanguageEvent.ProjectId)
        {
            return GetPreflightResponse<GetTaskLanguageEvent>();
        }
        
        if (optionalRequest.TaskId != null && optionalRequest.TaskId != taskLanguageEvent.Task?.TaskId)
        {
            return GetPreflightResponse<GetTaskLanguageEvent>();
        }
        
        return new()
        {
            HttpResponseMessage = null,
            Result = taskLanguageEvent
        };
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

        if (input.TaskType != null && data.Task.Type != input.TaskType)
            return preflightResponse;

        return new()
        {
            HttpResponseMessage = null,
            Result = (T1)data.Convert()
        };
    }

    private async Task<TaskResponse> GetTaskAsync(string projectId, string taskId, string teamId = null)
    {
        var taskActions = new TaskActions(InvocationContext);
        return await taskActions.RetrieveTask(new GetTaskRequest
        {
            ProjectId = projectId,
            TaskId = taskId
        }, teamId);
    }

    private async Task<WebhookResponse<GetTaskEvent>> MapToEventResponse<T>(WebhookResponse<T> response, string? teamId)
        where T : TaskEvent
    {
        if (response.ReceivedWebhookRequestType == WebhookRequestType.Preflight)
        {
            return new WebhookResponse<GetTaskEvent>()
            {
                HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                Result = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };
        }

        var task = await GetTaskAsync(response.Result.ProjectId, response.Result.TaskId, teamId);
        return new()
        {
            HttpResponseMessage = null,
            Result = new(response.Result, task)
        };
    }
}