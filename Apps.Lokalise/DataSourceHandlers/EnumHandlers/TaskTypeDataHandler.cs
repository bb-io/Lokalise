using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class TaskTypeDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "translation", "Translation" },
        { "review", "Review" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}