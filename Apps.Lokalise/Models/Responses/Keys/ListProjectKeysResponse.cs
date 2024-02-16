using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Keys;

public record ListProjectKeysResponse(IEnumerable<KeyDto> Keys, [Display("Project ID")] string projectId);