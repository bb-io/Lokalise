using Blackbird.Applications.Sdk.Common.Dictionaries;
namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class ExportSortDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "first_added", "First added" },
        { "last_added", "Last added" },
        { "last_updated", "Last updated" },
        { "a_z", "A-Z" },
        { "z_a", "Z-A" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}