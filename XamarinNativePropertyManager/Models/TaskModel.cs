﻿/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

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

        public IdentitySet CreatedBy { get; set; }

        public string OrderHint { get; set; }

        public string AssigneePriority { get; set; }

        public int PercentComplete { get; set; }

        public string StartDateTime { get; set; }

        public string CreatedDateTime { get; set; }

        public string DueDateTime { get; set; }

        public string PreviewType { get; set; }

        public string CompletedDateTime { get; set; }

        public string ConversationThreadId { get; set; }

        public object Assignments { get; set; }
    }
}
