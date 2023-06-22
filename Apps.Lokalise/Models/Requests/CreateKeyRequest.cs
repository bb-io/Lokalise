using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests
{
    public class CreateKeyRequest
    {
        [Display("Project ID")]
        public string ProjectId { get; set; }
        [Display("Key name")]
        public string KeyName { get; set; }
        [Display("Platforms")]
        public List<string> Platforms { get; set; }
    }
}
