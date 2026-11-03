using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Screenshots;

public class ScreenshotResponse
{
    [JsonProperty("screenshot_id")]
    [Display("Screenshot ID")]
    public string ScreenshotId { get; set; } = null!;

    [JsonProperty("url")]
    public string Url { get; set; } = null!;
}

