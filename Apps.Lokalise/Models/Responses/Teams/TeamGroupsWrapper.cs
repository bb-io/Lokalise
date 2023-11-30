using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Teams;

public class TeamGroupsWrapper : PaginationResponse<GroupDto>
{
    [JsonProperty("user_groups")]
    public override IEnumerable<GroupDto> Items { get; set; }
}