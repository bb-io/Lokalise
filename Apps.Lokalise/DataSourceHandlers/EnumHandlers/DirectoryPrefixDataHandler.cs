using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class DirectoryPrefixDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> EnumValues => new()
    {
        { "%LANG_ISO%", "Language ISO" }
    };

    public Dictionary<string, string> GetData()
    {
        return EnumValues;
    }
}