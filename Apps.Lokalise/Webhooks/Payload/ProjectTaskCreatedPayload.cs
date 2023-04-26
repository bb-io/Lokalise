namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskCreatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskCreatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskCreatedPayload : BasePayload
    {
        public Task Task { get; set; }
    }

}