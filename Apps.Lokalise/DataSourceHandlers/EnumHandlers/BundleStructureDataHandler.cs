using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class BundleStructureDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        {"%LANG_ISO%", "Language ISO"},
        {"%LANG_NAME%", "Language name"},
        {"%FORMAT%", "Format"},
        {"%PROJECT_NAME%", "Project name"}
    };
}