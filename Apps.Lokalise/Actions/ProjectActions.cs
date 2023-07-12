using Apps.Lokalise.ModelConverters;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.Models.Responses.Projects;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class ProjectActions
{

    [Action("List projects", Description = "Get a list of all projects")]
    public ProjectsResponse? ListAllProjects(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                            [ActionParameter] ProjectListParameters parameters)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest("/projects", Method.Get, authenticationCredentialsProviders);
        request.AddParameters(SnakeCaseConverter.ModelToSnakeCaseKeyPair(parameters));
        var result = client.Get(request);
        return SnakeCaseConverter.Deserialize<ProjectsResponse>(result.Content);
    }

    [Action("List projects by date", Description = "Get a list of all projects within a certain date range")]
    public ProjectsResponse? ProjectForDates(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                        [ActionParameter] ProjectFilterByDateRequest parameters)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest("/projects", Method.Get, authenticationCredentialsProviders);
        var result = client.Get(request);
        var projects = SnakeCaseConverter.Deserialize<ProjectsResponse>(result.Content);

        projects.Projects = projects.Projects.Where(proj =>
        {
            var dateTime = DateTime.Parse(string.Join(" ", proj.CreatedAt.Split(" ").Take(2)));
            return dateTime >= parameters.From && dateTime <= parameters.To;
        }).ToList();

        return projects;
    }

    [Action("Create project", Description = "Create a new project")]
    public ProjectResponse? CreateProject(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                        [ActionParameter] ProjectCreateRequest? parameters)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest("/projects", Method.Post, authenticationCredentialsProviders);
        request.AddJsonBody(parameters);
        var result = client.Post(request);
        return SnakeCaseConverter.Deserialize<ProjectResponse>(result.Content);
    }

    [Action("Get project", Description = "Get the details of a project")]
    public ProjectResponse? RetrieveProject(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                    [ActionParameter]string projectId)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest($"/projects/{projectId}", Method.Get, authenticationCredentialsProviders);
        var result = client.Get(request);
        return SnakeCaseConverter.Deserialize<ProjectResponse>(result.Content);
    }

    [Action("Update project", Description = "Update a project with new information")]
    public ProjectResponse? UpdateProject(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                  [ActionParameter] string projectId,
                                  [ActionParameter] ProjectUpdateRequest parameters)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest($"/projects/{projectId}", Method.Put, authenticationCredentialsProviders);
        request.AddJsonBody(parameters);
        var result = client.Put(request);
        return SnakeCaseConverter.Deserialize<ProjectResponse>(result.Content);
    }

    [Action("Delete project", Description = "Delete a project")]
    public ProjectDeleteResponse? DeleteProject(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                [ActionParameter] string projectId)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest($"/projects/{projectId}", Method.Delete, authenticationCredentialsProviders);
        var result = client.Delete(request);
        return SnakeCaseConverter.Deserialize<ProjectDeleteResponse>(result.Content);

    }

    [Action("Empty project", Description = "Deletes all keys and translations from the project")]
    public EmptyResponse? EmptyProject(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                              [ActionParameter] string projectId)
    {
        var client = new LokaliseClient();
        var request = new LokaliseRequest($"/projects/{projectId}/empty", Method.Put, authenticationCredentialsProviders);
        var result = client.Put(request);
        return SnakeCaseConverter.Deserialize<EmptyResponse>(result.Content);
    }
}
