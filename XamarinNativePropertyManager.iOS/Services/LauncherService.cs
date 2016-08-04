/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using Foundation;
using XamarinNativePropertyManager.Services;
using UIKit;

namespace XamarinNativePropertyManager.iOS.Services
{
	public class LauncherService : ILauncherService
	{
		public void LaunchWebUri(Uri uri)
		{
			UIApplication.SharedApplication.OpenUrl(NSUrl.FromString(uri.AbsoluteUri));
		}
	}
}

