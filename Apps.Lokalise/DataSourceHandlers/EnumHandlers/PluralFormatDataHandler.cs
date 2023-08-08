using Apps.Lokalise.DataSourceHandlers.Base;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class PluralFormatDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "json_string", "JSON string" },
        { "icu", "ICU" },
        { "array", "Array" },
        { "generic", "Generic" },
        { "symfony", "Symfony" },
        { "i18next", "I18Next" },
        { "i18next_v4", "I18Next V4" },
    };
}