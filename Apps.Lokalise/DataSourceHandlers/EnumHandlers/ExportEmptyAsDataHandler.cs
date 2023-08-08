using Apps.Lokalise.DataSourceHandlers.Base;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class ExportEmptyAsDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "empty", "Empty" },
        { "base", "Base" },
        { "null", "Null" },
        { "skip", "Skip" },
    };
}