namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeysDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeysDeletedPayload : BasePayload>(myJsonResponse);

    public class Key
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Filenames Filenames { get; set; }
    }

    public class ProjectKeysDeletedPayload : BasePayload
    {
        public List<Key> Keys { get; set; }
    }


}