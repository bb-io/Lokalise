using Apps.Lokalise.Models.Responses.Tasks;
using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class UserTeamWrapper
{
    [JsonProperty("team_id")]
    public string TeamId { get; set; }

    [JsonProperty("team_user")]
    public User TeamUser { get; set; }
}