using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Screenshots;

public class ScreenshotsResponse
{
    [JsonProperty("screenshots")]
    public IEnumerable<ScreenshotResponse> Screenshots { get; set; } = Array.Empty<ScreenshotResponse>();
}
