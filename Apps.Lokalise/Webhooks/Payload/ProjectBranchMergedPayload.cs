using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectBranchMergedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectBranchMergedPayload : BasePayload>(myJsonResponse);
    public class AffectedKeys
    {
        public int InsertedCount { get; set; }
        public int UpdatedCount { get; set; }
    }

    public class ProjectBranchMergedPayload : BasePayload
    {
        public TargetBranch TargetBranch { get; set; }
        public Branch Branch { get; set; }
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
        public string Name { get; set; }
    }


}