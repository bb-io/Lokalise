using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Projects
{
    public class DeleteFileRequest
    {
        [Display("Project id")]
        public string ProjectId { get; set; }

        [Display("File id")]
        public string FileId { get; set; }
    }
}
