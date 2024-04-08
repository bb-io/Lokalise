using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Projects;

public class ProjectCreateInput
{
    public string Name { get; set; }

    [Display("Team ID")] public long? TeamId { get; set; }

    public string? Description { get; set; }

    [DataSource(typeof(LanguageDataHandler))]
    public IEnumerable<string>? Languages { get; set; }

    [Display("Base project language")] public string? BaseLangIso { get; set; }

    [Display("Project type")]
    [StaticDataSource(typeof(ProjectTypeDataHandler))]
    public string? ProjectType { get; set; }

    [Display("Is segmentation enabled")] public bool? IsSegmentationEnabled { get; set; }
}