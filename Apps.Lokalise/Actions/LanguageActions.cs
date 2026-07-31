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
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Newtonsoft.Json;
using RestSharp;
using Task = System.Threading.Tasks.Task;

namespace Apps.Lokalise.Actions;

[ActionList("Languages")]
public class LanguageActions(InvocationContext invocationContext) : LokaliseInvocable(invocationContext)
{
    [Action("Get all project languages", Description = "Searches languages in a project")]
    public async Task<ListLanguagesResponse> ListProjectLanguages([ActionParameter] ProjectRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}/languages";
        var languages = await Paginator.GetAll<LanguagesWrapper, LanguageDto>(Creds, endpoint);
        return new(
            languages,
            languages.Select(l => l.LangIso));
    }

    [Action("Add language to project", Description = "Adds one or more languages to a project")]
    public Task AddLanguageToProject([ActionParameter] ProjectRequest project,
        [ActionParameter] AddLanguageToProjectInput input)
    {
        var endpoint = $"/projects/{project.ProjectId}/languages";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new AddLanguageToProjectRequest(input));

        return Client.ExecuteWithHandling(request);
    }

    [Action("Delete language from project", Description = "Deletes a language from a project")]
    public Task DeleteLanguageFromProject([ActionParameter] DeleteLanguageFromProjectRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}/languages/{input.LanguageId}";
        var request = new LokaliseRequest(endpoint, Method.Delete, Creds);

        return Client.ExecuteWithHandling(request);
    }

    [Action("Build language", Description = "Builds a language with user or group assignees for task creation")]
    public BuildLanguageResponse BuildLanguage([ActionParameter] BuildLanguageRequest input)
    {
        if (input.Users is null && input.Groups is null)
            throw new PluginMisconfigurationException("Either Users or Groups must be specified");

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
}
