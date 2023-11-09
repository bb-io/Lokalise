using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Apps.Lokalise.Models.Requests.Tasks.Base;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskCreateRequest : BaseTaskCreateRequest
{
    [Display("Languages")]
    [DataSource(typeof(LanguageDataHandler))]
    public IEnumerable<string> Languages { get; set; }

    [Display("Users")]
    public IEnumerable<string>? Users { get; set; }

    [Display("Groups")]
    public IEnumerable<string>? Groups { get; set; }
    
    [JsonIgnore]
    [Display("Filter keys")]
    [DataSource(typeof(FilterKeysDataHandler))]
    public string? FilterKeys { get; set; }
}