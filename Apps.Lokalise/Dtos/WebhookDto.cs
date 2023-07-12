using System.Text.Json.Serialization;

namespace Apps.Lokalise.Dtos
{
    public class WebhookDto
    {
        [JsonPropertyName("webhook_id")]
        public string WebhookId { get; set; }
        public string Url { get; set; }
        public object Branch { get; set; }
        public string Secret { get; set; }
        public List<string> Events { get; set; }
    }

    public class WebhooksResponseWrapper
    {
        public IEnumerable<WebhookDto> Webhooks { get; set; }
    }
}
