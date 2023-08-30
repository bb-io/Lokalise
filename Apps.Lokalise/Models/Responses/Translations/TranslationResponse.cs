using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Translations;

public class TranslationResponse
{
    [JsonProperty("translation")]
    public Translation Translation { get; set; }
}