namespace Apps.Lokalise.Extensions;

public static class StringExtensions
{
    public static string AsLokaliseQuery(this string queryValue)
        => queryValue switch
        {
            "True" => "1",
            "False" => "0",
            _ => queryValue
        };
}