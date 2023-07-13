using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectBranchDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectBranchDeletedPayload : BasePayload>(myJsonResponse);
    public class ProjectBranchDeletedPayload : BasePayload
    {
        [JsonPropertyName("branch")]
        [Display("Branch")]
        public Branch Branch { get; set; }
    }


}