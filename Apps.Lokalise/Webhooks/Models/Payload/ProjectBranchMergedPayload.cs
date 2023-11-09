using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectBranchMergedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectBranchMergedPayload : BasePayload>(myJsonResponse);
public class AffectedKeys
{
    [JsonProperty("inserted_count")]
    [Display("Inserted count")]
    public int InsertedCount { get; set; }

    [JsonProperty("updated_count")]
    [Display("Updated count")]
    public int UpdatedCount { get; set; }
}

public class ProjectBranchMergedPayload : BasePayload
{
    [JsonProperty("target_branch")]
    [Display("Target branch")]
    public TargetBranch TargetBranch { get; set; }

    [JsonProperty("branch")]
    [Display("Branch")]
    public Branch Branch { get; set; }

    [JsonProperty("affected_keys")]
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
            UpdatedCount = AffectedKeys.UpdatedCount
        };
    }
}

public class TargetBranch
{
    [JsonProperty("name")]
    [Display("Name")]
    public string Name { get; set; }
}