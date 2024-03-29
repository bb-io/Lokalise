﻿using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.Models.Requests.Tasks.Base;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskCreateRequest : BaseTaskCreateRequest
{
    [Display("Languages")]
    [DataSource(typeof(LanguageDataHandler))]
    public IEnumerable<string> Languages { get; set; }
}