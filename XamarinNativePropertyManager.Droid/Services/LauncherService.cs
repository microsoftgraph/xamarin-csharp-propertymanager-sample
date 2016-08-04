/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using XamarinNativePropertyManager.Services;
using Android.Content;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace XamarinNativePropertyManager.Droid.Services
{
    public class LauncherService : ILauncherService
    {
        public void LaunchWebUri(Uri uri)
        {
            // Get the top activity.
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            if (topActivity == null)
            {
                throw new Exception("Could not find the top Activity.");
            }

            // Launch the URI.
            var browserIntent = new Intent(Intent.ActionView, 
                Android.Net.Uri.Parse(uri.AbsoluteUri)); 
            topActivity.StartActivity(browserIntent);
        }
    }
}