using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Keys;

public class DeleteKeyRequest : ProjectRequest
{
    [Display("Key ID")]
    public int KeyId { get; set; }
}