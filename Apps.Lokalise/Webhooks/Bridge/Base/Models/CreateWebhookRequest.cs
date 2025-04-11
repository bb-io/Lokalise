using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Bridge.Base.Models
{
    public record CreateWebhookRequest(string Url, IEnumerable<string> SubscribedEvents);
}
