/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using UIKit;
using CoreGraphics;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.iOS.Services
{
	public class ProgressDialogHandle : IDialogHandle
	{
		public UIAlertController AlertController { get; }

		public ProgressDialogHandle(string title, string message)
		{
			// Create alert controller.
			AlertController = UIAlertController.Create(title, message + "\n\n\n\n", UIAlertControllerStyle.Alert);
		    var activityIndicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge)
		    {
		        Center = new CGPoint(130.5, 120),
		        Color = UIColor.Black
		    };
		    activityIndicator.StartAnimating();

			// Add activity indicator.
			AlertController.View.AddSubview(activityIndicator);

			var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
			viewController.PresentViewController(AlertController, true, null);
		}

		public void Close()
		{
			AlertController.DismissViewController(true, null);
		}
	}
}

