using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Tasks;

public class User
{
    [JsonProperty("user_id")]
    [Display("User ID")]
    public string UserId { get; set; }

    [JsonProperty("email")]
    [Display("Email")]
    public string Email { get; set; }

    [JsonProperty("fullname")]
    [Display("Full name")]
    public string Fullname { get; set; }
}