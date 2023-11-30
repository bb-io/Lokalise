using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.Models.Requests.Tasks;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Languages;

public class BuildLanguageRequest : TaskAssigneesRequest
{
    [Display("Project")]
    [DataSource(typeof(ProjectDataHandler))]
    public string ProjectId { get; set; }
    
    [Display("Language code")]
    [DataSource(typeof(ProjectLanguageDataHandler))]
    public string LanguageIso { get; set; }
}