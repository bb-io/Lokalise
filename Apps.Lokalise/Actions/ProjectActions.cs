using Apps.Lokalise.Extensions;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.Models.Responses.Projects;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class ProjectActions
{
    #region Fields

    private readonly LokaliseClient _client;

    #endregion

    #region Constructors

    public ProjectActions()
    {
        _client = new();
    }

    #endregion

    #region Actions

    [Action("List projects", Description = "Get a list of all projects")]
    public Task<ProjectsResponse> ListAllProjects(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ProjectListParameters parameters)
    {
        var request = new LokaliseRequest("/projects", Method.Get, authenticationCredentialsProviders);
        request.AddParameters(parameters.AsDictionary().AllIsNotNull());

        return _client.ExecuteWithHandling<ProjectsResponse>(request);
    }

    [Action("List projects by date", Description = "Get a list of all projects within a certain date range")]
    public async Task<ProjectsResponse> ProjectForDates(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ProjectFilterByDateRequest parameters)
    {
        var projects = await ListAllProjects(authenticationCredentialsProviders, parameters);

        return new()
        {
            Projects = projects.Projects.Where(proj =>
            {
                var dateTime = DateTime.Parse(string.Join(" ", proj.CreatedAt.Split(" ").Take(2)));
                return dateTime >= parameters.From && dateTime <= parameters.To;
            }).ToList()
        };
    }

    [Action("Create project", Description = "Create a new project")]
    public Task<ProjectResponse> CreateProject(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ProjectCreateRequest parameters)
    {
        var request = new
                LokaliseRequest("/projects", Method.Post, authenticationCredentialsProviders)
            .WithJsonBody(parameters);

        return _client.ExecuteWithHandling<ProjectResponse>(request);
    }

    [Action("Get project", Description = "Get the details of a project")]
    public Task<ProjectResponse> RetrieveProject(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ProjectRequest input)
    {
        var request = new LokaliseRequest($"/projects/{input.ProjectId}", Method.Get, authenticationCredentialsProviders);
        
        return _client.ExecuteWithHandling<ProjectResponse>(request);
    }

    [Action("Update project", Description = "Update a project with new information")]
    public Task<ProjectResponse> UpdateProject(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ProjectRequest input,
        [ActionParameter] ProjectUpdateRequest parameters)
    {
        var request = new 
            LokaliseRequest($"/projects/{input.ProjectId}", Method.Put, authenticationCredentialsProviders)
            .WithJsonBody(parameters);

        return _client.ExecuteWithHandling<ProjectResponse>(request);
    }

    [Action("Delete project", Description = "Delete a project")]
    public Task<ProjectDeleteResponse> DeleteProject(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ProjectRequest input)
    {
        var request = new LokaliseRequest($"/projects/{input.ProjectId}", Method.Delete, authenticationCredentialsProviders);
        
        return _client.ExecuteWithHandling<ProjectDeleteResponse>(request);
    }

    [Action("Empty project", Description = "Deletes all keys and translations from the project")]
    public Task<EmptyResponse> EmptyProject(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ProjectRequest input)
    {
        var request =
            new LokaliseRequest($"/projects/{input.ProjectId}/empty", Method.Put, authenticationCredentialsProviders);
        
        return _client.ExecuteWithHandling<EmptyResponse>(request);
    }

    #endregion
}