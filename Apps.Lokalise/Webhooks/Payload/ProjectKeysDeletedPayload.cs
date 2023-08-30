using Apps.Lokalise.Webhooks.Models;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeysDeletedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectKeysDeletedPayload : BasePayload>(myJsonResponse);

    public class Key
    {
        [JsonProperty("id")]
        [Display("Key ID")]
        public int Id { get; set; }

        [JsonProperty("name")]
        [Display("Key name")]
        public string Name { get; set; }

        [JsonProperty("filenames")]
        [Display("Filenames")]
        public Filenames Filenames { get; set; }
    }

    public class ProjectKeysDeletedPayload : BasePayload
    {
        [JsonProperty("keys")]
        public List<Key> Keys { get; set; }

        public override KeysDeletedEvent Convert()
        {
            return new KeysDeletedEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Keys = Keys
            };
        }
    }


}