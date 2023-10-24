using System.Net;
using Apps.Lokalise.Models.Responses.Keys;
using Apps.Lokalise.Models.Responses.Tasks;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Apps.Lokalise.Webhooks.Handlers.MultipleEventHandlers.Impl;
using Apps.Lokalise.Webhooks.Lists.Base;
using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Input;
using Apps.Lokalise.Webhooks.Models.Payload;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using RestSharp;
using Task = System.Threading.Tasks.Task;

namespace Apps.Lokalise.Webhooks.Lists;

[WebhookList]
public class MultiEventWebhookList : WebhookList
{
    public MultiEventWebhookList(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Webhook("On key modified for assignee", typeof(AssigneeKeyModifiedEventHandler),
        Description = "Triggered when a key is modified for a specific assignee")]
    public async Task<WebhookResponse<AssigneeKeyModifiedEvent>> OnKeyModifiedForAssignee(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookUserInput input)
    {
        var payload = webhookRequest.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload);

        var preflightResponse = new WebhookResponse<AssigneeKeyModifiedEvent>()
        {
            HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
            Result = null,
            ReceivedWebhookRequestType = WebhookRequestType.Preflight
        };

        if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            return preflightResponse;

        var data = JsonConvert.DeserializeObject<BasePayload>(payload)!;

        if (data.Project.Id != input.ProjectId)
            return preflightResponse;

        AssigneeKeyModifiedEvent result;

        var endpoint = $"/projects/{input.ProjectId}/tasks";
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
            var taskCreatedPayload = JsonConvert.DeserializeObject<ProjectTaskCreatedPayload>(payload)!.Convert();

            var request = new LokaliseRequest($"/projects/{input.ProjectId}/tasks/{taskCreatedPayload.TaskId}",
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
                    var endpoint = $"/projects/{input.ProjectId}/keys/{x}";
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

        return new()
        {
            HttpResponseMessage = null,
            Result = result
        };
    }
}