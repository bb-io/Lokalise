using Apps.Lokalise.DataSourceHandlers.Base;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class TaskStatusDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "created", "Created" },
        { "queued", "Queued" },
        { "in_progress", "In progress" },
        { "completed", "Completed" }
    };
}