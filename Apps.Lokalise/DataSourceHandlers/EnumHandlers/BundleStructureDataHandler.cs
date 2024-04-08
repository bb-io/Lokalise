using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class BundleStructureDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        {"%LANG_ISO%", "Language ISO"},
        {"%LANG_NAME%", "Language name"},
        {"%FORMAT%", "Format"},
        {"%PROJECT_NAME%", "Project name"}
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}