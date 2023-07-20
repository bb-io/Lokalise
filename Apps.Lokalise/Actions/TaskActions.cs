using Apps.Lokalise.Extensions;
using Apps.Lokalise.Models.Requests.Tasks;
using Apps.Lokalise.Models.Responses.Tasks;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class TaskActions
{
    #region Fields

    private readonly LokaliseClient _client;

    #endregion

    #region Constructors

    public TaskActions()
    {
        _client = new();
    }

    #endregion

    #region Actions

    [Action("List tasks", Description = "Get all tasks of a certain project")]
    public async Task<ListTasksResponse> ListAllTasks(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] [Display("Project ID")]
        string projectId,
        [ActionParameter] TaskListParameters parameters)
    {
        var endpoint = $"/projects/{projectId}/tasks";

        var query = parameters.AsDictionary().AllIsNotNull();
        var endpointWithQuery = QueryHelpers.AddQueryString(endpoint, query);

        var items = await Paginator.GetAll<TasksWrapper, TaskResponse>(
            authenticationCredentialsProviders.ToArray(),
            endpointWithQuery);

        return new(items);
    }

    [Action("Create task", Description = "Create a new task")]
    public async Task<TaskResponse> CreateTask(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] [Display("Project ID")]
        string projectId,
        [ActionParameter] TaskCreateRequest parameters)
    {
        var request = new LokaliseRequest($"/projects/{projectId}/tasks", Method.Post,
                authenticationCredentialsProviders)
            .WithJsonBody(parameters);

        var response = await _client.ExecuteWithHandling<TaskRetriveResponse>(request);
        return response.Task;
    }

    [Action("Get task", Description = "Get information about a specific task")]
    public async Task<TaskResponse> RetrieveTask(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] [Display("Project ID")]
        string projectId,
        [ActionParameter] [Display("Task ID")] string taskId)
    {
        var request = new LokaliseRequest($"/projects/{projectId}/tasks/{taskId}", Method.Get,
            authenticationCredentialsProviders);

        var response = await _client.ExecuteWithHandling<TaskRetriveResponse>(request);
        return response.Task;
    }

    [Action("Update task", Description = "Update information on a specific task")]
    public async Task<TaskResponse> UpdateTask(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] [Display("Project ID")] string projectId,
        [ActionParameter] [Display("Task ID")] string taskId,
        [ActionParameter] TaskUpdateRequest taskUpdateRequest)
    {
        var endpoint = $"/projects/{projectId}/tasks/{taskId}";
        var request = new LokaliseRequest(endpoint, Method.Put, authenticationCredentialsProviders)
            .WithJsonBody(taskUpdateRequest);

        var response = await _client.ExecuteWithHandling<TaskRetriveResponse>(request);
        return response.Task;
    }

    [Action("Delete task", Description = "Delete a specific task")]
    public Task<TaskDeleteResponse> DeleteTask(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] [Display("Project ID")] string projectId,
        [ActionParameter] [Display("Task ID")] string taskId)
    {
        var endpoint = $"/projects/{projectId}/tasks/{taskId}";
        var request = new LokaliseRequest(endpoint, Method.Delete, authenticationCredentialsProviders);
        
        return _client.ExecuteWithHandling<TaskDeleteResponse>(request);
    }

    #endregion
}