using Apps.Lokalise.Webhooks.Models.EventResponse;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectImportedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectImportedPayload : BasePayload>(myJsonResponse);
public class Import
{
    [JsonProperty("filename")]
    [Display("Filename")]
    public string Filename { get; set; }

    [JsonProperty("format")]
    [Display("Format")]
    public string Format { get; set; }

    [JsonProperty("inserted")]
    [Display("Inserted")]
    public int Inserted { get; set; }

    [JsonProperty("updated")]
    [Display("Updated")]
    public int Updated { get; set; }

    [JsonProperty("skipped")]
    [Display("Skipped")]
    public int Skipped { get; set; }
}

public class ProjectImportedPayload : BasePayload
{
    [JsonProperty("import")]
    [Display("Import")]
    public Import Import { get; set; }

    public override ProjectImportedEvent Convert()
    {
        return new ProjectImportedEvent
        {
            ProjectId = Project.Id,
            ProjectName = Project.Name,
            UserEmail = User.Email,
            UserName = User.Email,
            Filename = Import.Filename,
            Format = Import.Format,
            Inserted = Import.Inserted,
            Updated = Import.Updated,
            Skipped = Import.Skipped
        };
    }
}