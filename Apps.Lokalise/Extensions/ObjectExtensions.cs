using System.Text.Json;
using Apps.Lokalise.Utils.Converters;

namespace Apps.Lokalise.Extensions;

public static class ObjectExtensions
{
    public static Dictionary<string, string> AsDictionary(this object obj)
    {
        var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions()
        {
            Converters = { new StringValueConverter() }
        });
        return JsonSerializer.Deserialize<Dictionary<string, string>>(json)!;
    }
}