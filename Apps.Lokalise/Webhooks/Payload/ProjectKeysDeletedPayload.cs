using System.Text.Json.Serialization;
using Apps.Lokalise.Webhooks.Models;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeysDeletedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectKeysDeletedPayload : BasePayload>(myJsonResponse);

    public class Key
    {
        [JsonPropertyName("id")]
        [Display("Key ID")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Display("Key name")]
        public string Name { get; set; }

        [JsonPropertyName("filenames")]
        [Display("Filenames")]
        public Filenames Filenames { get; set; }
    }

    public class ProjectKeysDeletedPayload : BasePayload
    {
        [JsonPropertyName("keys")]
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