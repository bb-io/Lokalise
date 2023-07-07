using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectExportedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectExportedPayload : BasePayload>(myJsonResponse);
    public class Export
    {
        public string Type { get; set; }
        public string Filename { get; set; }
        public string Platform { get; set; }
    }

    public class ProjectExportedPayload : BasePayload
    {
        public Export Export { get; set; }

        public override ProjectExportedEvent Convert()
        {
            return new ProjectExportedEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Filename = Export.Filename,
                Type = Export.Type,
                Platform = Export.Platform,
            };
        }
    }


}