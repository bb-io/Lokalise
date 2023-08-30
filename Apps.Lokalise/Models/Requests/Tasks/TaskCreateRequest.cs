using Apps.Lokalise.Models.Requests.Tasks.Base;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskCreateRequest : BaseTaskCreateRequest
{
    [Display("Language code")]
    public string LanguageIso { get; set; }

    [Display("Users")]
    public IEnumerable<string>? Users { get; set; }

    [Display("Groups")]
    public IEnumerable<string>? Groups { get; set; }
}