using System.Collections.Generic;

namespace XamarinNativePropertyManager.Models
{
    public class NewConversationModel
    {
        public string Topic { get; set; }

        public List<NewPostModel> Posts { get; set; }
    }
}
