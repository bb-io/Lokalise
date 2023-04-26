namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectBranchAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectBranchAddedPayload : BasePayload>(myJsonResponse);
    public class Branch
    {
        public string Name { get; set; }
    }

    public class ProjectBranchAddedPayload : BasePayload
    {
        public Branch Branch { get; set; }
    }


}