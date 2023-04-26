namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectLanguagesAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectLanguagesAddedPayload : BasePayload>(myJsonResponse);

    public class ProjectLanguagesAddedPayload : BasePayload
    {
        public List<Language> Languages { get; set; }
    }


}