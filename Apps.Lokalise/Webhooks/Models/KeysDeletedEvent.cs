using Apps.Lokalise.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Models
{
    public class KeysDeletedEvent : BaseEvent
    {
        [Display("Keys")]
        public List<Key> Keys { get; set; }
    }
}
