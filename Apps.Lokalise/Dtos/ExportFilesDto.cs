using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class ExportFilesDto
{
    [JsonProperty("project_id")]
    public string ProjectId { get; set; }

    [JsonProperty("bundle_url")]
    public string BundleUrl { get; set; }
}