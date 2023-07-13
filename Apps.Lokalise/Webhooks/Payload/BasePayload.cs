using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    public class BasePayload
    {
        [JsonPropertyName("event")]
        [Display("Event")]
        public string Event { get; set; }

        [JsonPropertyName("project")]
        [Display("Project")]
        public Project Project { get; set; }

        [JsonPropertyName("user")]
        [Display("User")]
        public User User { get; set; }

        [JsonPropertyName("created_at")]
        [Display("Created at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("created_at_timestamp")]
        [Display("Created at timestamp")]
        public int CreatedAtTimestamp { get; set; }
    }

    public class Project
    {
        [JsonPropertyName("id")]
        [Display("Id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        [Display("Name")]
        public string Name { get; set; }
    }

    public class User
    {
        [JsonPropertyName("email")]
        [Display("Email")]
        public string Email { get; set; }

        [JsonPropertyName("full_name")]
        [Display("Full name")]
        public string FullName { get; set; }
    }
}