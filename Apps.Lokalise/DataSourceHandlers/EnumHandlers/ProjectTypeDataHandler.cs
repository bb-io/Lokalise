using Apps.Lokalise.DataSourceHandlers.Base;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class ProjectTypeDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "localization_files", "Localization files" },
        { "paged_documents", "Paged documents" }
    };
}