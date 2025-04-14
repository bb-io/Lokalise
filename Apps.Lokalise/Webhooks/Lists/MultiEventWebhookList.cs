using System.Net;
using Apps.Lokalise.Models.Requests.Keys;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.Models.Responses.Keys;
using Apps.Lokalise.Models.Responses.Tasks;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Apps.Lokalise.Webhooks.Handlers.MultipleEventHandlers.Impl;
using Apps.Lokalise.Webhooks.Lists.Base;
using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Input;
using Apps.Lokalise.Webhooks.Models.Payload;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using RestSharp;
using Task = System.Threading.Tasks.Task;

namespace Apps.Lokalise.Webhooks.Lists;

[WebhookList]
public class MultiEventWebhookList(InvocationContext invocationContext) : WebhookList(invocationContext)
{
    protected AuthenticationCredentialsProvider[] Creds =>
       InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected LokaliseClient Client { get; } = new();


    [Webhook("On key modified for assignee", typeof(AssigneeKeyModifiedEventHandler),
        Description = "Triggered when a key is modified for a specific assignee")]
    public async Task<WebhookResponse<AssigneeKeyModifiedEvent>> OnKeyModifiedForAssignee(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookUserInput input,
        [WebhookParameter] KeyOptionalRequest keyOptionalRequest)
    {
        var payload = webhookRequest.Body.ToString();
        if (string.IsNullOrEmpty(payload))
        {
            throw new PluginMisconfigurationException("The request must contain a body.");
        }

        var preflightResponse = new WebhookResponse<AssigneeKeyModifiedEvent>()
        {
            HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
            Result = null,
            ReceivedWebhookRequestType = WebhookRequestType.Preflight
        };

        if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            return preflightResponse;

        var data = JsonConvert.DeserializeObject<BasePayload>(payload)!;

        if (!input.Projects.Contains(data.Project.Id))
            return preflightResponse;

        AssigneeKeyModifiedEvent result;
        var endpoint = $"/projects/{data.Project.Id}/tasks";
        var allTasks = await Paginator.GetAll<TasksWrapper, TaskResponse>(
            InvocationContext.AuthenticationCredentialsProviders.ToArray(),
            endpoint);

        if (data.Event is "project.key.added")
        {
            var keyAddedPayload = JsonConvert.DeserializeObject<ProjectKeyAddedPayload>(payload)!.Convert();

            var keyLangs = allTasks
                .SelectMany(x => x.Languages)
                .Where(x => x.Keys.Contains(keyAddedPayload.Key.Id));

            if (!keyLangs.Any(x => x.Users.Any(x => x.Email == input.UserEmail)))
                return preflightResponse;

            result = new(keyAddedPayload)
            {
                Keys = new[] { keyAddedPayload.Key }
            };
        }
        else if (data.Event is "project.keys.added")
        {
            var keysAddedPayload = JsonConvert.DeserializeObject<ProjectKeysAddedPayload>(payload)!.Convert();

            var keyLangs = allTasks
                .SelectMany(x => x.Languages)
                .Where(x => keysAddedPayload.Keys.Any(y => x.Keys.Contains(y.Id)))
                .ToArray();

            if (!keyLangs.Any(x => x.Users.Any(x => x.Email == input.UserEmail)))
                return preflightResponse;

            result = new(keysAddedPayload)
            {
                Keys = keysAddedPayload.Keys
            };
        }
        else if (data.Event is "project.key.modified")
        {
            var keyModifiedPayload = JsonConvert.DeserializeObject<ProjectKeyModifiedPayload>(payload)!.Convert();

            var keyLangs = allTasks
                .SelectMany(x => x.Languages)
                .Where(x => x.Keys.Contains(keyModifiedPayload.Id));

            if (!keyLangs.Any(x => x.Users.Any(x => x.Email == input.UserEmail)))
                return preflightResponse;

            result = new(keyModifiedPayload)
            {
                Keys = new[]
                {
                    new KeyWithTags()
                    {
                        Id = keyModifiedPayload.Id,
                        Name = keyModifiedPayload.Name
                    }
                }
            };
        }
        else
        {
            var client = new LokaliseClient();
            var taskCreatedPayload = JsonConvert.DeserializeObject<TaskPayload>(payload)!.Convert();

            var request = new LokaliseRequest($"/projects/{taskCreatedPayload.ProjectId}/tasks/{taskCreatedPayload.TaskId}",
                Method.Get,
                InvocationContext.AuthenticationCredentialsProviders);

            var fullTask = await client.ExecuteWithHandling<TaskRetriveResponse>(request);

            if (!fullTask.Task.Languages.Any(x => x.Users.Any(x => x.Email == input.UserEmail)))
                return preflightResponse;

            var keyTasks = fullTask.Task.Languages
                .SelectMany(x => x.Keys)
                .Distinct()
                .Select(async x =>
                {
                    var endpoint = $"/projects/{taskCreatedPayload.ProjectId}/keys/{x}";
                    var request = new LokaliseRequest(endpoint, Method.Get,
                        InvocationContext.AuthenticationCredentialsProviders);
                    var response = await client.ExecuteWithHandling<KeyResponse>(request);

                    return new KeyWithTags()
                    {
                        Id = response.Key.KeyId,
                        Name = response.Key.KeyName.Web,
                        Tags = response.Key.Tags
                    };
                })
                .ToArray();

            result = new(taskCreatedPayload)
            {
                Keys = await Task.WhenAll(keyTasks)
            };
        }
        
        if(keyOptionalRequest.KeyId != null)
        {
            result.Keys = result.Keys.Where(x => x.Id == keyOptionalRequest.KeyId);
        }

        return new()
        {
            HttpResponseMessage = null,
            Result = result
        };
    }

    [Webhook("On key added (Multiple projects)", typeof(ProjectKeyAddedMultipleProjectsHandler))]
    public async Task<WebhookResponse<GetKeyEvent>> OnKeyAddedOrModified(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input,
        [WebhookParameter] ProjectOptionalRequest optionalRequest)
    {
        var response = HandlePreflightAndMap<KeyEvent, ProjectKeyAddedPayload>(webhookRequest, input, optionalRequest);
        return await MapToEventResponse(response);
    }

    private WebhookResponse<T1> HandlePreflightAndMap<T1, T2>(WebhookRequest webhookRequest, WebhookInput input, ProjectOptionalRequest optionalRequest)
      where T2 : BasePayload where T1 : BaseEvent
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

        if (optionalRequest.ProjectId != null && data.Project.Id != optionalRequest.ProjectId)
            return preflightResponse;

        return new()
        {
            HttpResponseMessage = null,
            Result = (T1)data.Convert()
        };
    }

    private async Task<WebhookResponse<GetKeyEvent>> MapToEventResponse<T>(WebhookResponse<T> response)
       where T : KeyEvent
    {
        if (response.ReceivedWebhookRequestType == WebhookRequestType.Preflight)
        {
            return new WebhookResponse<GetKeyEvent>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                Result = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };
        }

        var keyResponse = await GetKeyAsync(response.Result.ProjectId, response.Result.Key.Id);
        return new()
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new(response.Result, keyResponse),
            ReceivedWebhookRequestType = response.ReceivedWebhookRequestType
        };
    }
    private async Task<KeyResponse> GetKeyAsync(string projectId, string keyId)
    {
        var endpoint = $"/projects/{projectId}/keys/{keyId}";
        var request = new LokaliseRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithHandling<KeyResponse>(request);
        return response;
    }
}