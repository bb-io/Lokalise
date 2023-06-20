namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskClosedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskClosedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskClosedPayload : BasePayload
    {
        public Task Task { get; set; }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        //public string Due_date { get; set; }
        public string Description { get; set; }
    }


}