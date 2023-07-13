using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectContributorAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectContributorAddedPayload : BasePayload>(myJsonResponse);
    public class Contributor
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class ProjectContributorAddedPayload : BasePayload
    {
        [JsonPropertyName("contributor")]
        public Contributor Contributor { get; set; }
    }


}