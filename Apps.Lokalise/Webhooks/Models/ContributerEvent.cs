using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Models
{
    public class ContributerEvent : BaseEvent
    {
        [Display("Contributer email")]
        public string Email { get; set; }
    }
}
