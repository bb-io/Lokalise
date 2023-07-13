using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectLanguagesAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectLanguagesAddedPayload : BasePayload>(myJsonResponse);

    public class ProjectLanguagesAddedPayload : BasePayload
    {
        [JsonPropertyName("languages")]
        public List<Language> Languages { get; set; }
    }


}