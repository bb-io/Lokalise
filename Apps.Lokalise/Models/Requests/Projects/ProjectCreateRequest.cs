using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Projects;

public class ProjectCreateRequest
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("team_id")]
    [Display("Team ID")]
    public long? TeamId { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }

    [JsonProperty("languages")] public ProjectLanguage[]? Languages { get; set; }

    [JsonProperty("base_lang_iso")]
    [Display("Base project language")]
    public string? BaseLangIso { get; set; }

    [JsonProperty("project_type")]
    [Display("Project type")]
    [DataSource(typeof(ProjectTypeDataHandler))]
    public string? ProjectType { get; set; }

    [JsonProperty("is_segmentation_enabled")]
    [Display("Is segmentation enabled")]
    public bool? IsSegmentationEnabled { get; set; }
}