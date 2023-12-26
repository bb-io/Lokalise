using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Lokalise.Models.Responses.Files;

public record DownloadFilesResponse(IEnumerable<FileReference> Files);