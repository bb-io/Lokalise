using Apps.Lokalise.ModelConverters;
using Apps.Lokalise.Models.Requests;
using Apps.Lokalise.Models.Responses.Tasks;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Lokalise.Actions;

[ActionList]
public class TaskActions : BaseActions
{
    private const string TasksUrl = "https://api.lokalise.com/api2/tasks";
    private const string ProjectsUrl = "https://api.lokalise.com/api2/projects";

    [Action]
    public TasksResponse? ListAllTasks(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                            [ActionParameter] string projectId,
                                            [ActionParameter] TaskListParameters taskListParameters)
    {
        var requestUrl = $"{ProjectsUrl}/{projectId}/{TasksUrl}";

        var result = _httpRequestProvider.Get(
            requestUrl,
            SnakeCaseConverter.ModelToSnakeCaseKeyPair(taskListParameters),
            authenticationCredentialsProvider);

        return SnakeCaseConverter.Deserialize<TasksResponse>(result.Content);
    }

    [Action]
    public TaskResponse? CreateTask(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                        [ActionParameter] string projectId,
                                        [ActionParameter] TaskCreateRequest? taskCreateRequest)
    {
        var requestUrl = $"{ProjectsUrl}/{projectId}/{TasksUrl}";
        var result = _httpRequestProvider.Post(
            requestUrl,
            null,
            _requestWithBodyHeaders,
            SnakeCaseConverter.Serialize(taskCreateRequest),
            authenticationCredentialsProvider);

        return SnakeCaseConverter.Deserialize<TaskResponse>(result.Content);
    }

    [Action]
    public TaskResponse? RetrieveTask(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                    [ActionParameter] string projectId,
                                    [ActionParameter] string taskId)
    {
        var requestUrl = $"{ProjectsUrl}/{projectId}/{TasksUrl}/{taskId}";
        var result = _httpRequestProvider.Get(requestUrl, null, authenticationCredentialsProvider);
        var res = SnakeCaseConverter.Deserialize<TaskRetriveResponse>(result.Content);
        return res.Task;
    }

    [Action]
    public WordsCounts? RetrieveTaskWordsCount(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                [ActionParameter] string projectId,
                                [ActionParameter] string taskId)
    {
        var requestUrl = $"{ProjectsUrl}/{projectId}/{TasksUrl}/{taskId}";
        var result = _httpRequestProvider.Get(requestUrl, null, authenticationCredentialsProvider);
        var res = SnakeCaseConverter.Deserialize<WordsCountResponse>(result.Content);
        return res.Task;
    }

    [Action]
    public TaskRetriveResponse? UpdateTask(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                  [ActionParameter] string projectId,
                                  [ActionParameter] string taskId,
                                  [ActionParameter] TaskUpdateRequest taskUpdateRequest)
    {
        var requestUrl = $"{ProjectsUrl}/{projectId}/{TasksUrl}/{taskId}";
        var result = _httpRequestProvider.Put(
            requestUrl,
            null,
            _requestWithBodyHeaders,
            SnakeCaseConverter.Serialize(taskUpdateRequest),
            authenticationCredentialsProvider);

        return SnakeCaseConverter.Deserialize<TaskRetriveResponse>(result.Content);
    }

    [Action]
    public TaskDeleteResponse? DeleteTask(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                [ActionParameter] string projectId,
                                [ActionParameter] string taskId)
    {
        var requestUrl = $"{ProjectsUrl}/{projectId}/{TasksUrl}/{taskId}";
        var result = _httpRequestProvider.Delete(requestUrl, null, authenticationCredentialsProvider);
        return SnakeCaseConverter.Deserialize<TaskDeleteResponse>(result.Content);
    }
}
