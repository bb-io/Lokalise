using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Bridge.Base.Models
{
    public class LokaliseWebhookResponseDto
    {
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("webhooks")]
        public List<LokaliseWebhookDto> Webhooks { get; set; }
    }

    public class LokaliseWebhookDto
    {
        [JsonProperty("webhook_id")]
        public string WebhookId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("branch")]
        public string? Branch { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("events")]
        public List<string> Events { get; set; }

        [JsonProperty("event_lang_map")]
        public List<object>? EventLangMap { get; set; }
    }
}
