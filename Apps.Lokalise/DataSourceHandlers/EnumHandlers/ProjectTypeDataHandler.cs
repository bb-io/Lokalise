using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class ProjectTypeDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "localization_files", "Localization files" },
        { "paged_documents", "Paged documents" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}