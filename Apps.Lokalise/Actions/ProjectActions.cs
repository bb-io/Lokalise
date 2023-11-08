﻿using Apps.Lokalise.Extensions;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.Models.Responses.Projects;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.Extensions.System;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class ProjectActions : LokaliseInvocable
{
    public ProjectActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #region Actions

    [Action("List projects", Description = "Get a list of all projects")]
    public Task<ProjectsResponse> ListAllProjects([ActionParameter] ProjectListParameters parameters)
    {
        var query = parameters.AsLokaliseDictionary().AllIsNotNull();
        var endpoint = "/projects".WithQuery(query);

        var request = new LokaliseRequest(endpoint, Method.Get, Creds);
        return Client.ExecuteWithHandling<ProjectsResponse>(request);
    }

    [Action("List projects by date", Description = "Get a list of all projects within a certain date range")]
    public async Task<ProjectsResponse> ProjectForDates([ActionParameter] ProjectFilterByDateRequest parameters)
    {
        var projects = await ListAllProjects(parameters);

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
    public Task<ProjectResponse> CreateProject([ActionParameter] ProjectCreateInput parameters)
    {
        var request = new LokaliseRequest("/projects", Method.Post, Creds)
            .WithJsonBody(new ProjectCreateRequest(parameters));

        return Client.ExecuteWithHandling<ProjectResponse>(request);
    }

    [Action("Get project", Description = "Get the details of a project")]
    public Task<ProjectResponse> RetrieveProject([ActionParameter] ProjectRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}";
        var request = new LokaliseRequest(endpoint, Method.Get, Creds);

        return Client.ExecuteWithHandling<ProjectResponse>(request);
    }

    [Action("Update project", Description = "Update a project with new information")]
    public Task<ProjectResponse> UpdateProject([ActionParameter] ProjectRequest input,
        [ActionParameter] ProjectUpdateRequest parameters)
    {
        var endpoint = $"/projects/{input.ProjectId}";
        var request = new LokaliseRequest(endpoint, Method.Put, Creds)
            .WithJsonBody(parameters);

        return Client.ExecuteWithHandling<ProjectResponse>(request);
    }

    [Action("Delete project", Description = "Delete a project")]
    public Task<ProjectDeleteResponse> DeleteProject([ActionParameter] ProjectRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}";
        var request = new LokaliseRequest(endpoint, Method.Delete, Creds);

        return Client.ExecuteWithHandling<ProjectDeleteResponse>(request);
    }

    [Action("Empty project", Description = "Deletes all keys and translations from the project")]
    public Task<EmptyResponse> EmptyProject([ActionParameter] ProjectRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}/empty";
        var request = new LokaliseRequest(endpoint, Method.Put, Creds);

        return Client.ExecuteWithHandling<EmptyResponse>(request);
    }

    #endregion
}