/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Newtonsoft.Json;

namespace XamarinNativePropertyManager.Models
{
    public class IdModel
    {
        [JsonProperty("@odata.id")]
        public string Id { get; set; }
    }
}