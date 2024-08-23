using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Apps.Lokalise.Models.Responses.Files;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class DownloadAllXLIFFFilesRequest
    {
        [JsonProperty("all_platforms")]
        [Display("All platforms", Description = "Enable to include all platform keys. If disabled, only the keys, associated with the platform of the format will be exported.")]
        public bool? AllPlatforms { get; set; }

        [JsonProperty("filter_langs")]
        [Display("Filter languages", Description = "List of languages to export. Omit this parameter for all languages.")]
        public IEnumerable<string>? FilterLangs { get; set; }

        [JsonProperty("filter_data")]
        [Display("Filter data", Description = "Narrow export data range. Allowed values are translated or untranslated, reviewed (or reviewed_only), last_reviewed_only, verified and nonhidden.")]
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
        [Display("Include tags", Description = "Narrow export range to tags specified.")]
        public IEnumerable<string>? IncludeTags { get; set; }

        [JsonProperty("exclude_tags")]
        [Display("Exclude tags", Description = "Specify to exclude keys with these tags.")]
        public IEnumerable<string>? ExcludeTags { get; set; }

        [JsonProperty("export_sort")]
        [Display("Export sort", Description = "Export key sort mode. Allowed value are first_added, last_added, last_updated, a_z, z_a.")]
        [StaticDataSource(typeof(ExportSortDataHandler))]
        public string? ExportSort { get; set; }

        [JsonProperty("export_empty_as")]
        [Display("Export empty as", Description = "Select how you would like empty translations to be exported. Allowed values are empty to keep empty, base to replace with the base language value, null to replace with null (YAML export only), or skip to omit.")]
        [StaticDataSource(typeof(ExportEmptyAsDataHandler))]
        public string? ExportEmptyAs { get; set; }

        [JsonProperty("export_null_as")]
        [Display("Export null as", Description = "(Ruby on Rails YAML export only) Select how you would like null (void) translations to be exported. Allowed values are null to keep null, empty to replace with empty string.")]
        [StaticDataSource(typeof(ExportNullAsDataHandler))]
        public string? ExportNullAs { get; set; }

        [JsonProperty("include_comments")]
        [Display("Include comments", Description = "Enable to include key comments and description in exported file (if supported by the format).")]
        public bool? IncludeComments { get; set; }

        [JsonProperty("include_description")]
        [Display("Include description", Description = "Enable to include key description in exported file (if supported by the format).")]
        public bool? IncludeDescription { get; set; }

        [JsonProperty("include_pids")]
        [Display("Include Project IDs", Description = "Other projects ID's, which keys should be included with this export.")]
        public IEnumerable<string>? IncludePids { get; set; }

        [JsonProperty("triggers")] public IEnumerable<string>? Triggers { get; set; }

        [JsonProperty("filter_repositories")]
        [Display("Filter repositories", Description = "Pull requests will be created only for listed repositories (organization/repository format). Leave empty array to process all configured integrations by platform only.")]
        public IEnumerable<string>? FilterRepositories { get; set; }

        [JsonProperty("replace_breaks")]
        [Display("Replace breaks", Description = "Enable to replace line breaks in exported translations with \n.")]
        public bool? ReplaceBreaks { get; set; }

        [JsonProperty("disable_references")]
        [Display("Disable References", Description = "Enable to skip automatic replace of key reference placeholders (e.g. [%key:hello_world%]) with their corresponding translations.")]
        public bool? DisableReferences { get; set; }

        [JsonProperty("plural_format")]
        [Display("Plural format", Description = "Override the default plural format for the file type. Allowed values are json_string, icu, array, generic, symfony, i18next, i18next_v4. See Plurals and placeholders for more information about plural support for specific file formats.")]
        [StaticDataSource(typeof(PluralFormatDataHandler))]
        public string? PluralFormat { get; set; }

        [JsonProperty("placeholder_format")]
        [Display("Placeholder format", Description = "Override the default placeholder format for the file type. Allowed values are printf, ios, icu, net, symfony, i18n, raw). See Plurals and placeholders for more information.")]
        [StaticDataSource(typeof(PlaceholderFormatDataHandler))]
        public string? PlaceholderFormat { get; set; }

        [JsonProperty("language_mapping")]
        [Display("Language mapping", Description = "List of languages to override default iso codes for this export.")]
        public IEnumerable<LanguageMap>? LanguageMapping { get; set; }

        [JsonProperty("icu_numeric")]
        [Display("ICU numeric", Description = "If enabled, plural forms zero, one and two will be replaced with =0, =1 and =2 respectively. Only works for ICU plural format.")]
        public bool? IcuNumeric { get; set; }

        [JsonProperty("escape_percent")]
        [Display("Escape percent", Description = "Only works for printf placeholder format. When enabled, all universal percent placeholders \"[%]\" will be always exported as \"%%\".")]
        public bool? EscapePercent { get; set; }

        [JsonProperty("indentation")]
        [StaticDataSource(typeof(IndentationDataHandler))]
        [Display("Indentation", Description = "Provide to override default indentation in supported files. Allowed values are default, 1sp, 2sp, 3sp, 4sp, 5sp, 6sp, 7sp, 8sp and tab.")]
        public string? Indentation { get; set; }
    }
}
