using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class PlaceholderFormatDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "printf", "Printf" },
        { "ios", "IOS" },
        { "icu", "ICU" },
        { "net", "Net" },
        { "symfony", "Symfony" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}