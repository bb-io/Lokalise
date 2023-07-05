using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks
{
    public class WebhookInput
    {
        [Display("Project ID")]
        public string ProjectId { get; set; }
    }
}
