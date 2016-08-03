using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.Droid.Services
{
    public class DialogService : IDialogService
    {
        public IDialogHandle ShowProgress(string title, string message)
        {
            return new ProgressDialogHandle(title, message);
        }
    }
}