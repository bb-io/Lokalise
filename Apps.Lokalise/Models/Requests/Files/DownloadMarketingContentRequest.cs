using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Files;

public class DownloadMarketingContentRequest
{
    [Display("File name", Description = "Original HTML file name, including the .html or .htm extension.")]
    public string FileName { get; set; } = string.Empty;

    [Display("Language code", Description = "Language of the translated content.")]
    [DataSource(typeof(LanguageDataHandler))]
    public string LanguageCode { get; set; } = string.Empty;
}
