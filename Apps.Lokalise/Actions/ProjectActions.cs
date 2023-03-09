﻿using Apps.Lokalise.ModelConverters;
using Apps.Lokalise.Models.Requests;
using Apps.Lokalise.Models.Responses.Projects;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Lokalise.Actions;

[ActionList]
public class ProjectActions : BaseActions
{
    private readonly string ProjectsUrl = "https://api.lokalise.com/api2/projects";

    [Action]
    public ProjectsResponse? ListAllProjects(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                            [ActionParameter] ProjectListParameters projectListParameters)
    {
        var result = _httpRequestProvider.Get(
            ProjectsUrl,
            SnakeCaseConverter.ModelToSnakeCaseKeyPair(projectListParameters),
            authenticationCredentialsProvider);

        return SnakeCaseConverter.Deserialize<ProjectsResponse>(result.Content);
    }

    [Action]
    public ProjectsCollectionResponse? ProjectForDates(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                        [ActionParameter] ProjectFilterByDateRequest projectListParameters)
    {
        var result = _httpRequestProvider.Get(
            ProjectsUrl,
            null,
            authenticationCredentialsProvider);

        var projects = SnakeCaseConverter.Deserialize<ProjectsResponse>(result.Content);

        projects.Projects = projects.Projects.Where(proj =>
        {
            var dateTime = DateTime.Parse(string.Join(" ", proj.CreatedAt.Split(" ").Take(2)));
            return dateTime >= projectListParameters.From && dateTime <= projectListParameters.To;
        }).ToList();

        return new ProjectsCollectionResponse {
            Projects = projects
        };
    }

    [Action]
    public ProjectResponse? CreateProject(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                        [ActionParameter] ProjectCreateRequest? projectListParameters)
    {
        var result = _httpRequestProvider.Post(
            ProjectsUrl,
            null,
            _requestWithBodyHeaders,
            SnakeCaseConverter.Serialize(projectListParameters),
            authenticationCredentialsProvider);

        return SnakeCaseConverter.Deserialize<ProjectResponse>(result.Content);
    }

    [Action]
    public ProjectResponse? RetrieveProject(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                    [ActionParameter]string projectId)
    {
        var requestUrl = ProjectsUrl + $"/{projectId}";
        var result = _httpRequestProvider.Get(requestUrl, null, authenticationCredentialsProvider);
        return SnakeCaseConverter.Deserialize<ProjectResponse>(result.Content);
    }

    [Action]
    public ProjectResponse? UpdateProject(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                  [ActionParameter] string projectId,
                                  [ActionParameter] ProjectUpdateRequest projectListParameters)
    {
        var requestUrl = ProjectsUrl + $"/{projectId}";
        var result = _httpRequestProvider.Put(
            requestUrl,
            null,
            _requestWithBodyHeaders,
            SnakeCaseConverter.Serialize(projectListParameters),
            authenticationCredentialsProvider);

        return SnakeCaseConverter.Deserialize<ProjectResponse>(result.Content);
    }

    [Action]
    public ProjectDeleteResponse? DeleteProject(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                                [ActionParameter] string projectId)
    {
        var requestUrl = ProjectsUrl + $"/{projectId}";
        var result = _httpRequestProvider.Delete(requestUrl, _requestWithBodyHeaders, authenticationCredentialsProvider);
        return SnakeCaseConverter.Deserialize<ProjectDeleteResponse>(result.Content);
    }

    [Action]
    public EmptyResponse? EmptyProject(string token, AuthenticationCredentialsProvider authenticationCredentialsProvider,
                              [ActionParameter] string projectId)
    {
        var requestUrl = ProjectsUrl + $"/{projectId}/empty";
        var result = _httpRequestProvider.Put(
            requestUrl,
            null,
            _requestWithBodyHeaders,
            null,
            authenticationCredentialsProvider);

        return SnakeCaseConverter.Deserialize<EmptyResponse>(result.Content);
    }
}
