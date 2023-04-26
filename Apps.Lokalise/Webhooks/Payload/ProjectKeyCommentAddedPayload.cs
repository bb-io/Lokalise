namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyCommentAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeyCommentAddedPayload : BasePayload>(myJsonResponse);
    public class Comment
    {
        public string Value { get; set; }
    }

    public class Filenames
    {
        public string Android { get; set; }
        public string Ios { get; set; }
        public string Other { get; set; }
        public string Web { get; set; }
    }

    public class KeyCommentAdded
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Filenames Filenames { get; set; }
    }

    public class ProjectKeyCommentAddedPayload : BasePayload
    {
        public KeyCommentAdded Key { get; set; }
        public Comment Comment { get; set; }
    }


}