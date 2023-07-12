namespace Apps.Lokalise.Extensions;

public static class StreamExtensions
{
    public static byte[] GetByteData(this Stream stream)
    {
        using var resultFileStream = new MemoryStream();
        stream.CopyTo(resultFileStream);
        
        return resultFileStream.ToArray();
    }
}