using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Languages
{
    public class DeleteLanguageFromProjectRequest : ProjectRequest
    {
        [Display("Language ID")]
        public string LanguageId { get; set; }
    }
}