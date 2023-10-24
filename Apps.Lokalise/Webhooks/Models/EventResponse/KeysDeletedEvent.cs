using Apps.Lokalise.Webhooks.Models.Payload;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class KeysDeletedEvent : BaseEvent
{
    [Display("Keys")]
    public List<Key> Keys { get; set; }
}