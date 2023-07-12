using System.Text.Json.Serialization;

namespace Apps.Lokalise.Dtos
{
    public class ExportFilesDto
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("bundle_url")]
        public string BundleUrl { get; set; }
    }
}
