namespace XamarinNativePropertyManager.Models
{
    public class BodyModel
    {
        public string ContentType { get; set; }

        public string Content { get; set; }

        public BodyModel()
        {
            
        }

        public BodyModel(string content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }
    }
}
