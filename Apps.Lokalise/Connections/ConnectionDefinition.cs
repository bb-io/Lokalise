using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.Lokalise.Connections;

public class ConnectionDefinition : IConnectionDefinition
{
    public IEnumerable<ConnectionPropertyGroup> ConnectionPropertyGroups => new List<ConnectionPropertyGroup>
    {
        new()
        {
            Name = "Developer API token",
            AuthenticationType = ConnectionAuthenticationType.Undefined,
            ConnectionUsage = ConnectionUsage.Actions,
            ConnectionProperties = new List<ConnectionProperty>
            {
                new("apiToken") { DisplayName = "API Token" },
            }
        }
    };

    public IEnumerable<AuthenticationCredentialsProvider> CreateAuthorizationCredentialsProviders(
        Dictionary<string, string> values)
    {
        var apiToken = values.First(v => v.Key == "apiToken");
        yield return new AuthenticationCredentialsProvider(
            AuthenticationCredentialsRequestLocation.None,
            apiToken.Key,
            apiToken.Value
        );
    }
}