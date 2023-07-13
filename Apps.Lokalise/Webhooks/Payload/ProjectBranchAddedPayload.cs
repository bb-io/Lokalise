using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectBranchAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectBranchAddedPayload : BasePayload>(myJsonResponse);
    public class Branch
    {
        [JsonPropertyName("name")]
        [Display("Name")]
        public string Name { get; set; }
    }

    public class ProjectBranchAddedPayload : BasePayload
    {
        [JsonPropertyName("branch")]
        [Display("Branch")]
        public Branch Branch { get; set; }
    }


}