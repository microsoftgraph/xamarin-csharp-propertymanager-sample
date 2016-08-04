/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using System.IO;

namespace XamarinNativePropertyManager.Models
{
    public class PickedFileModel : IDisposable
    {
        public Stream Stream { get; set; }

        public string Name { get; set; }

        public void Dispose()
        {
            Stream.Dispose();
        }
    }
}
