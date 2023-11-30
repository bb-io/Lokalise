using Apps.Lokalise.Models.Requests.Tasks.Base;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskFromBuiltLangsRequest : BaseTaskCreateRequest
{
    [Display("Languages (from 'Build language' action)")]
    public IEnumerable<string> Languages { get; set; }
}