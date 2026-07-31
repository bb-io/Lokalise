using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Tasks;

public class GetFilesFromTaskResponse
{
    [Display("File names", Description = "Unique original filenames assigned to keys in the task")]
    public List<string> FileNames { get; set; } = new();
}
