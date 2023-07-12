using System.Text.Json.Serialization;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;

namespace Apps.Lokalise.Models.Responses.Languages;

public class LanguagesWrapper : PaginationResponse<LanguageDto>
{
    [JsonPropertyName("languages")]
    public override IEnumerable<LanguageDto> Items { get; set; }
}