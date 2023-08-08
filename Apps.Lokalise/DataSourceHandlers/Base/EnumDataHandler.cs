using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.DataSourceHandlers.Base;

public abstract class EnumDataHandler : IDataSourceHandler
{
    protected abstract Dictionary<string, string> EnumValues { get; }

    public Dictionary<string, string> GetData(DataSourceContext context)
    {
        return EnumValues
            .Where(x => context.SearchString == null ||
                        x.Value.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Key, x => x.Value);
    }
}