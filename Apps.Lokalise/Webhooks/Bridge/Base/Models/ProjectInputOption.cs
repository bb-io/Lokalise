using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Bridge.Base.Models
{
    public class ProjectInputOption
    {
        [Display("Project ID")]
        [DataSource(typeof(ProjectDataHandler))]
        public string ProjectId { get; set; }
    }
}
