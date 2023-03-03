using Apps.Lokalise.ModelConverters;
using Apps.Lokalise.Models.Requests;
using Apps.Lokalise.Models.Responses.Tasks;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Lokalise.Actions;

[ActionList]
public class TaskActions : BaseActions
{
    private const string TasksUrl = "tasks";
    private const string ProjectsUrl = "projects";

    [Action]
    public TasksResponse? ListAllTasks(string url,
                                            [ActionParameter] string projectId,
                                            [ActionParameter] TaskListParameters taskListParameters,
                                            AuthenticationCredentialsProvider authenticationCredentialsProvider)
    {
        var requestUrl = $"{url}/{ProjectsUrl}/{projectId}/{TasksUrl}";

        var result = _httpRequestProvider.Get(
            requestUrl,
            SnakeCaseConverter.ModelToSnakeCaseKeyPair(taskListParameters),
            authenticationCredentialsProvider);

        return SnakeCaseConverter.Deserialize<TasksResponse>(result.Content);
    }

    [Action]
    public TaskResponse? CreateTask(string url,
                                        [ActionParameter] string projectId,
                                        [ActionParameter] TaskCreateRequest? taskCreateRequest,
                                        AuthenticationCredentialsProvider authenticationCredentialsProvider)
    {
        var requestUrl = $"{url}/{ProjectsUrl}/{projectId}/{TasksUrl}";
        var result = _httpRequestProvider.Post(
            requestUrl,
            null,
            _requestWithBodyHeaders,
            SnakeCaseConverter.Serialize(taskCreateRequest),
            authenticationCredentialsProvider);

        return SnakeCaseConverter.Deserialize<TaskResponse>(result.Content);
    }

    [Action]
    public TaskRetriveResponse? RetrieveTask(string url,
                                    [ActionParameter] string projectId,
                                    [ActionParameter] string taskId,
                                    AuthenticationCredentialsProvider authenticationCredentialsProvider)
    {
        var requestUrl = $"{url}/{ProjectsUrl}/{projectId}/{TasksUrl}/{taskId}";
        var result = _httpRequestProvider.Get(requestUrl, null, authenticationCredentialsProvider);
        return SnakeCaseConverter.Deserialize<TaskRetriveResponse>(result.Content);
    }

    [Action]
    public TaskRetriveResponse? UpdateTask(string url,
                                  [ActionParameter] string projectId,
                                  [ActionParameter] string taskId,
                                  [ActionParameter] TaskUpdateRequest taskUpdateRequest,
                                  AuthenticationCredentialsProvider authenticationCredentialsProvider)
    {
        var requestUrl = $"{url}/{ProjectsUrl}/{projectId}/{TasksUrl}/{taskId}";
        var result = _httpRequestProvider.Put(
            requestUrl,
            null,
            _requestWithBodyHeaders,
            SnakeCaseConverter.Serialize(taskUpdateRequest),
            authenticationCredentialsProvider);

        return SnakeCaseConverter.Deserialize<TaskRetriveResponse>(result.Content);
    }

    [Action]
    public TaskDeleteResponse? DeleteTask(string url,
                                [ActionParameter] string projectId,
                                [ActionParameter] string taskId,
                                AuthenticationCredentialsProvider authenticationCredentialsProvider)
    {
        var requestUrl = $"{url}/{ProjectsUrl}/{projectId}/{TasksUrl}/{taskId}";
        var result = _httpRequestProvider.Delete(requestUrl, null, authenticationCredentialsProvider);
        return SnakeCaseConverter.Deserialize<TaskDeleteResponse>(result.Content);
    }
}
