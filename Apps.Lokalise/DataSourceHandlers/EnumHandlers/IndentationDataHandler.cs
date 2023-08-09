using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class IndentationDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
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
        { "tab", "Tab" },
    };
}