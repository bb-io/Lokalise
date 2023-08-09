using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class ExportSortDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "first_added", "First added" },
        { "last_added", "Last added" },
        { "last_updated", "Last updated" },
        { "a_z", "A-Z" },
        { "z_a", "Z-A" },
    };
}