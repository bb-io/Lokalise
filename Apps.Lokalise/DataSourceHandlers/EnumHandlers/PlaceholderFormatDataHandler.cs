using Apps.Lokalise.DataSourceHandlers.Base;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class PlaceholderFormatDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "printf", "Printf" },
        { "ios", "IOS" },
        { "icu", "ICU" },
        { "net", "Net" },
        { "symfony", "Symfony" },
    };
}