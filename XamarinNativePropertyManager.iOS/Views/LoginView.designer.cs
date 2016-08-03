// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamarinNativePropertyManager.iOS
{
	[Register ("LoginView")]
	partial class LoginView
	{
		[Outlet]
		UIKit.UIActivityIndicatorView ActivityIndicator { get; set; }

		[Outlet]
		UIKit.UIButton SignInButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SignInButton != null) {
				SignInButton.Dispose ();
				SignInButton = null;
			}

			if (ActivityIndicator != null) {
				ActivityIndicator.Dispose ();
				ActivityIndicator = null;
			}
		}
	}
}
