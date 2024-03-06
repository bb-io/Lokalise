using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Keys;

public class ListProjectKeysFilters
{
    public bool? Unverified { get; set; }
    
    public bool? Reviewed { get; set; }
    
    [Display("Exclude tags")]
    public IEnumerable<string>? TagsToSkip { get; set; }
    
    [Display("Untranslated language")]
    [DataSource(typeof(LanguageDataHandler))]
    public string? UntranslatedLanguage { get; set; }
    
    [Display("Reviewed language")]
    [DataSource(typeof(LanguageDataHandler))]
    public string? ReviewedLanguage { get; set; }
    
    [Display("Unverified language")]
    [DataSource(typeof(LanguageDataHandler))]
    public string? UnverifiedLanguage { get; set; }
}