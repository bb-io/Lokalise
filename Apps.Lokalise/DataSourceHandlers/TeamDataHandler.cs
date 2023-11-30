using Apps.Lokalise.Dtos;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Responses.Teams;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Lokalise.DataSourceHandlers;

public class TeamDataHandler : LokaliseInvocable, IAsyncDataSourceHandler
{
    public TeamDataHandler(InvocationContext invocationContext)
        : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var items = await Paginator
            .GetAll<TeamsWrapper, TeamDto>(Creds, "/teams");

        return items
            .Where(x => context.SearchString == null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.TeamId, x => x.Name);
    }
}