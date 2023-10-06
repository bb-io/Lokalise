using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class DownloadXLIFFFileRequest : DownloadTaskXLIFFFileRequest
    {
        [Display("Language code")]
        [DataSource(typeof(LanguageDataHandler))]
        public string LanguageCode { get; set; }
    }
}
