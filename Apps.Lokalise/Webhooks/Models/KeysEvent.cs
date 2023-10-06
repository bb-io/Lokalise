using Apps.Lokalise.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models;

public class KeysEvent : BaseEvent
{
    [Display("Keys")]
    public List<KeyWithTags> Keys {get; set;}
}