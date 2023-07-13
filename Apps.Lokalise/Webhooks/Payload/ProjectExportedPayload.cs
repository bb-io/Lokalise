using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectExportedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectExportedPayload : BasePayload>(myJsonResponse);
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
    }
}