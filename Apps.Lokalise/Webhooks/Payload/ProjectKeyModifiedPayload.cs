using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyModifiedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectKeyModifiedPayload : BasePayload>(myJsonResponse);

    public class KeyModified
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Display("Key name")]
        public string Name { get; set; }

        [JsonPropertyName("filenames")]
        [Display("Filenames")]
        public Filenames Filenames { get; set; }
        
        [JsonPropertyName("previous_name")]
        [Display("Previous name")]
        public string PreviousName { get; set; }
    }

    public class ProjectKeyModifiedPayload : BasePayload
    {
        [JsonPropertyName("key")]
        public KeyModified Key { get; set; }

        public override KeyModifiedEvent Convert()
        {
            return new KeyModifiedEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Id = Key.Id,
                Name = Key.Name,
                PreviousName = Key.PreviousName,
                IOS = Key.Filenames.Ios,
                Android= Key.Filenames.Android,
                Web = Key.Filenames.Web,
                Other= Key.Filenames.Other,
            };
        }
    }


}