using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.Models.Requests.Files;

public class DownloadSourceFilesRequest
{
    [StaticDataSource(typeof(FileFormatDataHandler))]
    public string Format { get; set; }
}