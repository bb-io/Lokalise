using Newtonsoft.Json;

namespace Apps.Lokalise.Utils.Converters;

public class IntToStringConverter : JsonConverter
{
    public override bool CanConvert(Type objectType) => true;

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Integer)
        {
            var intValue = Convert.ToInt64(reader.Value);
            return intValue.ToString();
        }

        if (reader.TokenType == JsonToken.Null)
            return null;

        throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }
}