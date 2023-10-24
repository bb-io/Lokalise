using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class DownloadXLIFFFileRequest : DownloadTaskXLIFFFileRequest
    {
        [Display("Language code")]
        [DataSource(typeof(LanguageDataHandler))]
        public string LanguageCode { get; set; }
    }
}
