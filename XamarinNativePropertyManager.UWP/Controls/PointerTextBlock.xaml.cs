using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace XamarinNativePropertyManager.UWP.Controls
{
    public sealed partial class PointerTextBlock : UserControl
    {
        private static readonly CoreCursor HandCursor = new CoreCursor(CoreCursorType.Hand, 1);
        private static readonly CoreCursor ArrowCursor = new CoreCursor(CoreCursorType.Arrow, 1);

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof (string), typeof (PointerTextBlock), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public PointerTextBlock()
        {
            InitializeComponent();
        }

        private void OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = HandCursor;
            Opacity = 0.7;
        }

        private void OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = ArrowCursor;
            Opacity = 1;
        }
    }
}
