using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeysDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeysDeletedPayload : BasePayload>(myJsonResponse);

    public class Key
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Display("Name")]
        public string Name { get; set; }

        [JsonPropertyName("filenames")]
        [Display("Filenames")]
        public Filenames Filenames { get; set; }
    }

    public class ProjectKeysDeletedPayload : BasePayload
    {
        [JsonPropertyName("keys")]
        public List<Key> Keys { get; set; }
    }


}