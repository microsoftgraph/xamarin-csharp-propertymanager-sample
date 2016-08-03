using System;
using System.Linq;
using MvvmCross.iOS.Views;
using XamarinNativePropertyManager.ViewModels;
using UIKit;
using MvvmCross.Platform.WeakSubscription;
using XamarinNativePropertyManager.iOS.Views.Tabs;

namespace XamarinNativePropertyManager.iOS.Views
{
	public partial class GroupView : MvxTabBarViewController<GroupViewModel>
	{
		private bool _viewConstructed;

		public GroupView()
		{
			// The ViewDidLoad method is called from the UIKit base constructor before 
			// the class constructor. This makes the ViewModel property inaccessible during
			// ViewDidLoad for MvxTabBarViewController. Workaround is to push logic to class
			// constructor. Shown at: https://github.com/MvvmCross/NPlus1DaysOfMvvmCross/blob/976ede3aafd3a7c6e06717ee48a9a45f08eedcd0/N-25-Tabbed/Tabbed.Touch/Views/FirstView.cs#L17
			_viewConstructed = true;
			ViewDidLoad();
		}

		public override void ViewWillAppear(bool animated)
		{
			// Hide the navigation bar.
			this.HideNavigationBar();
			ViewModel.OnResume();
			base.ViewDidAppear(animated);
		}

		public override void ViewDidLoad()
		{
			if (!_viewConstructed) 
			{
				return;
			}

			base.ViewDidLoad();

			// Create and set tabs.
			var viewControllers = new UIViewController[]
			{
				CreateTabViewController<DetailsTabView>("Details", "DetailsTabBarIcon", 0),
				CreateTabViewController<ConversationsTabView>("Conversations", "ConversationsTabBarIcon", 1),
				CreateTabViewController<FilesTabView>("Files", "FilesTabBarIcon", 2),
				CreateTabViewController<TasksTabView>("Tasks", "TasksTabBarIcon", 3)
			};
			ViewControllers = viewControllers;
			SelectedViewController = ViewControllers.First();

			// "Bind" the network activity indicator to the loading property.
			UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
			ViewModel.WeakSubscribe((sender, e) =>
			{
				if (e.PropertyName != nameof(ViewModel.IsLoading))
				{
					return;
				}
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = ViewModel.IsLoading;
			});
		}

		private UIViewController CreateTabViewController<T>(string title, string icon, nint index) where T : MvxViewController
		{
			// Create view controller.
			var viewController = Activator.CreateInstance(typeof(T)) as T;
			viewController.Title = title;
			viewController.TabBarItem = new UITabBarItem(title, UIImage.FromBundle(icon), index);
			viewController.ViewModel = ViewModel;

			// Create the navigation controller.
			var navigationController = new UINavigationController();

			//navigationController.NavigationItem.Title = Title;
			navigationController.PushViewController(viewController, false);

			// Set the navigation bar style.
			ViewControllerExtensions.SetNavigationBarStyle(viewController);

			return navigationController;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


