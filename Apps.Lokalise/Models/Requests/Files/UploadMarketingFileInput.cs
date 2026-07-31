using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Lokalise.Models.Requests.Files;

public class UploadMarketingFileInput
{
    [Display("HTML file", Description = "HTML file encoded as UTF-8. Files with .html and .htm extensions are supported.")]
    public FileReference File { get; set; } = default!;

    [Display("Language code", Description = "Language code of the content in the HTML file.")]
    [DataSource(typeof(LanguageDataHandler))]
    public string LanguageCode { get; set; } = string.Empty;

    [Display("Title", Description = "Title displayed in Lokalise. Defaults to the file name and must not exceed 256 characters.")]
    public string? Title { get; set; }
}
