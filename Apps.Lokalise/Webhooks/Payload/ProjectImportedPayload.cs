using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectImportedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectImportedPayload : BasePayload>(myJsonResponse);
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
    }
}