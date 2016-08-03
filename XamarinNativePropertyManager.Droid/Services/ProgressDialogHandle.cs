using System;
using XamarinNativePropertyManager.Services;
using Android.App;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform;

namespace XamarinNativePropertyManager.Droid.Services
{
    public class ProgressDialogHandle : IDialogHandle
    {
        private ProgressDialog _progressDialog;

        public ProgressDialogHandle(string title, string message)
        {
            // Get the top activity.
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            if (topActivity == null)
            {
                throw new Exception("Could not find the top Activity.");
            }
            _progressDialog = ProgressDialog.Show(topActivity, title, message, true);
        }

        public void Close()
        {
            try
            {
                _progressDialog.Hide();
            }
            catch
            {
                // Ignored.
            }
        }
    }
}