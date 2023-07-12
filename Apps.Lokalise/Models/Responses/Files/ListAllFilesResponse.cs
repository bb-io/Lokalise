using Apps.Lokalise.Dtos;

namespace Apps.Lokalise.Models.Responses.Files
{
    public record ListAllFilesResponse(IEnumerable<FileInfoDto> Files);
}
