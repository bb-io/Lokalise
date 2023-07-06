using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskCreatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskCreatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskCreatedPayload : BasePayload
    {
        public Task Task { get; set; }
        public new TaskEvent Convert()
        {
            return new TaskEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                TaskId = Task.Id,
                Title= Task.Title,
                DueDate= Task.Due_date,
                Description= Task.Description,
            };
        }
    }

}