using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apps.Lokalise.Utils.Converters;

public class IntToStringConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TryGetInt32(out int intValue))
            return intValue.ToString();

        if (reader.TryGetInt64(out long longValue))
            return longValue.ToString();
        
        return reader.GetString();
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}