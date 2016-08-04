/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using Windows.System;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.UWP.Services
{
    public class LauncherService : ILauncherService
    {
        public void LaunchWebUri(Uri uri)
        {
            Launcher.LaunchUriAsync(uri);
        }
    }
}
