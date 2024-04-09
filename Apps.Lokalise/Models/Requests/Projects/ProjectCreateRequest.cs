using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Projects;

public class ProjectCreateRequest
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("team_id")]
    public long? TeamId { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }

    [JsonProperty("languages")] public IEnumerable<ProjectLanguage>? Languages { get; set; }

    [JsonProperty("base_lang_iso")]
    public string? BaseLangIso { get; set; }

    [JsonProperty("project_type")]
    [StaticDataSource(typeof(ProjectTypeDataHandler))]
    public string? ProjectType { get; set; }

    [JsonProperty("is_segmentation_enabled")]
    public bool? IsSegmentationEnabled { get; set; }
    
    public ProjectCreateRequest(ProjectCreateInput parameters)
    {
        Name = parameters.Name;
        TeamId = parameters.TeamId;
        Description = parameters.Description;
        BaseLangIso = parameters.BaseLangIso;
        ProjectType = parameters.ProjectType;
        IsSegmentationEnabled = parameters.IsSegmentationEnabled;
        Languages = parameters.Languages?.Select(x => new ProjectLanguage()
        {
            LangIso = x
        });
    }
}