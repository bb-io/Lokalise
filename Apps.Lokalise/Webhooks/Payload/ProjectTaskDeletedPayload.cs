namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskDeletedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskDeletedPayload : BasePayload
    {
        public Task Task { get; set; }
    }

}