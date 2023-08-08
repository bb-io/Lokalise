using Apps.Lokalise.DataSourceHandlers.Base;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class DirectoryPrefixDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "%LANG_ISO%", "Language ISO" }
    };
}