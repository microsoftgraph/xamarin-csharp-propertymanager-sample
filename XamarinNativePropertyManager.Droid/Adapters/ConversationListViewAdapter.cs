using Android.Content;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using XamarinNativePropertyManager.Models;

namespace XamarinNativePropertyManager.Droid.Adapters
{
    public class ConversationListViewAdapter : MvxAdapter
    {
        public override int ViewTypeCount => 2;

        public ConversationListViewAdapter(Context context,
            IMvxAndroidBindingContext bindingContext)
            : base(context, bindingContext)
        {
        }

        public override int GetItemViewType(int position)
        {
            var conversation = GetRawItem(position) as ConversationModel;
            if (conversation == null)
            {
                return base.GetItemViewType(position);
            }
            return conversation.IsOwnedByUser ? 1 : 0;
        }

        protected override View GetBindableView(View convertView, object dataContext, int templateId)
        {
            var conversation = dataContext as ConversationModel;
            if (conversation != null)
            {
                templateId = conversation.IsOwnedByUser
                    ? Resource.Layout.ConversationRightListViewItem
                    : Resource.Layout.ConversationLeftListViewItem;
            }
            return base.GetBindableView(convertView, dataContext, templateId);
        }
    }
}