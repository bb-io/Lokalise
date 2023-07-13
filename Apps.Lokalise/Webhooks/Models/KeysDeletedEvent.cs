using Apps.Lokalise.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models
{
    public class KeysDeletedEvent : BaseEvent
    {
        [Display("Keys")]
        public List<Key> Keys { get; set; }
    }
}
