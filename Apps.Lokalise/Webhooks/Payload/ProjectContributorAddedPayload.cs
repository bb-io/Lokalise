namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectContributorAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectContributorAddedPayload : BasePayload>(myJsonResponse);
    public class Contributor
    {
        public string Email { get; set; }
    }

    public class ProjectContributorAddedPayload : BasePayload
    {
        public Contributor Contributor { get; set; }
    }


}