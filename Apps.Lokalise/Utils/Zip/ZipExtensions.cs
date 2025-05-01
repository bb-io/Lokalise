using Apps.Lokalise.Models.Responses.Files;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using System.IO.Compression;

namespace Apps.Lokalise.Utils.Zip
{
    public static class ZipExtensions
    {
        public static async Task<IEnumerable<ZipEntryFile>> GetFilesFromZip(
    this byte[] zipBytes,
    IFileManagementClient fileClient)
        {
            using var ms = new MemoryStream(zipBytes);
            using var archive = new ZipArchive(ms, ZipArchiveMode.Read, leaveOpen: false);

            var result = new List<ZipEntryFile>();
            foreach (var entry in archive.Entries.Where(e => !e.FullName.EndsWith("/")))
            {
                using var entryStream = entry.Open();
                var fileStream = new MemoryStream();
                await entryStream.CopyToAsync(fileStream);
                fileStream.Position = 0;

                var uploaded = await fileClient.UploadAsync(
                    fileStream,
                    contentType: "application/octet-stream",
                    fileName: entry.FullName
                );

                result.Add(new ZipEntryFile { Path = entry.FullName, File = uploaded });
            }

            return result;
        }
    }
}
