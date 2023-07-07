using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskClosedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskClosedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskClosedPayload : BasePayload
    {
        public Task Task { get; set; }

        public override TaskEvent Convert()
        {
            return new TaskEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                TaskId = Task.Id,
                Title = Task.Title,
                DueDate = Task.Due_date,
                Description = Task.Description,
            };
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public DateTime Due_date { get; set; }
        public string Description { get; set; }
    }


}