using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class DownloadTranslatedFileRequest : DownloadFileRequest
    {
        public string Format { get; set; }
        [Display("File name")] public string FileName { get; set; }
        [Display("Language code")] public string LanguageCode { get; set; }
    }
}