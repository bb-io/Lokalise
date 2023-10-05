using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Files;

public class DownloadTranslatedFileRequest : DownloadFileRequest
{
    [Display("File name")] public string FileName { get; set; }
        
    [Display("Language code")] 
    [DataSource(typeof(LanguageDataHandler))]
    public string LanguageCode { get; set; }
}