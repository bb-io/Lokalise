﻿using Apps.Lokalise.Utils.Converters;
using Newtonsoft.Json;

namespace Apps.Lokalise.Extensions;

public static class ObjectExtensions
{
    public static Dictionary<string, string> AsLokaliseDictionary(this object obj)
    {
        var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
        {
            Converters = { new StringValueConverter() }
        });
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(json)!;
    }
    
    public static string AsLokaliseQuery(this object queryValue)
        => queryValue.ToString() switch
        {
            "True" => "1",
            "False" => "0",
            _ => queryValue.ToString()
        } ?? string.Empty;
}