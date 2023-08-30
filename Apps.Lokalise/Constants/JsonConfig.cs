using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Apps.Lokalise.Constants;

public static class JsonConfig
{
    public static readonly JsonSerializerSettings Settings = new()
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        DefaultValueHandling = DefaultValueHandling.Ignore
    };
}