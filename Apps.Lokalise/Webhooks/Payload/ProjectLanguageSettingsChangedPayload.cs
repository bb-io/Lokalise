using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectLanguageSettings_changedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectLanguageSettings_changedPayload : BasePayload>(myJsonResponse);
    public class ProjectLanguageSettingsChangedPayload : BasePayload
    {
        [JsonPropertyName("language")]
        public Language Language { get; set; }
    }


}