namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyModifiedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeyModifiedPayload : BasePayload>(myJsonResponse);

    public class KeyModified
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PreviousName { get; set; }
        public Filenames Filenames { get; set; }
    }

    public class ProjectKeyModifiedPayload : BasePayload
    {
        public KeyModified Key { get; set; }
    }


}