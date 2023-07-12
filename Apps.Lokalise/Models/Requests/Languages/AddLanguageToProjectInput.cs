using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Languages
{
    public class AddLanguageToProjectInput
    {
        [Display("Language code")]
        public string LanguageCode { get; set; }        
        
        [Display("Custom language code")]
        public string? CustomIso { get; set; }      
        
        [Display("Custom name")]
        public string? CustomName { get; set; }
        
        [Display("Custom plural forms")]
        public IEnumerable<string>? CustomPluralForms { get; set; }
    }
}
