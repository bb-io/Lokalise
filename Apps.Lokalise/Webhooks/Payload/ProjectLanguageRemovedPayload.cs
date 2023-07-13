using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectLanguageRemovedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectLanguageRemovedPayload : BasePayload>(myJsonResponse);
    public class Language
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("iso")] public string Iso { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
    }

    public class ProjectLanguageRemovedPayload : BasePayload
    {
        [JsonPropertyName("language")] public Language Language { get; set; }
    }
}