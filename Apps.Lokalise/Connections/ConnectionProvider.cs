using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Lokalise.Connections;
public class ConnectionProvider : IConnectionProvider
{
    public AuthenticationCredentialsProvider Create(IDictionary<string, string> connectionValues)
    {
        var credential = connectionValues.First(x => x.Key == "apiKey");
        return new AuthenticationCredentialsProvider(
            AuthenticationCredentialsRequestLocation.Header,
            "X-Api-Token", 
            credential.Value);
    }

    public string ConnectionName => "Blackbird";

    public IEnumerable<string> ConnectionProperties => new[] { "url", "apiKey" };
}