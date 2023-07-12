using System.IO.Compression;

namespace Apps.Lokalise.Extensions;

public static class FileExtensions
{
    public static byte[] GetFileFromZip(this byte[] fileData, Func<ZipArchiveEntry, bool> predicate)
    {
        using var memoryStream = new MemoryStream(fileData);
        using var zip = new ZipArchive(memoryStream, ZipArchiveMode.Read);

        var file = zip.Entries.FirstOrDefault(predicate);

        if (file is null)
            throw new("No file found with provided filters");
        
        return file.Open().GetByteData();
    }
}