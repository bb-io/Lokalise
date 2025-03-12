using Apps.Lokalise.Constants;
using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.Models.Requests.Tasks;
using Apps.Lokalise.Models.Requests.Tasks.Base;
using Apps.Lokalise.Models.Requests.Translations;
using Apps.Lokalise.Models.Responses.Keys;
using Apps.Lokalise.Models.Responses.Languages;
using Apps.Lokalise.Models.Responses.Tasks;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Exceptions;
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

    [Action("Get tasks", Description = "Get all tasks of a certain project")]
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
        [ActionParameter] TaskCreateRequest parameters,
        [ActionParameter] TaskAssigneesRequest assigneesRequest)
    {
        if (assigneesRequest.Users is null && assigneesRequest.Groups is null)
            throw new PluginMisconfigurationException("One of the inputs must be specified: Users or Groups");

        var endpoint = $"/projects/{project.ProjectId}/tasks";

        var payload = new TaskCreateWithMultLangsRequest(parameters, assigneesRequest);
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(payload, JsonConfig.SerializeSettings);

        var response = await Client.ExecuteWithHandling<TaskRetriveResponse>(request);
        response.Task.FillLanguageCodesArray();

        return response.Task;
    }

    [Action("Create task from the built languages", Description = "Create a new task from the built languages")]
    public async Task<TaskResponse> CreateTaskFromBuiltLangs([ActionParameter] ProjectRequest project,
        [ActionParameter] TaskFromBuiltLangsRequest parameters)
    {
        var endpoint = $"/projects/{project.ProjectId}/tasks";

        var payload = new TaskCreateWithMultLangsRequest(parameters);
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(payload, JsonConfig.SerializeSettings);

        var response = await Client.ExecuteWithHandling<TaskRetriveResponse>(request);
        response.Task.FillLanguageCodesArray();

        return response.Task;
    }

    [Action("Create language task", Description = "Create a new task with a single language for filtering keys and users")]
    public async Task<TaskResponse> CreateLanguageTask([ActionParameter] ProjectRequest project,
    [ActionParameter] LanguageTaskCreateRequest parameters,
    [ActionParameter] TaskAssigneesRequest assigneesRequest,
    [ActionParameter] FilterRequest filters)
    {
        if (assigneesRequest.Users is null && assigneesRequest.Groups is null)
            throw new PluginMisconfigurationException("One of the inputs must be specified: Users or Groups");

        // Getting project languages
        var languages = await Client.ExecutePaginated<LanguagesWrapper, LanguageDto>(new LokaliseRequest($"/projects/{project.ProjectId}/languages", Method.Get, Creds));

        var langId = languages.Find(x => x.LangIso == parameters.TargetLanguageIso)?.LangId;
        if (langId == null) throw new PluginMisconfigurationException($"Language {parameters.TargetLanguageIso} is not part of this project.");

        // Getting all the translations
        IEnumerable<string> keys = new List<string>();
        if (parameters.ParentTaskId == null)
        {
            var translationsRequest = new LokaliseRequest($"/projects/{project.ProjectId}/translations", Method.Get, Creds);
            translationsRequest.AddParameter("filter_lang_id", langId);

            if (filters.FilterIsReviewed.HasValue) translationsRequest.AddParameter("filter_is_reviewed", filters.FilterIsReviewed.Value ? 1 : 0);
            if (filters.FilterUnverified.HasValue) translationsRequest.AddParameter("filter_unverified", filters.FilterUnverified.Value ? 1 : 0);
            if (filters.FilterUntranslated.HasValue) translationsRequest.AddParameter("filter_untranslated", filters.FilterUntranslated.Value ? 1 : 0);

            var translations = await Client.ExecutePaginated<TranslationsWrapper, TranslationObj>(translationsRequest, 5000);

            keys = translations.Select(x => x.KeyId);
        }        

        // Create task
        var payload = new TaskCreateWithMultLangsRequest(parameters, assigneesRequest, keys);
        var request = new LokaliseRequest($"/projects/{project.ProjectId}/tasks", Method.Post, Creds)
            .WithJsonBody(payload, JsonConfig.SerializeSettings);

        var response = await Client.ExecuteWithHandling<TaskRetriveResponse>(request);
        response.Task.FillLanguageCodesArray();

        return response.Task;
    }

    [Action("Get task", Description = "Get information about a specific task")]
    public async Task<TaskResponse> RetrieveTask([ActionParameter] GetTaskRequest taskRequest, 
        [ActionParameter, Display("Team ID"), DataSource(typeof(TeamDataHandler))] string? teamId)
    {
        var endpoint = $"/projects/{taskRequest.ProjectId}/tasks/{taskRequest.TaskId}";
        var request = new LokaliseRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithHandling<TaskRetriveResponse>(request);
        if (response.Task == null)
        {
            throw new PluginMisconfigurationException($"Task with ID {taskRequest.TaskId} for project: {taskRequest.ProjectId} returned null.");
        }
        
        response.Task.FillLanguageCodesArray();

        if (!string.IsNullOrEmpty(teamId))
        {
            var groups = response.Task.Languages.SelectMany(x => x.Groups);
            
            var users = new List<User>();
            foreach (var item in groups)
            {
                var group = await GetGroupById(teamId, item.Id);
                var usersFromGroup = await GetUsers(teamId, group.Members);
                users.AddRange(usersFromGroup);
            }
            
            response.Task.Users.AddRange(users);
            response.Task.Users = response.Task.Users.Distinct().ToList();
        }

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

    private async Task<IEnumerable<string>> ListKeysForTask(ProjectRequest project, ListProjectKeysBaseRequest input)
    {
        var baseEndpoint = $"/projects/{project.ProjectId}/keys";
        var query = input.AsLokaliseDictionary().AllIsNotNull();

        var endpointWithQuery = baseEndpoint.WithQuery(query);
        var items = await Paginator.GetAll<KeysWrapper, KeyDto>(Creds, endpointWithQuery);

        return items.Select(x => x.KeyId);
    }

    #endregion
}