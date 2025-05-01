using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Lokalise.Models.Responses.Files
{
    public class ZipEntryFile
    {
        public string Path { get; set; } = null!;

        public FileReference File { get; set; } = null!;
    }
}
