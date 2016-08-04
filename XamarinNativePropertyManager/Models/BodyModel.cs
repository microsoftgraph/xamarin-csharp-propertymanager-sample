/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

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
