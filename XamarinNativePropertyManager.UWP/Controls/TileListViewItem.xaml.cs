using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace XamarinNativePropertyManager.UWP.Controls
{
    public sealed partial class TileListViewItem : UserControl
    {
        public static readonly DependencyProperty TileBackgroundProperty = DependencyProperty.Register(
            "TileBackground", typeof (SolidColorBrush), typeof (TileListViewItem), new PropertyMetadata(default(SolidColorBrush)));

        public SolidColorBrush TileBackground
        {
            get { return (SolidColorBrush) GetValue(TileBackgroundProperty); }
            set { SetValue(TileBackgroundProperty, value); }
        }


        public static readonly DependencyProperty TileForegroundProperty = DependencyProperty.Register(
            "TileForeground", typeof (SolidColorBrush), typeof (TileListViewItem), new PropertyMetadata(default(SolidColorBrush)));

        public SolidColorBrush TileForeground
        {
            get { return (SolidColorBrush) GetValue(TileForegroundProperty); }
            set { SetValue(TileForegroundProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof (string), typeof (TileListViewItem), new PropertyMetadata(default(string)));

        public string Header
        {
            get { return (string) GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof (string), typeof (TileListViewItem), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof (string), typeof (TileListViewItem), new PropertyMetadata(default(string)));

        public string Icon
        {
            get { return (string) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register(
            "IconSize", typeof (double), typeof (TileListViewItem), new PropertyMetadata(20d));

        public double IconSize
        {
            get { return (double) GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(
            "TextWrapping", typeof (TextWrapping), typeof (TileListViewItem), new PropertyMetadata(TextWrapping.NoWrap));

        public TextWrapping TextWrapping
        {
            get { return (TextWrapping) GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }

        public TileListViewItem()
        {
            InitializeComponent();
        }
    }
}
