using Apps.Lokalise.Webhooks.Models.EventResponse;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;
// ProjectKeyModifiedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectKeyModifiedPayload : BasePayload>(myJsonResponse);

public class KeyModified
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    [Display("Key name")]
    public string Name { get; set; }

    [JsonProperty("filenames")]
    [Display("Filenames")]
    public Filenames Filenames { get; set; }
        
    [JsonProperty("previous_name")]
    [Display("Previous name")]
    public string PreviousName { get; set; }
}

public class ProjectKeyModifiedPayload : BasePayload
{
    [JsonProperty("key")]
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