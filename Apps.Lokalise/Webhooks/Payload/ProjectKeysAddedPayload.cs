namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeysAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeysAddedPayload : BasePayload>(myJsonResponse);

    public class ProjectKeysAddedPayload : BasePayload
    {
        public List<KeyWithTags> Keys { get; set; }
    }


}