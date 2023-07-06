using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Models
{
    public class OrderEvent : BaseEvent
    {
        [Display("Order ID")]
        public string Id { get; set; }

        [Display("Provider")]
        public string Provider { get; set; }
    }
}
