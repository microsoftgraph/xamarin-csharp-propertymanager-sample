using System;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using XamarinNativePropertyManager.ViewModels;
using UIKit;
using XamarinNativePropertyManager.iOS.Views.Cells;

namespace XamarinNativePropertyManager.iOS.Views.Tabs
{
	public partial class FilesTabView : MvxViewController
	{
		public FilesTabView() : base("FilesTabView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var viewModel = ViewModel as GroupViewModel;

			// Set view title and prompt.
			NavigationItem.Title = "Files";
			NavigationItem.Prompt = viewModel.Group.DisplayName;

			// Add left navigation bar item.
			var leftNavigationButton = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, e) =>
															viewModel.GoBackCommand.Execute(null));
			NavigationItem.LeftBarButtonItem = leftNavigationButton;

			// Add right navigation bar item.
			var rightNavigationButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, e) =>
			                                                viewModel.AddFileCommand.Execute(null));
			NavigationItem.RightBarButtonItem = rightNavigationButton;

			// Create the table view source.
			var source = new MvxSimpleTableViewSource(TableView, FilesTableViewCell.Key, FilesTableViewCell.Key);

			// Create and apply the binding set.
			var set = this.CreateBindingSet<FilesTabView, GroupViewModel>();
			set.Bind(source).To(vm => vm.Files);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.FileClickCommand);
			set.Apply();

			// Set the table view source and refresh.
			TableView.Source = source;
			TableView.RowHeight = 60;
			TableView.ReloadData();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


