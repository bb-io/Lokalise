using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectBranchAddedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectBranchAddedPayload : BasePayload>(myJsonResponse);
    public class Branch
    {
        [JsonPropertyName("name")]
        [Display("Name")]
        public string Name { get; set; }
    }

    public class ProjectBranchAddedPayload : BasePayload
    {
        [JsonPropertyName("branch")]
        [Display("Branch")]
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