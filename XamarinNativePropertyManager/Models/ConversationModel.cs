using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamarinNativePropertyManager.Models
{
    public class ConversationModel
    {
        public string Id { get; set; }

        public string Topic { get; set; }

        public bool HasAttachments { get; set; }

        public string LastDeliveredDateTime { get; set; }

        public List<string> UniqueSenders { get; set; }

        public string Preview { get; set; }

        [JsonIgnore]
        public bool IsOwnedByUser { get; set; }
    }
}
