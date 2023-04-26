namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectLanguageRemovedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectLanguageRemovedPayload : BasePayload>(myJsonResponse);
    public class Language
    {
        public int Id { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
    }

    public class ProjectLanguageRemovedPayload : BasePayload
    {
        public Language Language { get; set; }
    }


}