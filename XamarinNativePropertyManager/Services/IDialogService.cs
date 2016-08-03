namespace XamarinNativePropertyManager.Services
{
    public interface IDialogService 
    {
        IDialogHandle ShowProgress(string title, string message);
    }
}
