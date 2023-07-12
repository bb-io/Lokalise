using System.Text.Json.Serialization;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;

namespace Apps.Lokalise.Models.Responses.Keys;

public class KeysWrapper : PaginationResponse<KeyDto>
{
    [JsonPropertyName("keys")]
    public override IEnumerable<KeyDto> Items { get; set; }
}