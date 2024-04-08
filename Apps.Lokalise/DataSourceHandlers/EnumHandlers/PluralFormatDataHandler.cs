using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class PluralFormatDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "json_string", "JSON string" },
        { "icu", "ICU" },
        { "array", "Array" },
        { "generic", "Generic" },
        { "symfony", "Symfony" },
        { "i18next", "I18Next" },
        { "i18next_v4", "I18Next V4" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}