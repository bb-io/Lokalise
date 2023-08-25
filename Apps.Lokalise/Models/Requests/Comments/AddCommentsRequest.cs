﻿using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Comments;

public class AddCommentsRequest
{
    [JsonProperty("comments")] public CommentRequest[] Comments { get; set; }

    public AddCommentsRequest(string text)
    {
        Comments = new[] { new CommentRequest(text) };
    }
}