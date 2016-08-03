using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XamarinNativePropertyManager.Models;

namespace XamarinNativePropertyManager.UWP.Controls
{
    public class ConversationMessageTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var conversation = item as ConversationModel;
            if (conversation == null)
            {
                return base.SelectTemplateCore(item, container);
            }

            var resources = Application.Current.Resources;
            if (conversation.IsOwnedByUser)
            {
                return resources["ConversationMessageRightTemplate"] as DataTemplate;
            }
            return resources["ConversationMessageLeftTemplate"] as DataTemplate;
        }
    }
}
