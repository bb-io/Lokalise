using Apps.Lokalise.Dtos;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Tasks;
using Apps.Lokalise.Models.Responses.Teams;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Lokalise.DataSourceHandlers;

public class UserDataHandler : LokaliseInvocable, IAsyncDataSourceHandler
{
    private string TeamId { get; }

    public UserDataHandler(InvocationContext invocationContext, [ActionParameter] TaskAssigneesRequest input)
        : base(invocationContext)
    {
        TeamId = input.TeamId;
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(TeamId))
            throw new PluginMisconfigurationException("You must input Team first");

        var endpoint = $"/teams/{TeamId}/users";
        var items = await Paginator
            .GetAll<TeamUsersWrapper, UserDto>(Creds, endpoint);

        return items
            .Where(x => context.SearchString == null ||
                        x.Fullname.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.UserId, x => x.Fullname);
    }
}