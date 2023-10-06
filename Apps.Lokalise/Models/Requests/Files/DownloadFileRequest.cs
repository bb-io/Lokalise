using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Apps.Lokalise.Models.Responses.Files;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Files;

public class DownloadFileRequest
{
    [JsonProperty("format")]
    [DataSource(typeof(FileFormatDataHandler))]
    public string Format { get; set; }

    [JsonProperty("original_filenames")]
    [Display("Original filenames")]
    public bool? OriginalFilenames { get; set; }

    [JsonProperty("bundle_structure")]
    [Display("Bundle structure")]
    [DataSource(typeof(BundleStructureDataHandler))]
    public string? BundleStructure { get; set; }

    [JsonProperty("directory_prefix")]
    [Display("Directory prefix")]
    [DataSource(typeof(DirectoryPrefixDataHandler))]
    public string? DirectoryPrefix { get; set; }

    [JsonProperty("all_platforms")]
    [Display("All platforms")]
    public bool? AllPlatforms { get; set; }

    [JsonProperty("filter_langs")]
    [Display("Filter langs")]
    public IEnumerable<string>? FilterLangs { get; set; }

    [JsonProperty("filter_data")]
    [Display("Filter data")]
    public IEnumerable<string>? FilterData { get; set; }

    [JsonProperty("filter_filenames")]
    [Display("Filter filenames")]
    public IEnumerable<string>? FilterFilenames { get; set; }

    [JsonProperty("add_newline_eof")]
    [Display("Add newline at the end of file")]
    public bool? AddNewlineEof { get; set; }

    [JsonProperty("custom_translation_status_ids")]
    [Display("Custom translation status IDs")]
    public IEnumerable<string>? CustomTranslationStatusIds { get; set; }

    [JsonProperty("include_tags")]
    [Display("Include tags")]
    public IEnumerable<string>? IncludeTags { get; set; }

    [JsonProperty("exclude_tags")]
    [Display("Exclude tags")]
    public IEnumerable<string>? ExcludeTags { get; set; }

    [JsonProperty("export_sort")]
    [Display("Export sort")]
    [DataSource(typeof(ExportSortDataHandler))]
    public string? ExportSort { get; set; }

    [JsonProperty("export_empty_as")]
    [Display("Export empty as")]
    [DataSource(typeof(ExportEmptyAsDataHandler))]
    public string? ExportEmptyAs { get; set; }

    [JsonProperty("export_null_as")]
    [Display("Export null as")]
    [DataSource(typeof(ExportNullAsDataHandler))]
    public string? ExportNullAs { get; set; }

    [JsonProperty("include_comments")]
    [Display("Include comments")]
    public bool? IncludeComments { get; set; }

    [JsonProperty("include_description")]
    [Display("Include description")]
    public bool? IncludeDescription { get; set; }

    [JsonProperty("include_pids")]
    [Display("Include Project IDs")]
    public IEnumerable<string>? IncludePids { get; set; }

    [JsonProperty("triggers")] public IEnumerable<string>? Triggers { get; set; }

    [JsonProperty("filter_repositories")]
    [Display("Filter repositories")]
    public IEnumerable<string>? FilterRepositories { get; set; }

    [JsonProperty("replace_breaks")]
    [Display("Replace breaks")]
    public bool? ReplaceBreaks { get; set; }

    [JsonProperty("disable_references")]
    [Display("Disable References")]
    public bool? DisableReferences { get; set; }

    [JsonProperty("plural_format")]
    [Display("Plural format")]
    [DataSource(typeof(PluralFormatDataHandler))]
    public string? PluralFormat { get; set; }

    [JsonProperty("placeholder_format")]
    [Display("Placeholder format")]
    [DataSource(typeof(PlaceholderFormatDataHandler))]
    public string? PlaceholderFormat { get; set; }

    [JsonProperty("webhook_url")]
    [Display("Webhook url")]
    public string? WebhookUrl { get; set; }

    [JsonProperty("language_mapping")]
    [Display("Language mapping")]
    public IEnumerable<LanguageMap>? LanguageMapping { get; set; }

    [JsonProperty("icu_numeric")]
    [Display("Icu numeric")]
    public bool? IcuNumeric { get; set; }

    [JsonProperty("escape_percent")]
    [Display("Escape percent")]
    public bool? EscapePercent { get; set; }

    [JsonProperty("indentation")]
    [DataSource(typeof(IndentationDataHandler))]
    public string? Indentation { get; set; }

    [JsonProperty("yaml_include_root")]
    [Display("Yaml include root")]
    public bool? YamlIncludeRoot { get; set; }

    [JsonProperty("json_unescaped_slashes")]
    [Display("Json unescaped slashes")]
    public bool? JsonUnescapedSlashes { get; set; }

    [JsonProperty("java_properties_encoding")]
    [Display("Java properties encoding")]
    [DataSource(typeof(JavaPropertiesEncodingDataHandler))]
    public string? JavaPropertiesEncoding { get; set; }

    [JsonProperty("java_properties_separator")]
    [Display("Java properties separator")]
    [DataSource(typeof(JavaPropertiesSeparatorDataHandler))]
    public string? JavaPropertiesSeparator { get; set; }

    [JsonProperty("bundle_description")]
    [Display("Bundle description")]
    public string? BundleDescription { get; set; }

    [JsonProperty("filter_task_id")]
    [Display("Filter task ID")]
    public string? FilterTaskId { get; set; }

    [JsonProperty("compact")]
    public bool? Compact { get; set; }

    public DownloadFileRequest(DownloadAllXLIFFFilesRequest request)
    {
        OriginalFilenames = request.OriginalFilenames;
        BundleStructure = request.BundleStructure;
        DirectoryPrefix = request.DirectoryPrefix;
        AllPlatforms = request.AllPlatforms;
        FilterLangs = request.FilterLangs;
        FilterData = request.FilterData;
        FilterFilenames = request.FilterFilenames;
        AddNewlineEof = request.AddNewlineEof;
        CustomTranslationStatusIds = request.CustomTranslationStatusIds;
        IncludeTags = request.IncludeTags;
        ExcludeTags = request.ExcludeTags;
        ExportSort = request.ExportSort;
        ExportEmptyAs = request.ExportEmptyAs;
        ExportNullAs = request.ExportNullAs;
        IncludeComments = request.IncludeComments;
        IncludeDescription = request.IncludeDescription;
        IncludePids = request.IncludePids;
        Triggers = request.Triggers;
        FilterRepositories = request.FilterRepositories;
        ReplaceBreaks = request.ReplaceBreaks;
        DisableReferences = request.DisableReferences;
        PluralFormat = request.PluralFormat;
        PlaceholderFormat = request.PlaceholderFormat;
        WebhookUrl = request.WebhookUrl;
        LanguageMapping = request.LanguageMapping;
        IcuNumeric = request.IcuNumeric;
        EscapePercent = request.EscapePercent;
        Indentation = request.Indentation;
        YamlIncludeRoot = request.YamlIncludeRoot;
        JsonUnescapedSlashes = request.JsonUnescapedSlashes;
        JavaPropertiesEncoding = request.JavaPropertiesEncoding;
        JavaPropertiesSeparator = request.JavaPropertiesSeparator;
        BundleDescription = request.BundleDescription;
        Compact = request.Compact;
    }

    public DownloadFileRequest()
    {
    }
}