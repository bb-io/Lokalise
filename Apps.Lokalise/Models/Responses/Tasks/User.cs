using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Tasks;

public class User
{
    [JsonPropertyName("user_id")]
    [Display("User ID")]
    public int UserId { get; set; }

    [JsonPropertyName("email")]
    [Display("Email")]
    public string Email { get; set; }

    [JsonPropertyName("fullname")]
    [Display("Full name")]
    public string Fullname { get; set; }
}