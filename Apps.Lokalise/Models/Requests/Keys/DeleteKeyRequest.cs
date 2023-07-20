using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Keys;

public class DeleteKeyRequest
{
    [Display("Key ID")]
    public int KeyId { get; set; }

    [Display("Project ID")]
    public string ProjectId { get; set; }
}