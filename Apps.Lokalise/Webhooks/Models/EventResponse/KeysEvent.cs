using Apps.Lokalise.Webhooks.Models.Payload;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class KeysEvent : BaseEvent
{
    [Display("Keys")]
    public List<KeyWithTags> Keys {get; set;}
}