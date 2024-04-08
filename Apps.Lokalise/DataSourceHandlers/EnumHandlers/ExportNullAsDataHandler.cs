using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class ExportNullAsDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "null", "Null" },
        { "empty", "Empty" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}