using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apps.Lokalise.Utils.Converters;

public class IntToStringConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TryGetInt64(out long longValue) ? longValue.ToString() : reader.GetString();

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}