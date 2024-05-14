using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class JavaPropertiesSeparatorDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "=", "=" },
        { ":", ":" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}