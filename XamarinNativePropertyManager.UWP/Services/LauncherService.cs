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
