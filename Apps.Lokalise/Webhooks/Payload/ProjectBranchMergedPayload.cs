using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectBranchMergedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectBranchMergedPayload : BasePayload>(myJsonResponse);
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

        public override BranchMergeEvent Convert()
        {
            return new BranchMergeEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                SourceBranchName = Branch.Name,
                TargetBranchName = TargetBranch.Name,
                InsertedCount = AffectedKeys.InsertedCount,
                UpdatedCount = AffectedKeys.UpdatedCount,
            };
        }
    }

    public class TargetBranch
    {
        [JsonPropertyName("name")]
        [Display("Name")]
        public string Name { get; set; }
    }
}