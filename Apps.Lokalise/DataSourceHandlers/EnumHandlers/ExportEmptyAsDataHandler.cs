using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class ExportEmptyAsDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "empty", "Empty" },
        { "base", "Base" },
        { "null", "Null" },
        { "skip", "Skip" }
    };
}