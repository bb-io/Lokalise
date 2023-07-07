using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectImportedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectImportedPayload : BasePayload>(myJsonResponse);
    public class Import
    {
        public string Filename { get; set; }
        public string Format { get; set; }
        public int Inserted { get; set; }
        public int Updated { get; set; }
        public int Skipped { get; set; }
    }

    public class ProjectImportedPayload : BasePayload
    {
        public Import Import { get; set; }

        public override ProjectImportedEvent Convert()
        {
            return new ProjectImportedEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Filename = Import.Filename,
                Format = Import.Format,
                Inserted = Import.Inserted,
                Updated = Import.Updated,
                Skipped = Import.Skipped
            };
        }
    }


}