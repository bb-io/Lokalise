using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Translations;

public class TranslationRequest : ProjectRequest
{
    [Display("Translation ID")]
    public string TranslationId { get; set; }
}