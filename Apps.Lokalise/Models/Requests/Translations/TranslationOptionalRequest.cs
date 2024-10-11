using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Translations;

public class TranslationOptionalRequest
{
    [Display("Translation ID")]
    public string? TranslationId { get; set; }
}