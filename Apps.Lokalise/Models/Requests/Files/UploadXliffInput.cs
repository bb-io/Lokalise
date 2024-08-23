using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Files;

public class UploadXliffInput : UploadFileInput
{
    [Display("Overwrite existing keys")]
    public bool? OverwriteExistingKeys { get; set; }
}