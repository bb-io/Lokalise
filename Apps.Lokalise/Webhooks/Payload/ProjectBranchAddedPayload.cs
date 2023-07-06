using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectBranchAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectBranchAddedPayload : BasePayload>(myJsonResponse);
    public class Branch
    {
        public string Name { get; set; }
    }

    public class ProjectBranchAddedPayload : BasePayload
    {
        public Branch Branch { get; set; }

        public new BranchEvent Convert()
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