using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskDeletedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskDeletedPayload : BasePayload
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
                //DueDate = Task.Due_date,
                Description = Task.Description,
            };
        }
    }

}