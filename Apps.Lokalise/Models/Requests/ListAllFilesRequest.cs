using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests
{
    public class ListAllFilesRequest
    {
        [Display("Project ID")]
        public string ProjectId { get; set; }

        [Display("Filename")]
        public string? FileNameFilter { get; set; }
    }
}
