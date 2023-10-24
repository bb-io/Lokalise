using Apps.Lokalise.Webhooks.Models.Payload;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class KeyEvent : BaseEvent
{
    public KeyWithTags Key { get; set; }
}