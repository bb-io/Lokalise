using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Languages
{
    public class DeleteLanguageFromProjectRequest
    {
        [Display("Project ID")] public string ProjectId { get; set; }
        [Display("Language ID")] public string LanguageId { get; set; }
    }
}