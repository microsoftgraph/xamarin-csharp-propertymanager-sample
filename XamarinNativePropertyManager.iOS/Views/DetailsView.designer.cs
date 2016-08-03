// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamarinNativePropertyManager.iOS.Views
{
	[Register ("DetailsView")]
	partial class DetailsView
	{
		[Outlet]
		UIKit.UIView ContentView { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint DescriptionLabelTopConstraint { get; set; }

		[Outlet]
		UIKit.UITextField DescriptionTextField { get; set; }

		[Outlet]
		UIKit.UITextView DescriptionTextView { get; set; }

		[Outlet]
		UIKit.UITextField LivingAreaTextField { get; set; }

		[Outlet]
		UIKit.UITextField LotSizeTextField { get; set; }

		[Outlet]
		UIKit.UITextField OperatingCostsTextField { get; set; }

		[Outlet]
		UIKit.UITextField RoomsTextField { get; set; }

		[Outlet]
		UIKit.UIScrollView ScrollView { get; set; }

		[Outlet]
		UIKit.UILabel StreetNameLabel { get; set; }

		[Outlet]
		UIKit.UITextField StreetNameTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ContentView != null) {
				ContentView.Dispose ();
				ContentView = null;
			}

			if (DescriptionTextField != null) {
				DescriptionTextField.Dispose ();
				DescriptionTextField = null;
			}

			if (DescriptionTextView != null) {
				DescriptionTextView.Dispose ();
				DescriptionTextView = null;
			}

			if (LivingAreaTextField != null) {
				LivingAreaTextField.Dispose ();
				LivingAreaTextField = null;
			}

			if (LotSizeTextField != null) {
				LotSizeTextField.Dispose ();
				LotSizeTextField = null;
			}

			if (OperatingCostsTextField != null) {
				OperatingCostsTextField.Dispose ();
				OperatingCostsTextField = null;
			}

			if (RoomsTextField != null) {
				RoomsTextField.Dispose ();
				RoomsTextField = null;
			}

			if (ScrollView != null) {
				ScrollView.Dispose ();
				ScrollView = null;
			}

			if (StreetNameLabel != null) {
				StreetNameLabel.Dispose ();
				StreetNameLabel = null;
			}

			if (StreetNameTextField != null) {
				StreetNameTextField.Dispose ();
				StreetNameTextField = null;
			}

			if (DescriptionLabelTopConstraint != null) {
				DescriptionLabelTopConstraint.Dispose ();
				DescriptionLabelTopConstraint = null;
			}
		}
	}
}
