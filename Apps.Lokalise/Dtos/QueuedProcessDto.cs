using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Dtos
{
    public class QueuedProcessDto
    {
        public ProcessObj Process { get; set; }
    }

    public class ProcessObj
    {
        public string Process_id { get; set; }

        public string Status { get; set; }
    }
}
