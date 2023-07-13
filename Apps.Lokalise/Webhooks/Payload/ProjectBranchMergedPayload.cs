using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectBranchMergedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectBranchMergedPayload : BasePayload>(myJsonResponse);
    public class AffectedKeys
    {
        [JsonPropertyName("inserted_count")]
        [Display("Inserted count")]
        public int InsertedCount { get; set; }

        [JsonPropertyName("updated_count")]
        [Display("Updated count")]
        public int UpdatedCount { get; set; }
    }

    public class ProjectBranchMergedPayload : BasePayload
    {
        [JsonPropertyName("target_branch")]
        [Display("Target branch")]
        public TargetBranch TargetBranch { get; set; }

        [JsonPropertyName("branch")]
        [Display("Branch")]
        public Branch Branch { get; set; }

        [JsonPropertyName("affected_keys")]
        [Display("Affected keys")]
        public AffectedKeys AffectedKeys { get; set; }
    }

    public class TargetBranch
    {
        [JsonPropertyName("name")]
        [Display("Name")]
        public string Name { get; set; }
    }
}