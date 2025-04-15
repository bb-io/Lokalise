using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.EventResponse
{
    public class UnifiedKey
    {
        [JsonProperty("id")]
        [Display("ID")]
        public int Id { get; set; }

        [JsonProperty("name")]
        [Display("Name")]
        public string Name { get; set; }

        [JsonProperty("base_value")]
        [Display("Base Value")]
        public string? BaseValue { get; set; }

        [JsonProperty("previous_name")]
        [Display("Previous Name")]
        public string? PreviousName { get; set; }

        [JsonProperty("tags")]
        [Display("Tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("filenames")]
        [Display("Filenames")]
        public Filenames Filenames { get; set; }

        [JsonProperty("hidden")]
        [Display("Hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("screenshots")]
        [Display("Screenshots")]
        public List<string>? Screenshots { get; set; }
    }

    public class Filenames
    {
        [JsonProperty("ios")]
        [Display("iOS Filename")]
        public string? IOS { get; set; }

        [JsonProperty("android")]
        [Display("Android Filename")]
        public string? Android { get; set; }

        [JsonProperty("web")]
        [Display("Web Filename")]
        public string? Web { get; set; }

        [JsonProperty("other")]
        [Display("Other Filename")]
        public string? Other { get; set; }
    }

    public class ProjectKeysUnifiedPayload : BasePayload
    {
        [JsonProperty("action")]
        [Display("Action")]
        public string Action { get; set; }

        [JsonProperty("keys")]
        [Display("Keys")]
        public List<UnifiedKey> Keys { get; set; }

        public override BaseEvent Convert()
        {
            return new ProjectKeysUnifiedEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.FullName,
                Action = this.Action,
                Keys = this.Keys
            };
        }
    }
    public class ProjectKeysUnifiedEvent : BaseEvent
    {
        [Display("Action")]
        public string Action { get; set; }

        [Display("Keys")]
        public IEnumerable<UnifiedKey> Keys { get; set; }
    }
}
