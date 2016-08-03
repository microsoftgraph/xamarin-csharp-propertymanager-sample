using System.Threading.Tasks;
using MvvmCross.iOS.Views;
using UIKit;

namespace XamarinNativePropertyManager.iOS
{
	public static class ViewControllerExtensions
	{
		public static void SetNavigationBarStyle(this UIViewController viewController)
		{
			viewController.NavigationController.NavigationBar.TintColor = UIColor.White;
			viewController.NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(0, 120, 215);
			viewController.NavigationController.NavigationBar.BackgroundColor = UIColor.FromRGB(0, 120, 215);
			viewController.NavigationController.View.BackgroundColor = UIColor.FromRGB(0, 120, 215);
			viewController.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
			viewController.NavigationController.NavigationBar.Translucent = false;
			viewController.NavigationController.NavigationBar.Layer.BorderWidth = 0;
			viewController.NavigationController.NavigationBar.Layer.BorderColor = UIColor.Clear.CGColor;
			viewController.NavigationController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarPosition.Any, UIBarMetrics.Default);
			viewController.NavigationController.NavigationBar.ShadowImage = new UIImage();
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
			{
				TextColor = UIColor.White
			});
		}

		public static void ShowNavigationBar(this MvxViewController viewController, bool animated = false)
		{
			viewController.NavigationController.SetNavigationBarHidden(false, animated);
		}

		public static void HideNavigationBar(this MvxViewController viewController, bool animated = false)
		{
			viewController.NavigationController.SetNavigationBarHidden(true, animated);
		}

		public static void ShowNavigationBar(this MvxTabBarViewController viewController, bool animated = false)
		{
			viewController.NavigationController.SetNavigationBarHidden(false, animated);
		}

		public static void HideNavigationBar(this MvxTabBarViewController viewController, bool animated = false)
		{
			viewController.NavigationController.SetNavigationBarHidden(true, animated);
		}

		public static Task<string> GetTextFromAlertAsync(this MvxViewController viewController, string title, 
		                                                  string message = null, string placeholder = null)
		{
			// Create the task completion source.
			var taskCompletionSource = new TaskCompletionSource<string>();

			// Create the alert controller.
			UIAlertController alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
			alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, 
			                                               (obj) => taskCompletionSource.SetResult(alertController.TextFields[0].Text)));
			alertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, 
			                                               (obj) => taskCompletionSource.SetResult(null)));

			// Add the text field.
			alertController.AddTextField((obj) =>
			{
				obj.Placeholder = placeholder; 
				obj.BorderStyle = UITextBorderStyle.RoundedRect;
			});

			// Show the alert controller.
			viewController.PresentViewController(alertController, true, () =>
			{
				// Fix background/effect bug that ocurrs with text fields in 
				// an alert controller.
				for (var i = 0; i < alertController.TextFields.Length; i++)
				{
					var textField = alertController.TextFields[i];
					var superView = textField.Superview;
					var effectView = superView.Superview.Subviews[0] as UIVisualEffectView;
					if (effectView != null)
					{
						superView.BackgroundColor = UIColor.Clear;
						effectView.RemoveFromSuperview();
					}
				}
			});

			return taskCompletionSource.Task;
		}
	}
}