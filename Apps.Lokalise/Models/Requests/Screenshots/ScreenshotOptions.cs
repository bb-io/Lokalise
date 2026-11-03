using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Screenshots;

public class ScreenshotOptions : ProjectRequest
{
    [Display("Tag")]
    public string? Tag { get; set; }

    [Display("Key IDs")]
    public IEnumerable<string>? KeyIds { get; set; }

    [Display("OCR", Description = "Recognize translations and attach matching keys. Defaults to yes.")]
    public bool? Ocr { get; set; }

    [Display("Description")]
    public string? Description { get; set; }
}
