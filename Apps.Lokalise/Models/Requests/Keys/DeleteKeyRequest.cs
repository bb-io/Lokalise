using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Keys;

public class DeleteKeyRequest
{
    [Display("Key id")]
    public int KeyId { get; set; }

    [Display("Project id")]
    public string ProjectId { get; set; }
}