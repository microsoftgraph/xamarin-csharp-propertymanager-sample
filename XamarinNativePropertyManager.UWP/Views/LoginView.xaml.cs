using Windows.UI.Core;
using MvvmCross.WindowsUWP.Views;
using XamarinNativePropertyManager.ViewModels;

namespace XamarinNativePropertyManager.UWP.Views
{
    public sealed partial class LoginView : MvxWindowsPage
    {
        public new LoginViewModel ViewModel => base.ViewModel as LoginViewModel;

        public LoginView()
        { 
            InitializeComponent();

            // Register for back requests.
            var systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += OnBackRequested;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs backRequestedEventArgs)
        {
            backRequestedEventArgs.Handled = false;
        }
    }
}
