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

