using Newtonsoft.Json;

namespace XamarinNativePropertyManager.Models
{
    public class IdModel
    {
        [JsonProperty("@odata.id")]
        public string Id { get; set; }
    }
}