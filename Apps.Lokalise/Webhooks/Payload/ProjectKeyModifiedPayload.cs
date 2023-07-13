using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyModifiedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeyModifiedPayload : BasePayload>(myJsonResponse);

    public class KeyModified
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Display("Name")]
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
        [JsonPropertyName("name")]
        public KeyModified Key { get; set; }
    }


}