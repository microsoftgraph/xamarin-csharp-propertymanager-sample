/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Android.App;
using Android.Content;
using MvvmCross.Platform;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.Droid.Services
{
    public static class FilePickerAgentContinuationHelper
    {
        public static void SetAuthenticationAgentContinuationEventArgs(ContentResolver contentResolver, int requestCode,
            Result resultCode, Intent data)
        {
            (Mvx.Resolve<IFilePickerService>() as FilePickerService)?.ResolveTask(
                contentResolver, requestCode, resultCode, data);
        }
    }
}