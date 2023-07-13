using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests
{
    public class DownloadFileRequest
    {
        [Display("Project ID")]
        public string ProjectId { get; set; }

        [Display("File format")]
        public string FileFormat { get; set; }

        [Display("Original filenames")]
        public bool? OriginalFilenames { get; set; }

        [Display("Bundle structure")]
        public string? BundleStructure { get; set; }

        [Display("Directory prefix")]
        public string? DirectoryPrefix { get; set; }

        [Display("All platforms")]
        public bool? AllPlatforms { get; set; }

        [Display("Filter languages")]
        public List<string>? FilterLangs { get; set; }

        [Display("Filter data")]
        public List<string>? FilterData { get; set; }

        [Display("Filter filenames")]
        public List<string>? FilterFilenames { get; set; }

        [Display("Add newline to EOF")]
        public bool? AddNewlineToEof { get; set; }

        [Display("Custom status IDs")]
        public List<string>? CustomStatusIds { get; set; }

        [Display("Include tags")]
        public List<string>? IncludeTags { get; set; }

        [Display("Exclude tags")]
        public List<string>? ExcludeTags { get; set; }

        [Display("Export sort")]
        public string? ExportSort { get; set; }

        [Display("Export empty as")]
        public string? ExportEmptyAs { get; set; }

        [Display("Export null as")]
        public string? ExportNullAs { get; set; }

        [Display("Include comments")]
        public bool? IncludeComments { get; set; }

        [Display("Include description")]
        public bool? IncludeDescription { get; set; }

        [Display("Include Project IDs")]
        public List<string>? IncludePids { get; set; }

        [Display("Triggers")]
        public List<string>? Triggers { get; set; }

        [Display("Filter repositories")]
        public List<string>? FilterRepositories { get; set; }

        [Display("Replace breaks")]
        public bool? ReplaceBreaks { get; set; }

        [Display("Disable references")]
        public bool? DisableReferences { get; set; }

        [Display("Plural format")]
        public string? PluralFormat { get; set; }

        [Display("Placeholder format")]
        public string? PlaceholderFormat { get; set; }

        [Display("Webhook URL")]
        public string? WebhookUrl { get; set; }

        [Display("Language mapping")]
        public List<object>? LanguageMapping { get; set; }

        [Display("ICU numeric")]
        public bool? IcuNumeric { get; set; }

        [Display("Escape percent")]
        public bool? EscapePercent { get; set; }

        [Display("Indentation")]
        public string? Indentation { get; set; }

        [Display("YAML include root")]
        public bool? YamlIncludeRoot { get; set; }

        [Display("JSON unescaped slashes")]
        public bool? JsonUnescapedSlashes { get; set; }

        [Display("Java properties encoding")]
        public string? JavaPropertiesEncoding { get; set; }

        [Display("Java properties separator")]
        public string? JavaPropertiesSeparator { get; set; }

        [Display("Bundle description")]
        public string? BundleDescription { get; set; }

        [Display("Filter task ID")]
        public int? FilterTaskId { get; set; }

        [Display("Compact")]
        public bool? Compact { get; set; }
    }
}
