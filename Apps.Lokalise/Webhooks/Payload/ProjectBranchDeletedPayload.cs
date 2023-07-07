using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectBranchDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectBranchDeletedPayload : BasePayload>(myJsonResponse);
    public class ProjectBranchDeletedPayload : BasePayload
    {
        public Branch Branch { get; set; }
        public override BranchEvent Convert()
        {
            return new BranchEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Name = Branch.Name,
            };
        }
    }


}