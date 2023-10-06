﻿using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class DownloadTaskXLIFFFileRequest : DownloadXLIFFFileRequest
    {
        [JsonProperty("filter_task_id")]
        [Display("Filter task ID")]
        public string FilterTaskId { get; set; }

        [Display("Language code")]
        [DataSource(typeof(LanguageDataHandler))]
        public string LanguageCode { get; set; }
    }
}
