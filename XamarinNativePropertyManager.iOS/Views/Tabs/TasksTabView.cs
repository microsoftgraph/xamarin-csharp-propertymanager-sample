/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using XamarinNativePropertyManager.iOS.Extensions;
using XamarinNativePropertyManager.iOS.Views.Cells;
using XamarinNativePropertyManager.ViewModels;

namespace XamarinNativePropertyManager.iOS.Views.Tabs
{
	public partial class TasksTabView : MvxViewController
	{
	    public TasksTabView() : base("TasksTabView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var viewModel = ViewModel as GroupViewModel;

			// Set view title and prompt.
			NavigationItem.Title = "Tasks";
		    if (viewModel != null)
		    {
		        NavigationItem.Prompt = viewModel.Group.DisplayName;

		        // Add left navigation bar item.
		        var leftNavigationButton = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, e) =>
		            viewModel.GoBackCommand.Execute(null));
		        NavigationItem.LeftBarButtonItem = leftNavigationButton;

		        // Add right navigation bar item.
		        var rightNavigationButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, async (sender, e) =>
		        {
		            var result = await this.GetTextFromAlertAsync("New Task", null, "Type a task...");
		            if (result != null) {
		                viewModel.TaskText = result;
		                viewModel.AddTaskCommand.Execute(null);
		            }
		        });
		        NavigationItem.RightBarButtonItem = rightNavigationButton;
		    }

		    // Create the table view source.
			var source = new MvxSimpleTableViewSource(TableView, TasksTableViewCell.Key, TasksTableViewCell.Key);

			// Create and apply the binding set.
			var set = this.CreateBindingSet<TasksTabView, GroupViewModel>();
			set.Bind(source).To(vm => vm.Tasks);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.TaskClickCommand);
			set.Apply();

			// Set the table view source and refresh.
			TableView.Source = source;
			TableView.RowHeight = 60;
			TableView.ReloadData();
		}
	}
}


