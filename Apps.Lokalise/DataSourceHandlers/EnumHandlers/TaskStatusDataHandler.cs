using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class TaskStatusDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "created", "Created" },
        { "queued", "Queued" },
        { "in_progress", "In progress" },
        { "completed", "Completed" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}