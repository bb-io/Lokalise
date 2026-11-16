using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class TaskTypeDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "translation", "Translation" },
        { "review", "Review" },
        { "automatic_translation", "Automatic translation" },
        { "lqa_by_ai", "LQA by AI" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}
