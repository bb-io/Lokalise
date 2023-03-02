using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Connections;
public class ConnectionProviderFactory : IConnectionProviderFactory
{
    public IEnumerable<IConnectionProvider> Create()
    {
        yield return new ConnectionProvider();
    }
}
