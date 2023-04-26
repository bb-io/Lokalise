namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskLanguageClosedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskLanguageClosedPayload : BasePayload>(myJsonResponse);

    public class ProjectTaskLanguageClosedPayload : BasePayload
    {
        public Task Task { get; set; }
        public Language Language { get; set; }
    }

}