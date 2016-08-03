// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamarinNativePropertyManager.iOS.Views.Tabs
{
	[Register ("DetailsTabView")]
	partial class DetailsTabView
	{
		[Outlet]
		UIKit.UIView ContentView { get; set; }

		[Outlet]
		UIKit.UILabel DescriptionLabel { get; set; }

		[Outlet]
		UIKit.UILabel LivingAreaLabel { get; set; }

		[Outlet]
		UIKit.UILabel LotSizeLabel { get; set; }

		[Outlet]
		UIKit.UILabel OperatingCostsLabel { get; set; }

		[Outlet]
		UIKit.UILabel RoomsLabel { get; set; }

		[Outlet]
		UIKit.UIScrollView ScrollView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DescriptionLabel != null) {
				DescriptionLabel.Dispose ();
				DescriptionLabel = null;
			}

			if (RoomsLabel != null) {
				RoomsLabel.Dispose ();
				RoomsLabel = null;
			}

			if (LivingAreaLabel != null) {
				LivingAreaLabel.Dispose ();
				LivingAreaLabel = null;
			}

			if (LotSizeLabel != null) {
				LotSizeLabel.Dispose ();
				LotSizeLabel = null;
			}

			if (OperatingCostsLabel != null) {
				OperatingCostsLabel.Dispose ();
				OperatingCostsLabel = null;
			}

			if (ScrollView != null) {
				ScrollView.Dispose ();
				ScrollView = null;
			}

			if (ContentView != null) {
				ContentView.Dispose ();
				ContentView = null;
			}
		}
	}
}
