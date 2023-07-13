using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Apps.Lokalise.Extensions;

namespace Apps.Lokalise.Utils.Converters;

public class StringValueConverter : JsonConverter<object>
{
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        var properties = value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        writer.WriteStartObject();

        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(value);
            writer.WriteString(GetJsonPropertyName(property), propertyValue?.AsLokaliseQuery() ?? string.Empty);
        }

        writer.WriteEndObject();
    }

    private string GetJsonPropertyName(PropertyInfo property)
    {
        var jsonPropertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>();
        return jsonPropertyName?.Name ?? property.Name;
    }
}