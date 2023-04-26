namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectBranchDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectBranchDeletedPayload : BasePayload>(myJsonResponse);
    public class ProjectBranchDeletedPayload : BasePayload
    {
        public Branch Branch { get; set; }
    }


}