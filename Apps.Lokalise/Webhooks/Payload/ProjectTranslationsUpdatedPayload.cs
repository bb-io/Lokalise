namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationsUpdatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTranslationsUpdatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTranslationsUpdatedPayload : BasePayload
    {
        public List<TranslationsUpdated> Translations { get; set; }
    }

    public class TranslationsUpdated
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string PreviousValue { get; set; }
        public Language Language { get; set; }
        public KeyName Key { get; set; }
    }


}