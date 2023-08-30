using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Languages;

public class LanguagesWrapper : PaginationResponse<LanguageDto>
{
    [JsonProperty("languages")]
    public override IEnumerable<LanguageDto> Items { get; set; }
}