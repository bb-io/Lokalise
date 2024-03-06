using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Webhooks.Models.Input;

public class CommentAddedWebhookInput : WebhookInput
{
    [Display("Key"), DataSource(typeof(KeysDataHandler))]
    public string? KeyId { get; set; }
}