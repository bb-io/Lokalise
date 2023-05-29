using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests
{
    public class UpdateSegmentRequest
    {
        public string ProjectId { get; set; }
        public string KeyId { get; set; }
        public string LanguageCode { get; set; }

        public string SegmentNumber { get; set; }

        public string NewValue { get; set; }
    }
}
