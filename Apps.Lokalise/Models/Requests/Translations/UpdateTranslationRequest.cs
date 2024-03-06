using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Translations;

public class UpdateTranslationRequest
{
    [JsonProperty("translation")]
    [Display("Translation text")]
    public string Translation { get; set; }

    [JsonProperty("is_unverified")]
    [Display("Is unverified")]
    public bool? IsUnverified { get; set; }

    [JsonProperty("is_reviewed")]
    [Display("Is reviewed")]
    public bool? IsReviewed { get; set; }

    [JsonProperty("custom_translation_status_ids")]
    [Display("Custom translation status IDs")]
    public IEnumerable<string>? CustomTranslationStatusIds { get; set; }
}