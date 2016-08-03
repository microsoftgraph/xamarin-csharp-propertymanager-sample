using XamarinNativePropertyManager.Services;
using Windows.UI.Xaml.Controls;

namespace XamarinNativePropertyManager.UWP.Services
{
    public class ProgressDialogHandle : IDialogHandle
    {
        private ContentDialog _contentDialog;
        private bool _canClose;

        public ProgressDialogHandle(string title, string message)
        {
            CreateAndShowContentDialog(title, message);
        }

        private void CreateAndShowContentDialog(string title, string message)
        {
            // Create stack panel.
            var stackPanel = new StackPanel();
            stackPanel.Children.Add(new TextBlock
            {
                Text = message,
                TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap,
                Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 25)
            });
            stackPanel.Children.Add(new ProgressRing
            {
                IsActive = true,
                Width = 35,
                Height = 35
            });

            _contentDialog = new ContentDialog
            {
                Title = title,
                MaxWidth = 325,
                IsPrimaryButtonEnabled = false,
                IsSecondaryButtonEnabled = false,
                Content = stackPanel
            };

            // Catch and cancel any closing events.
            _contentDialog.Closing += OnClosing;

            // Show dialog.
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            _contentDialog.ShowAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private void OnClosing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (!_canClose)
            {
                args.Cancel = true;
            }
        }

        public void Close()
        {
            try
            {
                _canClose = true;
                _contentDialog.Hide();
            }
            catch
            {
                // Ignored.
            }
        }
    }
}
