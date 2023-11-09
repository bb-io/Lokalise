using Apps.Lokalise.Constants;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.Models.Requests.Tasks;
using Apps.Lokalise.Models.Responses.Tasks;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.Extensions.System;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class TaskActions : LokaliseInvocable
{
    public TaskActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #region Actions

    [Action("List tasks", Description = "Get all tasks of a certain project")]
    public async Task<ListTasksResponse> ListAllTasks([ActionParameter] ProjectRequest project,
        [ActionParameter] TaskListParameters parameters)
    {
        var endpoint = $"/projects/{project.ProjectId}/tasks";

        var query = parameters.AsLokaliseDictionary().AllIsNotNull();
        var endpointWithQuery = endpoint.WithQuery(query);

        var items = await Paginator.GetAll<TasksWrapper, TaskResponse>(Creds, endpointWithQuery);
        items.ForEach(i => i.FillLanguageCodesArray());

        return new(items);
    }

    [Action("Create task", Description = "Create a new task")]
    public async Task<TaskResponse> CreateTask([ActionParameter] ProjectRequest project,
        [ActionParameter] TaskCreateRequest parameters)
    {
        if (parameters.FilterKeys is null && parameters.Keys is null && parameters.ParentTaskId is null)
            throw new("One of the inputs must be specified: Parent task ID or Keys or Filter keys");

        if (parameters.Users is null && parameters.Groups is null)
            throw new("One of the inputs must be specified: Users or Groups");

        if (parameters.FilterKeys is not null && parameters.Keys is not null)
            throw new("You should chose only one: either specify key IDs or use Filter keys");

        if (parameters.FilterKeys is not null)
        {
            parameters.Keys = parameters.FilterKeys switch
            {
                LokaliseConstants.UntranslatedFilter => await GetUntranslatedKeys(project, parameters.Languages),
                LokaliseConstants.UnverifiedFilter => await GetUnverifiedKeys(project, parameters.Languages),
                _ => throw new InvalidOperationException("Wrong filter keys parameter")
            };
        }
        var endpoint = $"/projects/{project.ProjectId}/tasks";

        var payload = new TaskCreateWithMultLangsRequest(parameters);
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(payload, JsonConfig.Settings);

        var response = await Client.ExecuteWithHandling<TaskRetriveResponse>(request);
        response.Task.FillLanguageCodesArray();

        return response.Task;
    }

    [Action("Get task", Description = "Get information about a specific task")]
    public async Task<TaskResponse> RetrieveTask([ActionParameter] ProjectRequest project,
        [ActionParameter] [Display("Task ID")] string taskId)
    {
        var endpoint = $"/projects/{project.ProjectId}/tasks/{taskId}";
        var request = new LokaliseRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithHandling<TaskRetriveResponse>(request);
        response.Task.FillLanguageCodesArray();

        return response.Task;
    }

    [Action("Update task", Description = "Update information on a specific task")]
    public async Task<TaskResponse> UpdateTask([ActionParameter] ProjectRequest project,
        [ActionParameter] [Display("Task ID")] string taskId,
        [ActionParameter] TaskUpdateInput input)
    {
        var endpoint = $"/projects/{project.ProjectId}/tasks/{taskId}";
        var request = new LokaliseRequest(endpoint, Method.Put, Creds)
            .WithJsonBody(new TaskUpdateRequest(input));

        var response = await Client.ExecuteWithHandling<TaskRetriveResponse>(request);
        response.Task.FillLanguageCodesArray();

        return response.Task;
    }

    [Action("Delete task", Description = "Delete a specific task")]
    public Task<TaskDeleteResponse> DeleteTask([ActionParameter] ProjectRequest input,
        [ActionParameter] [Display("Task ID")] string taskId)
    {
        var endpoint = $"/projects/{input.ProjectId}/tasks/{taskId}";
        var request = new LokaliseRequest(endpoint, Method.Delete, Creds);

        return Client.ExecuteWithHandling<TaskDeleteResponse>(request);
    }

    #endregion

    #region Utils

    private async Task<IEnumerable<string>> GetUntranslatedKeys(ProjectRequest project, IEnumerable<string> langs)
    {
        var keys = await new KeyActions(InvocationContext).ListProjectKeys(project, new()
        {
            IncludeTranslations = true,
            FilterUntranslated = true
        });

        return keys.Keys.Where(x =>
                x.Translations?.Any(y =>
                    langs.Contains(y.LanguageIso) && string.IsNullOrWhiteSpace(y.Translation)) is true ||
                (langs.Contains(x.SourceTranslation?.LanguageIso) &&
                 string.IsNullOrWhiteSpace(x.SourceTranslation?.Translation)))
            .Select(x => x.KeyId);
    }

    private async Task<IEnumerable<string>> GetUnverifiedKeys(ProjectRequest project, IEnumerable<string> langs)
    {
        var keys = await new KeyActions(InvocationContext).ListProjectKeys(project, new()
        {
            IncludeTranslations = true
        });

        return keys.Keys.Where(x =>
                x.Translations?.Any(y =>
                    langs.Contains(y.LanguageIso) && y.IsUnverified) is true ||
                (langs.Contains(x.SourceTranslation?.LanguageIso) && x.SourceTranslation?.IsUnverified is true))
            .Select(x => x.KeyId);
    }

    #endregion
}