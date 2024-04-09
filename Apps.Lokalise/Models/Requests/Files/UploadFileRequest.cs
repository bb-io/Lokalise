using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Files;

public class UploadFileRequest
{
    [JsonProperty("filename")] public string FileName { get; set; }

    [JsonProperty("data")] public byte[] File { get; set; }

    [JsonProperty("lang_iso")] public string LanguageCode { get; set; }

    [JsonProperty("convert_placeholders")] public bool? ConvertPlaceHolders { get; set; }

    [JsonProperty("detect_icu_plurals")] public bool? DetectIcuPlurals { get; set; }

    [JsonProperty("tags")] public IEnumerable<string>? Tags { get; set; }

    [JsonProperty("tag_inserted_keys")] public bool? TagInsertedKeys { get; set; }

    [JsonProperty("tag_updated_keys")] public bool? TagUpdatedKeys { get; set; }

    [JsonProperty("tag_skipped_keys")] public bool? TagSkippedKeys { get; set; }

    [JsonProperty("replace_modified")] public bool? ReplaceModified { get; set; }

    [JsonProperty("slashn_to_linebreak")] public bool? SlashnToLinebreak { get; set; }

    [JsonProperty("keys_to_values")] public bool? KeysToValues { get; set; }

    [JsonProperty("distinguish_by_file")] public bool? DistinguishByFile { get; set; }

    [JsonProperty("apply_tm")] public bool? ApplyTM { get; set; }

    [JsonProperty("use_automations")] public bool? UseAutomations { get; set; }

    [JsonProperty("hidden_from_contributors")]
    public bool? HiddenFromContributors { get; set; }

    [JsonProperty("cleanup_mode")] public bool? CleanupMode { get; set; }

    [JsonProperty("custom_translation_status_ids")]
    public IEnumerable<string>? CustomTranslationStatusIds { get; set; }

    [JsonProperty("custom_translation_status_inserted_keys")]
    public bool? CustomTranslationStatusInsertedKeys { get; set; }

    [JsonProperty("custom_translation_status_updated_keys")]
    public bool? CustomTranslationStatusUpdatedKeys { get; set; }

    [JsonProperty("custom_translation_status_skipped_keys")]
    public bool? CustomTranslationStatusSkippedKeys { get; set; }

    [JsonProperty("skip_detect_lang_iso")] public bool? SkipDetectLangIso { get; set; }

    [JsonProperty("format")] public string? Format { get; set; }

    [JsonProperty("filter_task_id")] public long? FilterTaskId { get; set; }

    public UploadFileRequest(UploadFileInput input, IFileManagementClient fileManagementClient)
    {
        FileName = input.FileName ?? input.File.Name;
        File = fileManagementClient.DownloadAsync(input.File).Result.GetByteData().Result;
        LanguageCode = input.LanguageCode;
        ConvertPlaceHolders = input.ConvertPlaceHolders;
        DetectIcuPlurals = input.DetectIcuPlurals;
        Tags = input.Tags;
        TagInsertedKeys = input.TagInsertedKeys;
        TagUpdatedKeys = input.TagUpdatedKeys;
        TagSkippedKeys = input.TagSkippedKeys;
        ReplaceModified = input.ReplaceModified;
        SlashnToLinebreak = input.SlashnToLinebreak;
        KeysToValues = input.KeysToValues;
        DistinguishByFile = input.DistinguishByFile;
        ApplyTM = input.ApplyTM;
        UseAutomations = input.UseAutomations;
        HiddenFromContributors = input.HiddenFromContributors;
        CleanupMode = input.CleanupMode;
        CustomTranslationStatusIds = input.CustomTranslationStatusIds;
        CustomTranslationStatusInsertedKeys = input.CustomTranslationStatusInsertedKeys;
        CustomTranslationStatusUpdatedKeys = input.CustomTranslationStatusUpdatedKeys;
        CustomTranslationStatusSkippedKeys = input.CustomTranslationStatusSkippedKeys;
        SkipDetectLangIso = input.SkipDetectLangIso;
        Format = input.Format;
        FilterTaskId = input.FilterTaskId == null ? null : long.Parse(input.FilterTaskId);
    }
}