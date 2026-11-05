using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Lokalise.Models.Requests.Screenshots;

public class ScreenshotsInput : ScreenshotOptions
{
    [Display("Screenshots")]
    public IEnumerable<FileReference> Screenshots { get; set; } = null!;
}
