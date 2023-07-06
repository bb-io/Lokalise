using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Models
{
    public class BranchMergeEvent : BaseEvent
    {
        [Display("Source branch name")]
        public string SourceBranchName { get; set; }

        [Display("Target branch name")]
        public string TargetBranchName { get; set; }

        [Display("Number of inserted keys")]
        public int InsertedCount { get; set; }

        [Display("Number of updated keys")]
        public int UpdatedCount { get; set; }
    }
}
