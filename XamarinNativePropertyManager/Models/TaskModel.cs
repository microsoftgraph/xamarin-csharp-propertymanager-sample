using Newtonsoft.Json;

namespace XamarinNativePropertyManager.Models
{
    public class TaskModel
    {
        [JsonProperty("@odata.etag")]
        public string ETag { get; set; }

        public string Id { get; set; }

        public string PlanId { get; set; }

        public string BucketId { get; set; }

        public string Title { get; set; }

        public string CreatedBy { get; set; }

        public string AssignedTo { get; set; }

        public string OrderHint { get; set; }

        public string AssigneePriority { get; set; }

        public int PercentComplete { get; set; }

        public string StartDateTime { get; set; }

        public string AssignedDateTime { get; set; }

        public string CreatedDateTime { get; set; }

        public string AssignedBy { get; set; }

        public string DueDateTime { get; set; }

        public string PreviewType { get; set; }

        public string CompletedDateTime { get; set; }

        public string ConversationThreadId { get; set; }
    }
}
