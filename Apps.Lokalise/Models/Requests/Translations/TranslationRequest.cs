using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Translations;

public class TranslationRequest
{
    [Display("Project ID")]
    public string ProjectId { get; set; }
    
    [Display("Translation ID")]
    public string TranslationId { get; set; }
}