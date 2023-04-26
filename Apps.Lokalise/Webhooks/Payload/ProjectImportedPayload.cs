namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectImportedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectImportedPayload : BasePayload>(myJsonResponse);
    public class Import
    {
        public string Filename { get; set; }
        public string Format { get; set; }
        public int Inserted { get; set; }
        public int Updated { get; set; }
        public int Skipped { get; set; }
    }

    public class ProjectImportedPayload : BasePayload
    {
        public Import Import { get; set; }
    }


}