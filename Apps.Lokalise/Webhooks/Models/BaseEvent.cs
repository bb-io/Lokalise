using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models
{
    public class BaseEvent
    {
        [Display("Project ID")]
        public string ProjectId { get; set; }

        [Display("Project name")]
        public string ProjectName { get; set; }

        [Display("User email")]
        public string UserEmail { get; set; }

        [Display("User name")]
        public string UserName { get; set; }
    }
}
