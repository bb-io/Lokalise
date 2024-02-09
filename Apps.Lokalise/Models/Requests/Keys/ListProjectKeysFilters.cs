using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Keys;

public class ListProjectKeysFilters
{
    public bool? Unverified { get; set; }
    
    public bool? Unreviewed { get; set; }
    
    [Display("Exclude tags")]
    public IEnumerable<string>? TagsToSkip { get; set; }
    
    [Display("Untranslated language")]
    [DataSource(typeof(LanguageDataHandler))]
    public string? UntranslatedLanguage { get; set; }
    
    [Display("Unreviewed language")]
    [DataSource(typeof(LanguageDataHandler))]
    public string? UnreviewedLanguage { get; set; }
    
    [Display("Unverified language")]
    [DataSource(typeof(LanguageDataHandler))]
    public string? UnverifiedLanguage { get; set; }
}