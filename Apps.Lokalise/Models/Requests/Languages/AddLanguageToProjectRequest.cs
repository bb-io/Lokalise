﻿using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Languages;

public class AddLanguageToProjectRequest
{
    [JsonProperty("languages")] public IEnumerable<AddLanguageData> Languages { get; set; }

    public AddLanguageToProjectRequest(AddLanguageToProjectInput input)
    {
        Languages = new[] { new AddLanguageData(input) };
    }
}