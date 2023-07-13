using System.Text.Json.Serialization;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeysAddedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectKeysAddedPayload : BasePayload>(myJsonResponse);

    public class ProjectKeysAddedPayload : BasePayload
    {
        [JsonPropertyName("keys")]
        public List<KeyWithTags> Keys { get; set; }

        public override KeysEvent Convert()
        {
            return new KeysEvent
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