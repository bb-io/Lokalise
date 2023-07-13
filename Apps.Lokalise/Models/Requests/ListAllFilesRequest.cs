using Blackbird.Applications.Sdk.Common;

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
