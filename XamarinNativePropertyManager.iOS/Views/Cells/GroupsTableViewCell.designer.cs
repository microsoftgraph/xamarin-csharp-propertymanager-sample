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
	[Register ("GroupsTableViewCell")]
	partial class GroupsTableViewCell
	{
		[Outlet]
		UIKit.UILabel MailLabel { get; set; }

		[Outlet]
		UIKit.UILabel NameLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (MailLabel != null) {
				MailLabel.Dispose ();
				MailLabel = null;
			}
		}
	}
}
