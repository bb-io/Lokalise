using Apps.Lokalise.DataSourceHandlers.Base;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class JavaPropertiesEncodingDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "utf-8", "UTF-8" },
        { "latin-1", "Latin-1" },
    };
}