using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class JavaPropertiesEncodingDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "utf-8", "UTF-8" },
        { "latin-1", "Latin-1" },
    };
}