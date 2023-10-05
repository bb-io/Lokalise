using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Payload;

// ProjectBranchDeletedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectBranchDeletedPayload : BasePayload>(myJsonResponse);
public class ProjectBranchDeletedPayload : BasePayload
{
    [JsonProperty("branch")]
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