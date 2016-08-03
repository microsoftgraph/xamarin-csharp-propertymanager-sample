using System.Linq;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MvvmCross.WindowsUWP.Views;
using XamarinNativePropertyManager.Models;
using XamarinNativePropertyManager.ViewModels;

namespace XamarinNativePropertyManager.UWP.Views
{
    public sealed partial class GroupView : MvxWindowsPage
    {
        public new GroupViewModel ViewModel => base.ViewModel as GroupViewModel;

        public GroupView()
        { 
            InitializeComponent();

            // Register for back requests.
            var systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.AppViewBackButtonVisibility = 
                AppViewBackButtonVisibility.Visible;
            systemNavigationManager.BackRequested += OnBackRequested;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if (ViewModel == null)
            {
                return;
            }
            ViewModel.ConversationsChanged += ViewModelOnConversationsChanged;
            ViewModel.FilesChanged += ViewModelOnFilesChanged;
            ViewModel.TasksChanged += ViewModelOnTasksChanged;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs backRequestedEventArgs)
        {
            backRequestedEventArgs.Handled = true;
            ViewModel?.GoBackCommand.Execute(null);
        }

        private void ViewModelOnConversationsChanged(GroupViewModel sender)
        {
            ScrolLToBottom(ConversationsGridView);
        }

        private void ViewModelOnFilesChanged(GroupViewModel sender)
        {
            ScrolLToBottom(FilesListView);
        }

        private void ViewModelOnTasksChanged(GroupViewModel sender)
        {
            ScrolLToBottom(TasksListView);
        }

        private static void ScrolLToBottom(ListViewBase itemsControl)
        {
            var item = itemsControl.Items.LastOrDefault();
            if (item == null)
            {
                return;
            }
            itemsControl.UpdateLayout();
            itemsControl.ScrollIntoView(item);
        }

        private void OnFileItemClick(object sender, ItemClickEventArgs e)
        {
            var file = e.ClickedItem as FileModel;
            if (file != null)
            {
                ViewModel?.FileClickCommand.Execute(file);
            }
        }

        private void OnTaskItemClick(object sender, ItemClickEventArgs e)
        {
            var task = e.ClickedItem as TaskModel;
            if (task != null)
            {
                ViewModel?.TaskClickCommand.Execute(task);
            }
        }

        private void OnMessageKeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key != VirtualKey.Enter || !e.KeyStatus.WasKeyDown)
            {
                return;
            }
            ViewModel?.AddConversationCommand.Execute(null);
        }

        private void OnTaskKeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key != VirtualKey.Enter || !e.KeyStatus.WasKeyDown)
            {
                return;
            }
            ViewModel?.AddTaskCommand.Execute(null);
        }

        private void OnEditDetailsButtonTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ViewModel?.EditDetailsCommand.Execute(null);
        }

        private void OnAddFileItemTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ViewModel?.AddFileCommand.Execute(null);
        }
    }
}
