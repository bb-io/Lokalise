using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class IndentationDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "default", "Default" },
        { "1sp", "1sp" },
        { "2sp", "2sp" },
        { "3sp", "3sp" },
        { "4sp", "4sp" },
        { "5sp", "5sp" },
        { "6sp", "6sp" },
        { "7sp", "7sp" },
        { "8sp", "8sp" },
        { "tab", "Tab" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}