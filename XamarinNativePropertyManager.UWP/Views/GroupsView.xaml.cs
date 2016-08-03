using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using MvvmCross.WindowsUWP.Views;
using XamarinNativePropertyManager.Models;
using XamarinNativePropertyManager.ViewModels;

namespace XamarinNativePropertyManager.UWP.Views
{
    public sealed partial class GroupsView : MvxWindowsPage
    {
        public new GroupsViewModel ViewModel => base.ViewModel as GroupsViewModel;

        public GroupsView()
        { 
            InitializeComponent();

            // Register for back requests.
            var systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.AppViewBackButtonVisibility = 
                AppViewBackButtonVisibility.Visible;
            systemNavigationManager.BackRequested += OnBackRequested;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs backRequestedEventArgs)
        {
            backRequestedEventArgs.Handled = true;
            ViewModel?.GoBackCommand.Execute(null);
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            var group = e.ClickedItem as GroupModel;
            ViewModel?.GroupClickCommand.Execute(group);
        }

        private void OnQuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            ViewModel?.FilterGroupsCommand.Execute(null);
        }

        private void OnAddPropertyItemTapped(object sender, TappedRoutedEventArgs e)
        {
            ViewModel?.AddPropertyCommand.Execute(null);
        }
    }
}
