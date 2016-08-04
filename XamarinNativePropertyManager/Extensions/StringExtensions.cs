/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System.IO;

namespace XamarinNativePropertyManager.Extensions
{
    public static class StringExtensions
    {
        public static Stream GetStream(this string str)
        {
            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);
            streamWriter.Write(str);
            streamWriter.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
