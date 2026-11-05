using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Lokalise.Models.Requests.Screenshots;

public class ScreenshotInput : ScreenshotOptions
{
    [Display("Screenshot")]
    public FileReference Screenshot { get; set; } = null!;
}
