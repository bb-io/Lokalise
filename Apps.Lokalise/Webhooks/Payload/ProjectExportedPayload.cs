using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectExportedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectExportedPayload : BasePayload>(myJsonResponse);
    public class Export
    {
        [JsonPropertyName("type")]
        [Display("Type")]
        public string Type { get; set; }

        [JsonPropertyName("filename")]
        [Display("Filename")]
        public string Filename { get; set; }

        [JsonPropertyName("platform")]
        [Display("Platform")]
        public string Platform { get; set; }
    }

    public class ProjectExportedPayload : BasePayload
    {
        [JsonPropertyName("export")]
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
                Platform = Export.Platform,
            };
        }
    }
}