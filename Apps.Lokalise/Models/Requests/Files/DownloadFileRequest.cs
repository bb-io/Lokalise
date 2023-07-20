using System.Text.Json.Serialization;
using Apps.Lokalise.Models.Responses.Files;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class DownloadFileRequest
    {
        [JsonPropertyName("format")] public string Format { get; set; }

        [JsonPropertyName("original_filenames")]
        [Display("Original filenames")]
        public bool? OriginalFilenames { get; set; }

        [JsonPropertyName("bundle_structure")]
        [Display("Bundle structure")]
        public string? BundleStructure { get; set; }

        [JsonPropertyName("directory_prefix")]
        [Display("Directory prefix")]
        public string? DirectoryPrefix { get; set; }

        [JsonPropertyName("all_platforms")]
        [Display("All platforms")]
        public bool? AllPlatforms { get; set; }

        [JsonPropertyName("filter_langs")]
        [Display("Filter langs")]
        public IEnumerable<string>? FilterLangs { get; set; }

        [JsonPropertyName("filter_data")]
        [Display("Filter data")]
        public IEnumerable<string>? FilterData { get; set; }

        [JsonPropertyName("filter_filenames")]
        [Display("Filter filenames")]
        public IEnumerable<string>? FilterFilenames { get; set; }

        [JsonPropertyName("add_newline_eof")]
        [Display("Add newline at the end of file")]
        public bool? AddNewlineEof { get; set; }

        [JsonPropertyName("custom_translation_status_ids")]
        [Display("Custom translation status IDs")]
        public IEnumerable<string>? CustomTranslationStatusIds { get; set; }

        [JsonPropertyName("include_tags")]
        [Display("Include tags")]
        public IEnumerable<string>? IncludeTags { get; set; }

        [JsonPropertyName("exclude_tags")]
        [Display("Exclude tags")]
        public IEnumerable<string>? ExcludeTags { get; set; }

        [JsonPropertyName("export_sort")]
        [Display("Export sort")]
        public string? ExportSort { get; set; }

        [JsonPropertyName("export_empty_as")]
        [Display("Export empty as")]
        public string? ExportEmptyAs { get; set; }

        [JsonPropertyName("export_null_as")]
        [Display("Export null as")]
        public string? ExportNullAs { get; set; }

        [JsonPropertyName("include_comments")]
        [Display("Include comments")]
        public bool? IncludeComments { get; set; }

        [JsonPropertyName("include_description")]
        [Display("Include description")]
        public bool? IncludeDescription { get; set; }

        [JsonPropertyName("include_pids")]
        [Display("Include Project IDs")]
        public IEnumerable<string>? IncludePids { get; set; }

        [JsonPropertyName("triggers")] public IEnumerable<string>? Triggers { get; set; }

        [JsonPropertyName("filter_repositories")]
        [Display("Filter repositories")]
        public IEnumerable<string>? FilterRepositories { get; set; }

        [JsonPropertyName("replace_breaks")]
        [Display("Replace breaks")]
        public bool? ReplaceBreaks { get; set; }

        [JsonPropertyName("disable_references")]
        [Display("Disable References")]
        public bool? DisableReferences { get; set; }

        [JsonPropertyName("plural_format")]
        [Display("Plural format")]
        public string? PluralFormat { get; set; }

        [JsonPropertyName("placeholder_format")]
        [Display("Placeholder format")]
        public string? PlaceholderFormat { get; set; }

        [JsonPropertyName("webhook_url")]
        [Display("Webhook url")]
        public string? WebhookUrl { get; set; }

        [JsonPropertyName("language_mapping")]
        [Display("Language mapping")]
        public IEnumerable<LanguageMap>? LanguageMapping { get; set; }

        [JsonPropertyName("icu_numeric")]
        [Display("Icu numeric")]
        public bool? IcuNumeric { get; set; }

        [JsonPropertyName("escape_percent")]
        [Display("Escape percent")]
        public bool? EscapePercent { get; set; }

        [JsonPropertyName("indentation")]
        public string? Indentation { get; set; }

        [JsonPropertyName("yaml_include_root")]
        [Display("Yaml include root")]
        public bool? YamlIncludeRoot { get; set; }

        [JsonPropertyName("json_unescaped_slashes")]
        [Display("Json unescaped slashes")]
        public bool? JsonUnescapedSlashes { get; set; }

        [JsonPropertyName("java_properties_encoding")]
        [Display("Java properties encoding")]
        public string? JavaPropertiesEncoding { get; set; }

        [JsonPropertyName("java_properties_separator")]
        [Display("Java properties separator")]
        public string? JavaPropertiesSeparator { get; set; }

        [JsonPropertyName("bundle_description")]
        [Display("Bundle description")]
        public string? BundleDescription { get; set; }

        [JsonPropertyName("filter_task_id")]
        [Display("Filter task ID")]
        public long? FilterTaskId { get; set; }

        [JsonPropertyName("compact")]
        public bool? Compact { get; set; }
    }
}