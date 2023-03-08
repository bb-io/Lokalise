using Apps.Lokalise.ModelConverters;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests;
public class ProjectListParameters
{
    public string FilterTeamId { get; set; }
    public string FilterNames { get; set; }
    [JsonConverter(typeof(BoolToBitConverter))]
    public bool IncludeStatistics { get; set; }
    [JsonConverter(typeof(BoolToBitConverter))]
    public bool IncludeSettings { get; set; }
    public int Limit { get; set; }
    public int Page { get; set; }
}
