using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Translations;

public class UpdateTranslationRequest
{
    [JsonPropertyName("translation")]
    [Display("Translation")]
    public string Translation { get; set; }

    [JsonPropertyName("is_unverified")]
    [Display("Is unverified")]
    public bool? IsUnverified { get; set; }

    [JsonPropertyName("is_reviewed")]
    [Display("Is reviewed")]
    public bool? IsReviewed { get; set; }

    [JsonPropertyName("custom_translation_status_ids")]
    [Display("Custom translation status IDs")]
    public IEnumerable<string>? CustomTranslationStatusIds { get; set; }
}