using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Files;

public class FilesWrapper : PaginationResponse<FileInfoDto>
{
    [JsonProperty("files")]
    public override IEnumerable<FileInfoDto> Items { get; set; }
}