// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamarinNativePropertyManager.iOS.Views.Cells
{
	[Register ("ConversationsTableRightViewCell")]
	partial class ConversationsTableRightViewCell
	{
		[Outlet]
		UIKit.UILabel MessageLabel { get; set; }

		[Outlet]
		UIKit.UILabel SenderLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MessageLabel != null) {
				MessageLabel.Dispose ();
				MessageLabel = null;
			}

			if (SenderLabel != null) {
				SenderLabel.Dispose ();
				SenderLabel = null;
			}
		}
	}
}
