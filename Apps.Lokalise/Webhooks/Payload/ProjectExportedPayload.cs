namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectExportedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectExportedPayload : BasePayload>(myJsonResponse);
    public class Export
    {
        public string Type { get; set; }
        public string Filename { get; set; }
        public string Platform { get; set; }
    }

    public class ProjectExportedPayload : BasePayload
    {
        public Export Export { get; set; }
    }


}