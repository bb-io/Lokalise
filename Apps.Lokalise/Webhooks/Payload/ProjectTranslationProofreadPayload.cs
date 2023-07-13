using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationProofreadPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTranslationProofreadPayload : BasePayload>(myJsonResponse);
    public class KeyName
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
    }

    public class ProjectTranslationProofreadPayload : BasePayload
    {
        [JsonPropertyName("translation")] public Translation Translation { get; set; }
        [JsonPropertyName("key")] public KeyName Key { get; set; }
        [JsonPropertyName("language")] public Language Language { get; set; }
    }

    public class Translation
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("value")] public string Value { get; set; }
        [JsonPropertyName("is_proofread")] 
        [Display("Is proofread")]
        public bool IsProofread { get; set; }
    }
}