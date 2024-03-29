﻿using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class LanguageDto
{
    [JsonProperty("lang_id")]
    [Display("Language ID")]
    public string LangId { get; set; }

    [JsonProperty("lang_iso")]
    [Display("Language code")]
    public string LangIso { get; set; }
        
    [JsonProperty("lang_name")]
    [Display("Language name")]
    public string LangName { get; set; }
        
    [JsonProperty("is_rtl")]
    [Display("Is rtl")]
    public bool IsRtl { get; set; }

}