using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Projects
{
    public class DeleteFileRequest
    {
        [Display("Project ID")]
        public string ProjectId { get; set; }

        [Display("File ID")]
        public string FileId { get; set; }
    }
}
