using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using XamarinNativePropertyManager.ViewModels;
using MvvmCross.Binding.Droid.Views;
using Java.Lang;

namespace XamarinNativePropertyManager.Droid.Fragments
{
    public class TasksFragment : MvxFragment
    {
        private MvxListView _tasksListView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, 
            Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet(savedInstanceState);
            return this.BindingInflate(Resource.Layout.TasksFragment, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            // Get the group view model.
            var viewModel = ViewModel as GroupViewModel;
            if (viewModel != null)
            {
                viewModel.TasksChanged += OnTasksChanged;
            }

            // Get the list view.
            _tasksListView = (MvxListView)view.FindViewById(Resource.Id.tasks_list_view);
            
            // Get EditText and hook up the event listeners.
            var taskEditText = (Android.Support.V7.Widget.AppCompatEditText)
                view.FindViewById(Resource.Id.task_edit_text);
            taskEditText.EditorAction += OnTaskEditorAction;
        }

        private void OnTasksChanged(GroupViewModel sender)
        {
            _tasksListView.Post(new Runnable(() =>
            {
                _tasksListView.SetSelection(sender.Tasks.Count - 1);
            }));
        }

        private void OnTaskEditorAction(object sender, Android.Widget.TextView.EditorActionEventArgs e)
        {
            if (e.ActionId == Android.Views.InputMethods.ImeAction.Send)
            {
                (ViewModel as GroupViewModel)?.AddTaskCommand.Execute(null);
                e.Handled = true;
            }
        }
    }
}