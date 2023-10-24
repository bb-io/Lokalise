using Apps.Lokalise.Webhooks.Models.EventResponse;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectBranchAddedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectBranchAddedPayload : BasePayload>(myJsonResponse);
public class Branch
{
    [JsonProperty("name")]
    [Display("Name")]
    public string Name { get; set; }
}

public class ProjectBranchAddedPayload : BasePayload
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