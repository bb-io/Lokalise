using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Payload
{
    public class BasePayload
    {
        [JsonProperty("event")]
        [Display("Event")]
        public string Event { get; set; }

        [JsonProperty("project")]
        [Display("Project")]
        public Project Project { get; set; }

        [JsonProperty("user")]
        [Display("User")]
        public User User { get; set; }

        [JsonProperty("created_at")]
        [Display("Created at")]
        public string CreatedAt { get; set; }

        [JsonProperty("created_at_timestamp")]
        [Display("Created at timestamp")]
        public int CreatedAtTimestamp { get; set; }
        public virtual BaseEvent Convert()
        {
            return new BaseEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
            };
        }
    }

    public class Project
    {
        [JsonProperty("id")]
        [Display("Id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        [Display("Name")]
        public string Name { get; set; }
    }

    public class User
    {
        [JsonProperty("email")]
        [Display("Email")]
        public string Email { get; set; }

        [JsonProperty("full_name")]
        [Display("Full name")]
        public string FullName { get; set; }
    }
}