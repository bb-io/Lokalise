namespace Apps.Lokalise.Extensions;

public static class DictionaryExtensions
{
    public static Dictionary<T, string> AllIsNotNull<T>(this IDictionary<T, string> dic) where T : notnull
        => dic
            .Where(x => !string.IsNullOrEmpty(x.Value))
            .ToDictionary(x => x.Key, x => x.Value);
}