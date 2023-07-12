namespace Apps.Lokalise.Models.Requests.Tasks;
public class TaskListParameters
{
    public string? FilterTitle { get; set; }
    public string? FilterStatuses { get; set; }
    public int? Limit { get; set; }
    public int? Page { get; set; }
}
