using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using XamarinNativePropertyManager.ViewModels;
using MvvmCross.Binding.Droid.Views;
using XamarinNativePropertyManager.Droid.Adapters;
using Java.Lang;

namespace XamarinNativePropertyManager.Droid.Fragments
{
    public class ConversationsFragment : MvxFragment
    {
        private MvxListView _conversationsListView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, 
            Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet(savedInstanceState);
            return this.BindingInflate(Resource.Layout.ConversationFragment, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            // Get the group view model.
            var viewModel = ViewModel as GroupViewModel;
            if (viewModel != null)
            {
                viewModel.ConversationsChanged += OnConversationsChanged;
            }

            // Get the list view and configure the adapter.
            _conversationsListView = (MvxListView)view.FindViewById(Resource.Id.conversation_list_view);
            _conversationsListView.Adapter = new ConversationListViewAdapter(Context, 
                (IMvxAndroidBindingContext)BindingContext);

            // Get EditText and hook up the event listeners.
            var conversationEditText = (Android.Support.V7.Widget.AppCompatEditText)
                view.FindViewById(Resource.Id.conversation_edit_text);
            conversationEditText.EditorAction += OnConversationEditorAction;
        }

        private void OnConversationsChanged(GroupViewModel sender)
        {
            _conversationsListView.Post(new Runnable(() =>
            {
                _conversationsListView.SetSelection(sender.Conversations.Count - 1);
            }));
        }

        private void OnConversationEditorAction(object sender, Android.Widget.TextView.EditorActionEventArgs e)
        {
            if (e.ActionId == Android.Views.InputMethods.ImeAction.Send)
            {
                (ViewModel as GroupViewModel)?.AddConversationCommand.Execute(null);
                e.Handled = true;
            }
        }
    }
}