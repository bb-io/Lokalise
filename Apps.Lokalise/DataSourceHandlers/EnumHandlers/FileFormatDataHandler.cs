using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Lokalise.DataSourceHandlers.EnumHandlers;

public class FileFormatDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "android_sdk", "Lokalise Android SDK bundle" },
        { "arb", "ARB" },
        { "csv", "Comma-separated values" },
        { "docx", "Docx" },
        { "flutter_sdk", "Lokalise Flutter SDK bundle" },
        { "html", "HTML" },
        { "ini", "PHP INI" },
        { "ios_sdk", "Lokalise iOS SDK bundle" },
        { "js", "JavaScript Object" },
        { "json", "JSON flat and JSON nested" },
        { "json_structured", "Structured JSON" },
        { "offline_xliff", "Offline XLIFF" },
        { "php_array", "PHP arrays" },
        { "php_laravel", "PHP Laravel" },
        { "plist", "Objective-C/Cocoa Properties" },
        { "po", "Gettext" },
        { "properties", "Java Properties" },
        { "react_native", "React Native (I18n library)" },
        { "resx", ".NET Resources" },
        { "ruby_yaml", "Ruby YAML" },
        { "stf", "Salesforce Translation" },
        { "strings", "Apple Strings" },
        { "symfony_xliff", "Symphony PHP XLIFF" },
        { "ts", "QT Linguist" },
        { "xlf", "Angular i18n XLIFF" },
        { "xliff", "Apple XLIFF" },
        { "xlsx", "Excel 2007" },
        { "xml", "Android Resources" },
        { "yaml", "YAML" }
    };
}