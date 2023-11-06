using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Languages;

public class AddLanguageToProjectInput
{
    [Display("Language codes")]
    [DataSource(typeof(LanguageDataHandler))]
    public IEnumerable<string> LanguageCodes { get; set; }        
        
    // [Display("Custom language code")]
    // public string? CustomIso { get; set; }      
    //     
    // [Display("Custom name")]
    // public string? CustomName { get; set; }
    //     
    // [Display("Custom plural forms")]
    // public IEnumerable<string>? CustomPluralForms { get; set; }
}