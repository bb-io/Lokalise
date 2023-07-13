using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationsUpdatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTranslationsUpdatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTranslationsUpdatedPayload : BasePayload
    {
        [JsonPropertyName("translations")] public List<TranslationsUpdated> Translations { get; set; }
    }

    public class TranslationsUpdated
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("value")] public string Value { get; set; }

        [JsonPropertyName("previous_value")]
        [Display("Previous value")]
        public string PreviousValue { get; set; }

        [JsonPropertyName("language")] public Language Language { get; set; }
        [JsonPropertyName("key")] public KeyName Key { get; set; }
    }
}