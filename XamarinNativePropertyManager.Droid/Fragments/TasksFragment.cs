/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using XamarinNativePropertyManager.ViewModels;
using MvvmCross.Binding.Droid.Views;
using Java.Lang;
using MvvmCross.Platform.IoC;

namespace XamarinNativePropertyManager.Droid.Fragments
{
    [MvxUnconventional]
    public class TasksFragment : MvxFragment<GroupViewModel>
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

            ViewModel.TasksChanged += OnTasksChanged;

            // Get the list view.
            _tasksListView = view.FindViewById<MvxListView>(Resource.Id.tasks_list_view);
            
            // Get EditText and hook up the event listeners.
            var taskEditText = 
                view.FindViewById<Android.Support.V7.Widget.AppCompatEditText>(Resource.Id.task_edit_text);
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
                ViewModel?.AddTaskCommand.Execute(null);
                e.Handled = true;
            }
        }
    }
}