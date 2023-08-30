using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Keys;

public class KeysWrapper : PaginationResponse<KeyDto>
{
    [JsonProperty("keys")]
    public override IEnumerable<KeyDto> Items { get; set; }
}