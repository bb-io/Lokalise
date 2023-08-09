using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

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