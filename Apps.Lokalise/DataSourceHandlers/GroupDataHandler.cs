using Apps.Lokalise.Dtos;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Tasks;
using Apps.Lokalise.Models.Responses.Teams;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Lokalise.DataSourceHandlers;

public class GroupDataHandler : LokaliseInvocable, IAsyncDataSourceHandler
{
    private string TeamId { get; }

    public GroupDataHandler(InvocationContext invocationContext, [ActionParameter] TaskAssigneesRequest input)
        : base(invocationContext)
    {
        TeamId = input.TeamId;
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(TeamId))
            throw new("You must input Team first");

        var endpoint = $"/teams/{TeamId}/groups";
        var items = await Paginator
            .GetAll<TeamGroupsWrapper, GroupDto>(Creds, endpoint);

        return items
            .Where(x => context.SearchString == null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.GroupId, x => x.Name);
    }
}