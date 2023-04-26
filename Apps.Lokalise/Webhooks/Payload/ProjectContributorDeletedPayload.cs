namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectContributorDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectContributorDeletedPayload : BasePayload>(myJsonResponse);
    public class ProjectContributorDeletedPayload : BasePayload
    {
        public Contributor Contributor { get; set; }
    }


}