using Apps.Lokalise.Webhooks.Models.Payload;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class AssigneeKeyModifiedEvent : BaseEvent
{
    public IEnumerable<KeyWithTags> Keys { get; set; }

    public AssigneeKeyModifiedEvent()
    {
    }

    public AssigneeKeyModifiedEvent(BaseEvent @event) : base(@event)
    {
    }
}