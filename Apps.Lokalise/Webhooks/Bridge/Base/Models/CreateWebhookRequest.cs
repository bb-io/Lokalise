using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Bridge.Base.Models
{
    public record CreateWebhookRequest(
       [property: JsonProperty("url")] string Url,
       [property: JsonProperty("events")] IEnumerable<string> SubscribedEvents);
}
