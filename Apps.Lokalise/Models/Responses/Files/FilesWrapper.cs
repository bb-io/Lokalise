using System.Text.Json.Serialization;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;

namespace Apps.Lokalise.Models.Responses.Files
{
    public class FilesWrapper : PaginationResponse<FileInfoDto>
    {
        [JsonPropertyName("files")]
        public override IEnumerable<FileInfoDto> Items { get; set; }
    }
}
