namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationUpdatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTranslationUpdatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTranslationUpdatedPayload : BasePayload
    {
        public TranslationUpdated Translation { get; set; }
        public KeyName Key { get; set; }
        public Language Language { get; set; }
    }

    public class TranslationUpdated
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string PreviousValue { get; set; }
    }


}