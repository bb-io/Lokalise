using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Screenshots;
using Apps.Lokalise.Models.Responses.Screenshots;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList("Screenshots")]
public class ScreenshotActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient)
    : LokaliseInvocable(invocationContext)
{
    [Action("Add screenshot", Description = "Adds a screenshot to a project")]
    public async Task<ScreenshotResponse> AddScreenshot([ActionParameter] ScreenshotInput input)
    {
        var screenshots = await UploadScreenshot(new[] { input.Screenshot }, input);
        return screenshots.Single();
    }

    [Action("Add multiple screenshots", Description = "Adds screenshots to a project in batches of up to 10")]
    public async Task<ScreenshotsResponse> AddMultipleScreenshots([ActionParameter] ScreenshotsInput input)
        => new() { Screenshots = await UploadScreenshot(input.Screenshots, input) };

    private Task<List<ScreenshotResponse>> UploadScreenshot(IEnumerable<FileReference> files, ScreenshotOptions options)
        => UploadBatches(files, options, fileManagementClient.DownloadAsync, async payload =>
        {
            var request = new LokaliseRequest($"/projects/{options.ProjectId}/screenshots", Method.Post, Creds)
                .WithJsonBody(payload);
            var response = await Client.ExecuteWithHandling<ScreenshotApiResponse>(request);
            if (response.Errors?.Any() == true)
                throw new PluginApplicationException($"Lokalise could not upload one or more screenshots: {string.Join("; ", response.Errors.Select(x => x.Message))}. Screenshots already uploaded may remain in the project.");
            if (response.Screenshots.Count() != payload.Screenshots.Count())
                throw new PluginApplicationException("Lokalise returned an unexpected number of screenshots. Screenshots already uploaded may remain in the project.");
            return response.Screenshots;
        });

    internal static async Task<List<ScreenshotResponse>> UploadBatches(IEnumerable<FileReference> files,
        ScreenshotOptions options, Func<FileReference, Task<Stream>> download,
        Func<ScreenshotBatch, Task<IEnumerable<ScreenshotResponse>>> upload)
    {
        var results = new List<ScreenshotResponse>();
        var keyIds = options.KeyIds?.ToArray();
        foreach (var batch in files.Chunk(10))
        {
            var screenshots = new List<ScreenshotUpload>();
            foreach (var file in batch)
            {
                var contentType = GetImageContentType(file);
                using var stream = await download(file);
                var bytes = await stream.GetByteData();
                screenshots.Add(new ScreenshotUpload
                {
                    Data = $"data:{contentType};base64,{Convert.ToBase64String(bytes)}",
                    Ocr = options.Ocr ?? true,
                    KeyIds = keyIds,
                    Tags = options.Tag is null ? null : new[] { options.Tag },
                    Description = options.Description
                });
            }

            results.AddRange(await upload(new ScreenshotBatch { Screenshots = screenshots }));
        }

        return results;
    }

    private static string GetImageContentType(FileReference file)
    {
        var type = file.ContentType?.Trim().ToLowerInvariant();
        if (type == "image/png" || type == "image/jpeg") return type;
        if (type == "image/jpg") return "image/jpeg";

        return Path.GetExtension(file.Name)?.ToLowerInvariant() switch
        {
            ".png" => "image/png",
            ".jpg" or ".jpeg" => "image/jpeg",
            _ => throw new PluginMisconfigurationException($"Screenshot '{file.Name}' must be a JPG or PNG image.")
        };
    }
}

internal class ScreenshotBatch
{
    [JsonProperty("screenshots")]
    public IEnumerable<ScreenshotUpload> Screenshots { get; set; } = null!;
}

internal class ScreenshotApiResponse : ScreenshotsResponse
{
    [JsonProperty("errors")] public IEnumerable<ScreenshotApiError>? Errors { get; set; }
}

internal class ScreenshotApiError
{
    [JsonProperty("message")] public string Message { get; set; } = "Unknown error";
}

internal class ScreenshotUpload
{
    [JsonProperty("data")] public string Data { get; set; } = null!;
    [JsonProperty("ocr", DefaultValueHandling = DefaultValueHandling.Include)] public bool Ocr { get; set; }
    [JsonProperty("key_ids")] public IEnumerable<string>? KeyIds { get; set; }
    [JsonProperty("tags")] public IEnumerable<string>? Tags { get; set; }
    [JsonProperty("description")] public string? Description { get; set; }
}
