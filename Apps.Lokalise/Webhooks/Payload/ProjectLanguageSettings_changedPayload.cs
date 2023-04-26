namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectLanguageSettings_changedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectLanguageSettings_changedPayload : BasePayload>(myJsonResponse);
    public class ProjectLanguageSettings_changedPayload : BasePayload
    {
        public Language Language { get; set; }
    }


}