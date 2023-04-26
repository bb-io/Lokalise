namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeyAddedPayload : BasePayload>(myJsonResponse);
    public class KeyWithTags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BaseValue { get; set; }
        public List<string> Tags { get; set; }
    }

    public class ProjectKeyAddedPayload : BasePayload
    {
        public KeyWithTags Key { get; set; }
    }


}