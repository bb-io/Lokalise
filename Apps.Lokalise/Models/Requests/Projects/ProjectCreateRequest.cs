using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Projects;

public class ProjectCreateRequest
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("team_id")]
    [Display("Team ID")]
    public long? TeamId { get; set; }

    [JsonPropertyName("description")] public string? Description { get; set; }

    [JsonPropertyName("languages")] public ProjectLanguage[]? Languages { get; set; }

    [JsonPropertyName("base_lang_iso")]
    [Display("Base project language")]
    public string? BaseLangIso { get; set; }

    [JsonPropertyName("project_type")]
    [Display("Project type")]
    public string? ProjectType { get; set; }

    [JsonPropertyName("is_segmentation_enabled")]
    [Display("Is segmentation enabled")]
    public bool? IsSegmentationEnabled { get; set; }
}