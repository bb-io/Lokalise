namespace Apps.Lokalise.Models.Responses.Projects;
public class Settings
{
    public bool PerPlatformKeyNames { get; set; }
    public bool Reviewing { get; set; }
    public bool AutoToggleUnverified { get; set; }
    public bool OfflineTranslation { get; set; }
    public bool KeyEditing { get; set; }
    public bool InlineMachineTranslations { get; set; }
    public bool Branching { get; set; }
    public bool Segmentation { get; set; }
    public bool CustomTranslationStatuses { get; set; }
    public bool CustomTranslationStatusesAllowMultiple { get; set; }
}