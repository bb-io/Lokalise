using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests
{
    public class ListAllFilesRequest
    {
        [Display("Project Id")]
        public string ProjectId { get; set; }

        [Display("Filename")]
        public string? FileNameFilter { get; set; }
    }
}
