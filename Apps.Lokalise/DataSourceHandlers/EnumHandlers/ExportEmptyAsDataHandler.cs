using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class ExportEmptyAsDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "empty", "Empty" },
        { "base", "Base" },
        { "null", "Null" },
        { "skip", "Skip" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}