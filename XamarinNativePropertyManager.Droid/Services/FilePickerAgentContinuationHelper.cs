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