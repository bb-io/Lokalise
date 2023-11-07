using Apps.Lokalise.Dtos;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Responses.Languages;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Lokalise.DataSourceHandlers;

public class LanguageDataHandler : LokaliseInvocable, IAsyncDataSourceHandler
{
    public LanguageDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var items = await Paginator
            .GetAll<LanguagesWrapper, LanguageDto>(Creds, "/system/languages");

        return items
            .Where(x => context.SearchString == null ||
                        x.LangName.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Take(20)
            .ToDictionary(x => x.LangIso, x => x.LangName);
    }
}