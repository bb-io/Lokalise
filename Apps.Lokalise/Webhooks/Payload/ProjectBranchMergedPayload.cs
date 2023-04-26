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
    }

    public class TargetBranch
    {
        public string Name { get; set; }
    }


}