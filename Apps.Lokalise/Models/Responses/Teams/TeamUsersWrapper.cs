using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Teams;

public class TeamUsersWrapper : PaginationResponse<UserDto>
{
    [JsonProperty("team_users")]
    public override IEnumerable<UserDto> Items { get; set; }
}