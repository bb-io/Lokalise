using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Webhooks.Models.Input;

public class WebhookInput
{
    [Display("Project")]
    [DataSource(typeof(ProjectDataHandler))]
    public string ProjectId { get; set; }
    
    [Display("User email")]
    public string? UserEmail { get; set; }
}