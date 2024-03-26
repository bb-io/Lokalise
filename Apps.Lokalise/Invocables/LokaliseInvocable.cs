using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Tasks;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Lokalise.Invocables;

public class LokaliseInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected LokaliseClient Client { get; }

    public LokaliseInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }
    
    protected async Task<FullGroupDto> GetGroupById(string teamId, string groupId)
    {
        var endpoint = $"/teams/{teamId}/groups/{groupId}";
        var request = new LokaliseRequest(endpoint, Method.Get, Creds);

        return await Client.ExecuteWithHandling<FullGroupDto>(request);
    }

    protected async Task<List<User>> GetUsers(string teamId, IEnumerable<string> userIds)
    {
        var users = new List<User>();
        
        foreach (var userId in userIds)
        {
            var endpoint = $"/teams/{teamId}/users/{userId}";
            var request = new LokaliseRequest(endpoint, Method.Get, Creds);

            var userWrapper = await Client.ExecuteWithHandling<UserTeamWrapper>(request);
            users.Add(userWrapper.TeamUser);
        }

        return users;
    }
}