using System.Text.Json.Serialization;
using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

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
    [DataSource(typeof(ProjectTypeDataHandler))]
    public string? ProjectType { get; set; }

    [JsonPropertyName("is_segmentation_enabled")]
    [Display("Is segmentation enabled")]
    public bool? IsSegmentationEnabled { get; set; }
}