/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Newtonsoft.Json;

namespace XamarinNativePropertyManager.Models
{
    public class PlannerAssignment
    {
        [JsonProperty("@odata.type")]
        public string Type { get { return "microsoft.graph.plannerAssignment"; } }
        public IdentitySet AssignedBy { get; set; }
        public string AssignedDateTime { get; set; }
        public string OrderHint { get; set; }
    }
}
