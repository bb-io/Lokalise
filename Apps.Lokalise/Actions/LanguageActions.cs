using System.Web;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Languages;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.Models.Requests.Tasks;
using Apps.Lokalise.Models.Responses.Languages;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class LanguageActions : LokaliseInvocable
{
    public LanguageActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #region Actions

    [Action("List all system languages", Description = "List all system languages")]
    public Task<ListLanguagesResponse> ListSystemLanguages()
        => ListLanguages("/system/languages");

    [Action("List all project languages", Description = "List all project languages")]
    public Task<ListLanguagesResponse> ListProjectLanguages([ActionParameter] ProjectRequest input)
        => ListLanguages($"/projects/{input.ProjectId}/languages");

    [Action("Add language to project", Description = "Add language to project")]
    public Task AddLanguageToProject([ActionParameter] ProjectRequest project,
        [ActionParameter] AddLanguageToProjectInput input)
    {
        var endpoint = $"/projects/{project.ProjectId}/languages";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new AddLanguageToProjectRequest(input));

        return Client.ExecuteWithHandling(request);
    }

    [Action("Delete language from project", Description = "Delete language from project")]
    public Task DeleteLanguageFromProject([ActionParameter] DeleteLanguageFromProjectRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}/languages/{input.LanguageId}";
        var request = new LokaliseRequest(endpoint, Method.Delete, Creds);

        return Client.ExecuteWithHandling(request);
    }

    [Action("Build language", Description = "Build language object")]
    public BuildLanguageResponse BuildLanguage([ActionParameter] BuildLanguageRequest input)
    {
        if (input.Users is null && input.Groups is null)
            throw new("Either Users or Groups must be specified");

        return new()
        {
            Language = HttpUtility.HtmlEncode(JsonConvert.SerializeObject(new TaskLanguage()
            {
                LanguageIso = input.LanguageIso,
                Users = input.Users,
                Groups = input.Groups
            }))
        };
    }

    #endregion

    #region Utils

    private async Task<ListLanguagesResponse> ListLanguages(string endpoint)
    {
        var items = await Paginator.GetAll<LanguagesWrapper, LanguageDto>(Creds, endpoint);
        return new(items);
    }

    #endregion
}