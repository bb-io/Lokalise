﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Apps.Lokalise.Constants;

public static class JsonConfig
{
    public static readonly JsonSerializerSettings SerializeSettings = new()
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy(),
        },
        DateFormatString = "yyyy-MM-dd HH:mm:ss",
        DefaultValueHandling = DefaultValueHandling.Ignore
    };   
    
    public static readonly JsonSerializerSettings DeserializeSettings = new()
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy(),
        },
        DateFormatString = "yyyy-MM-dd HH:mm:ss '(Etc/UTC)'",
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        DefaultValueHandling = DefaultValueHandling.Ignore
    };
}