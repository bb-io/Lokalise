using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Models
{
    public class KeyEvent : BaseEvent
    {
        [Display("Key ID")]
        public int Id { get; set; }

        [Display("Key name")]
        public string Name { get; set; }

        [Display("Key base value")]
        public string BaseValue { get; set; }

        [Display("Key tags")]
        public List<string> Tags { get; set; }
    }
}
