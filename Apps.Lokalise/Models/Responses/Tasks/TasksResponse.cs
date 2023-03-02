namespace Apps.Lokalise.Models.Responses.Tasks;
public class TasksResponse
{
    public string ProjectId { get; set; }
    public List<TaskResponse> Tasks { get; set; }
}
