using Apps.Lokalise.Constants;
using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class FilterKeysDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        [LokaliseConstants.UntranslatedFilter] = "Untranslated",
        [LokaliseConstants.UnverifiedFilter] = "Unverified",
    };
}