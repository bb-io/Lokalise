using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationUpdatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTranslationUpdatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTranslationUpdatedPayload : BasePayload
    {
        [JsonPropertyName("translation")] public TranslationUpdated Translation { get; set; }
        [JsonPropertyName("key")] public KeyName Key { get; set; }
        [JsonPropertyName("language")] public Language Language { get; set; }
    }

    public class TranslationUpdated
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("value")] public string Value { get; set; }
        [JsonPropertyName("previous_value")] 
        [Display("Previous value")]
        public string PreviousValue { get; set; }
    }
}