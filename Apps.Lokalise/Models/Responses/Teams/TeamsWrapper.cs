using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Teams;

public class TeamsWrapper : PaginationResponse<TeamDto>
{
    [JsonProperty("teams")]
    public override IEnumerable<TeamDto> Items { get; set; }
}