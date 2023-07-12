namespace Apps.Lokalise.Webhooks.Payload
{
    public class BasePayload
    {
        public string Event { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
        public string CreatedAt { get; set; }
        public int CreatedAtTimestamp { get; set; }
    }

    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class User
    {
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
