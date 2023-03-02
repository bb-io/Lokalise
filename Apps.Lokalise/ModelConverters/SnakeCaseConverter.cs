using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Apps.Lokalise.ModelConverters;

public static class SnakeCaseConverter
{
    public static TResult? Deserialize<TResult>(string? json) where TResult : class
    {
        if (json == null) return null;
        return JsonConvert.DeserializeObject<TResult>(json, jsonSerializerSettings);
    }

    public static string Serialize<TModel>(TModel? model) where TModel : class
    {
        if (model == null) return null;
        return JsonConvert.SerializeObject(model, jsonSerializerSettings);
    }

    public static Dictionary<string, string> ModelToSnakeCaseKeyPair<TModel>(TModel? model) where TModel : class
    {
        var json = JsonConvert.SerializeObject(model, jsonSerializerSettings);
        return JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
    }


    private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };
}
