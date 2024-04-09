using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class JavaPropertiesEncodingDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "utf-8", "UTF-8" },
        { "latin-1", "Latin-1" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}