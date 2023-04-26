namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationProofreadPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTranslationProofreadPayload : BasePayload>(myJsonResponse);
    public class KeyName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProjectTranslationProofreadPayload : BasePayload
    {
        public Translation Translation { get; set; }
        public KeyName Key { get; set; }
        public Language Language { get; set; }
    }

    public class Translation
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsProofread { get; set; }
    }


}