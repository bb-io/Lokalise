using System.Text.Json;
using Apps.Lokalise.Utils.Converters;

namespace Apps.Lokalise.Extensions;

public static class ObjectExtensions
{
    public static Dictionary<string, string> AsLokaliseDictionary(this object obj)
    {
        var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions()
        {
            Converters = { new StringValueConverter() }
        });
        return JsonSerializer.Deserialize<Dictionary<string, string>>(json)!;
    }
    
    public static string AsLokaliseQuery(this object queryValue)
        => queryValue.ToString() switch
        {
            "True" => "1",
            "False" => "0",
            _ => queryValue.ToString()
        } ?? string.Empty;
}