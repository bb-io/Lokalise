using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Files;

public class DownloadSourceFilesRequest
{
    [DataSource(typeof(FileFormatDataHandler))]
    public string Format { get; set; }
}