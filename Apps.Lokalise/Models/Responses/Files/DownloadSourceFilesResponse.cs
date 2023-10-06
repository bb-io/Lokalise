using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Lokalise.Models.Responses.Files;

public record DownloadSourceFilesResponse(IEnumerable<File> Files);