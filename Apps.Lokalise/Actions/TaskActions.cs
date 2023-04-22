using Apps.Lokalise.ModelConverters;
using Apps.Lokalise.Models.Requests;
using Apps.Lokalise.Models.Responses.Projects;
using Apps.Lokalise.Models.Responses.Tasks;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class TaskActions
{
    private const string TasksUrlPart = "tasks";
    private const string ProjectsUrl = "https://api.lokalise.com/api2/projects";

    [Action("List tasks", Description = "Get all tasks of a certain project")]
    public TasksResponse? ListAllTasks(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                            [ActionParameter] string projectId,
                                            [ActionParameter] TaskListParameters parameters)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest($"/projects/{projectId}/tasks", Method.Get, authenticationCredentialsProviders);
        request.AddParameters(SnakeCaseConverter.ModelToSnakeCaseKeyPair(parameters));
        var result = client.Get(request);
        return SnakeCaseConverter.Deserialize<TasksResponse>(result.Content);
    }

    [Action("Create task", Description = "Create a new task")]
    public TaskResponse? CreateTask(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                        [ActionParameter] string projectId,
                                        [ActionParameter] TaskCreateRequest? parameters)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest($"/projects/{projectId}/tasks", Method.Post, authenticationCredentialsProviders);
        request.AddJsonBody(parameters);
        var result = client.Post(request);
        return SnakeCaseConverter.Deserialize<TaskResponse>(result.Content);
    }

    [Action("Get task", Description = "Get information about a specific task")]
    public TaskResponse? RetrieveTask(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                    [ActionParameter] string projectId,
                                    [ActionParameter] string taskId)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest($"/projects/{projectId}/tasks/${taskId}", Method.Get, authenticationCredentialsProviders);
        var result = client.Get(request);
        var res = SnakeCaseConverter.Deserialize<TaskRetriveResponse>(result.Content);
        return res.Task;
    }

    [Action("Update task", Description = "Update information on a specific task")]
    public TaskRetriveResponse? UpdateTask(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                  [ActionParameter] string projectId,
                                  [ActionParameter] string taskId,
                                  [ActionParameter] TaskUpdateRequest taskUpdateRequest)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest($"/projects/{projectId}/tasks/${taskId}", Method.Put, authenticationCredentialsProviders);
        request.AddJsonBody(taskUpdateRequest);
        var result = client.Put(request);
        return SnakeCaseConverter.Deserialize<TaskRetriveResponse>(result.Content);
    }

    [Action("Delete task", Description = "Delete a specific task")]
    public TaskDeleteResponse? DeleteTask(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                [ActionParameter] string projectId,
                                [ActionParameter] string taskId)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest($"/projects/{projectId}/tasks/${taskId}", Method.Delete, authenticationCredentialsProviders);
        var result = client.Delete(request);
        return SnakeCaseConverter.Deserialize<TaskDeleteResponse>(result.Content);
    }
}
