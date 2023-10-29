using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Webhooks.Models.Input;

public class WebhookUserInput
{
    [Display("Projects")]
    [DataSource(typeof(ProjectDataHandler))]
    public List<string> Projects { get; set; }

    [Display("User email")] public string UserEmail { get; set; }
}