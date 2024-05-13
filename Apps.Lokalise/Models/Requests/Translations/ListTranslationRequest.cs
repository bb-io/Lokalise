using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.Models.Requests.Segments;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Translations
{
    public class ListTranslationRequest
    {
        [Display("Project")]
        [DataSource(typeof(ProjectDataHandler))]
        public string ProjectId { get; set; }
    }
}
