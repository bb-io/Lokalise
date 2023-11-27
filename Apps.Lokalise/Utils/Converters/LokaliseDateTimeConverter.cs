using Newtonsoft.Json;

namespace Apps.Lokalise.Utils.Converters;

public class LokaliseDateTimeConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(DateTime);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return DateTime.MinValue;

        if (reader.TokenType == JsonToken.Date)
            return (DateTime)reader.Value!;

        if (reader.TokenType == JsonToken.String)
        {
            var dateStr = (string)reader.Value!;
            if (DateTime.TryParse(dateStr, out DateTime result))
                return result;

            throw new JsonSerializationException($"Unable to parse date: {dateStr}");
        }

        throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing DateTime.");
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}