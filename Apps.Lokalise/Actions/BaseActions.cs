using Apps.Lokalise.Providers;

namespace Apps.Lokalise.Actions;
public abstract class BaseActions
{
    protected readonly HttpRequestProvider _httpRequestProvider;
    protected readonly Dictionary<string, string> _requestWithBodyHeaders;

    public BaseActions()
    {
        _httpRequestProvider = new HttpRequestProvider();
        _requestWithBodyHeaders = new Dictionary<string, string>
            {
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };
    }
}
