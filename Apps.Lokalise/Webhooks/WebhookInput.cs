using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Webhooks;

public class WebhookInput
{
    [Display("Project")]
    [DataSource(typeof(ProjectDataHandler))]
    public string ProjectId { get; set; }
}