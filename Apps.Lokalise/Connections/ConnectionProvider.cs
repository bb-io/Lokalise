using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Lokalise.Connections;
public class ConnectionProvider : IConnectionProvider
{
    public AuthenticationCredentialsProvider Create(IDictionary<string, string> connectionValues)
    {
        var credential = connectionValues.First(x => x.Key == ApiTokenKeyName);
        return new AuthenticationCredentialsProvider(
            AuthenticationCredentialsRequestLocation.Header,
            ApiTokenKeyName,
            credential.Value);
    }

    private const string ApiTokenKeyName = "X-Api-Token";

    public string ConnectionName => "Blackbird";

    public IEnumerable<string> ConnectionProperties => new[] { ApiTokenKeyName };
}