using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectContributorDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectContributorDeletedPayload : BasePayload>(myJsonResponse);
    public class ProjectContributorDeletedPayload : BasePayload
    {
        [JsonPropertyName("contributor")]
        public Contributor Contributor { get; set; }
    }


}