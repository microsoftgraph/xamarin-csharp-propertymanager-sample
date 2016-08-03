using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using XamarinNativePropertyManager.ViewModels;
using UIKit;

namespace XamarinNativePropertyManager.iOS.Views.Tabs
{
	public partial class DetailsTabView : MvxViewController
	{
		public DetailsTabView() : base("DetailsTabView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var viewModel = ViewModel as GroupViewModel;

			// Set view title and prompt.
			NavigationItem.Title = "Details";
			NavigationItem.Prompt = viewModel.Group.DisplayName;

			// Add left navigation bar item.
			var leftNavigationButton = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, e) =>
															viewModel.GoBackCommand.Execute(null));
			NavigationItem.LeftBarButtonItem = leftNavigationButton;

			// Add right navigation bar item.
			var rightNavigationButton = new UIBarButtonItem(UIBarButtonSystemItem.Edit, (sender, e) =>
			                                                viewModel.EditDetailsCommand.Execute(null));
			NavigationItem.RightBarButtonItem = rightNavigationButton;

			// Create and apply the binding set.
			var set = this.CreateBindingSet<DetailsTabView, GroupViewModel>();
			set.Bind(DescriptionLabel).To(vm => vm.Details.Description);
			set.Bind(RoomsLabel).To(vm => vm.Details.Rooms);
			set.Bind(LivingAreaLabel).To(vm => vm.Details.LivingArea);
			set.Bind(LotSizeLabel).To(vm => vm.Details.LotSize);
			set.Bind(OperatingCostsLabel).To(vm => vm.Details.OperatingCosts);
			set.Apply();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			var frame = ContentView.Frame;
			ScrollView.ContentSize = new CoreGraphics.CGSize(frame.Size.Width, frame.Size.Height + 49);
		}
	}
}


