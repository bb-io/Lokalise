using Apps.Lokalise.Dtos;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Languages;
using Apps.Lokalise.Models.Responses.Languages;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Lokalise.DataSourceHandlers;

public class ProjectLanguageDataHandler : LokaliseInvocable, IAsyncDataSourceHandler
{
    private string ProjectId { get; }

    public ProjectLanguageDataHandler(InvocationContext invocationContext, [ActionParameter] BuildLanguageRequest input)
        : base(invocationContext)
    {
        ProjectId = input.ProjectId;
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(ProjectId))
            throw new PluginMisconfigurationException("You must input Project first");

        var endpoint = $"/projects/{ProjectId}/languages";
        var langs = await Paginator
            .GetAll<LanguagesWrapper, LanguageDto>(Creds, endpoint);

        return langs
            .Where(x => context.SearchString == null ||
                        x.LangName.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.LangIso, x => x.LangName);
    }
}