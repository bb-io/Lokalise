using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Languages
{
    public class DeleteLanguageFromProjectRequest
    {
        [Display("Project id")] public string ProjectId { get; set; }
        [Display("Language id")] public string LanguageId { get; set; }
    }
}