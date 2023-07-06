using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Models
{
    public class ProjectExportedEvent : BaseEvent
    {
        [Display("Filename")]
        public string Filename { get; set; }

        [Display("Type")]
        public string Type { get; set; }

        [Display("Platform")]
        public string Platform { get; set; }

    }
}
