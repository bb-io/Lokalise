using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class KeyCommentEvent : BaseEvent
{
    [Display("Key ID")]
    public string Id { get; set; }

    [Display("Key name")]
    public string Name { get; set; }

    [Display("Comment")]
    public string Comment { get; set; }
}