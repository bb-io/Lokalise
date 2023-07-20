using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Responses.Translations;

public class TranslationResponse
{
    [JsonPropertyName("translation")]
    public Translation Translation { get; set; }
}