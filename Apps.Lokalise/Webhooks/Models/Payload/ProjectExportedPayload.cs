using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectExportedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectExportedPayload : BasePayload>(myJsonResponse);
public class Export
{
    [JsonProperty("type")]
    [Display("Type")]
    public string Type { get; set; }

    [JsonProperty("filename")]
    [Display("Filename")]
    public string Filename { get; set; }

    [JsonProperty("platform")]
    [Display("Platform")]
    public string Platform { get; set; }
}

public class ProjectExportedPayload : BasePayload
{
    [JsonProperty("export")]
    [Display("Export")]
    public Export Export { get; set; }

    public override ProjectExportedEvent Convert()
    {
        return new ProjectExportedEvent
        {
            ProjectId = Project.Id,
            ProjectName = Project.Name,
            UserEmail = User.Email,
            UserName = User.Email,
            Filename = Export.Filename,
            Type = Export.Type,
            Platform = Export.Platform
        };
    }
}