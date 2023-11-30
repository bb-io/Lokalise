using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskAssigneesRequest
{
    [Display("Team")]
    [DataSource(typeof(TeamDataHandler))]
    public string TeamId { get; set; }

    [Display("Users")]
    [DataSource(typeof(UserDataHandler))]
    public IEnumerable<string>? Users { get; set; }

    [Display("Groups")]
    [DataSource(typeof(GroupDataHandler))]
    public IEnumerable<string>? Groups { get; set; }
}