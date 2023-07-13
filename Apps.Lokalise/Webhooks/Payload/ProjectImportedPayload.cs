using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectImportedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectImportedPayload : BasePayload>(myJsonResponse);
    public class Import
    {
        [JsonPropertyName("filename")]
        [Display("Filename")]
        public string Filename { get; set; }

        [JsonPropertyName("format")]
        [Display("Format")]
        public string Format { get; set; }

        [JsonPropertyName("inserted")]
        [Display("Inserted")]
        public int Inserted { get; set; }

        [JsonPropertyName("updated")]
        [Display("Updated")]
        public int Updated { get; set; }

        [JsonPropertyName("skipped")]
        [Display("Skipped")]
        public int Skipped { get; set; }
    }

    public class ProjectImportedPayload : BasePayload
    {
        [JsonPropertyName("import")]
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
}