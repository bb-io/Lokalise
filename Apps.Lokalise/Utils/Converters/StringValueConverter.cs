using System.Reflection;
using Apps.Lokalise.Extensions;
using Newtonsoft.Json;

namespace Apps.Lokalise.Utils.Converters;

public class StringValueConverter : JsonConverter
{
    public override bool CanRead => false;

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override bool CanConvert(Type objectType) => true;

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var properties = value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        writer.WriteStartObject();

        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(value);
            var propertyName = GetJsonPropertyName(property);

            writer.WritePropertyName(propertyName);

            if (propertyValue != null)
            {
                writer.WriteValue(propertyValue.AsLokaliseQuery());
            }
            else
            {
                writer.WriteNull();
            }
        }

        writer.WriteEndObject();
    }

    private string GetJsonPropertyName(PropertyInfo property)
    {
        var jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();
        return jsonPropertyAttribute?.PropertyName ?? property.Name;
    }
}