using Apps.Lokalise.Webhooks.Models;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyAddedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectKeyAddedPayload : BasePayload>(myJsonResponse);
    public class KeyWithTags
    {
        [JsonProperty("id")]
        [Display("Key ID")]
        public int Id { get; set; }

        [JsonProperty("name")]
        [Display("Key name")]
        public string Name { get; set; }

        [JsonProperty("base_value")]
        [Display("Key base Value")]
        public string BaseValue { get; set; }

        [JsonProperty("tags")]
        [Display("Key tags")]
        public List<string> Tags { get; set; }
    }

    public class ProjectKeyAddedPayload : BasePayload
    {
        [JsonProperty("key")] public KeyWithTags Key { get; set; }

        public override KeyEvent Convert()
        {
            return new KeyEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Id = Key.Id,
                Name = Key.Name,
                BaseValue = Key.BaseValue,
                Tags = Key.Tags,
            };
        }
    }
}