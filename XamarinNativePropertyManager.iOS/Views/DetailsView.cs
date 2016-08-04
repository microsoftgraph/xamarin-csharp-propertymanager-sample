/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using XamarinNativePropertyManager.ViewModels;
using UIKit;
using XamarinNativePropertyManager.iOS.Extensions;

namespace XamarinNativePropertyManager.iOS.Views
{
	public partial class DetailsView : MvxViewController<DetailsViewModel>
	{
		public DetailsView() : base("DetailsView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Set view title.
			Title = ViewModel.Title;

			// Set navigation bar style.
			this.SetNavigationBarStyle();

			// Add left navigation bar item.
			var leftNavigationButton = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, e) =>
			                                                ViewModel.GoBackCommand.Execute(null));
			NavigationItem.LeftBarButtonItem = leftNavigationButton;

			// Add right navigation bar item.
			var rightNavigationButton = new UIBarButtonItem(UIBarButtonSystemItem.Save, (sender, e) =>
															ViewModel.SaveDetailsCommand.Execute(null));
			NavigationItem.RightBarButtonItem = rightNavigationButton;

			// Adjust description text field border.
			DescriptionTextField.BorderStyle = UITextBorderStyle.RoundedRect;

			// Feed the text from text view into the text field which serves
			// as the visual frame.
			DescriptionTextView.Changed += (sender, e) =>
			{
				DescriptionTextField.Text = DescriptionTextView.Text;
				ViewModel.Validate();
			};

			// Register event handlers to trigger validation.
			NSNotificationCenter.DefaultCenter.AddObserver(UITextField.TextFieldTextDidChangeNotification, obj =>
			{
				ViewModel.Validate();
			});
			NSNotificationCenter.DefaultCenter.AddObserver(UITextView.TextDidChangeNotification, obj =>
			{
				ViewModel.Validate();
			});

			// Move the labels and fields up if needed.
			if (ViewModel.IsExisting)
			{
				DescriptionLabelTopConstraint.Constant = -50;
			}

			// Register event handlers to trigger focus flow.
			StreetNameTextField.ShouldReturn += textField => DescriptionTextView.BecomeFirstResponder();
			RoomsTextField.ShouldReturn += textField => LivingAreaTextField.BecomeFirstResponder();
			LivingAreaTextField.ShouldReturn += textField => LotSizeTextField.BecomeFirstResponder();
			LotSizeTextField.ShouldReturn += textField => OperatingCostsTextField.BecomeFirstResponder();
			OperatingCostsTextField.ShouldReturn += textField => OperatingCostsTextField.ResignFirstResponder();

			// Create and apply the binding set.
			var set = this.CreateBindingSet<DetailsView, DetailsViewModel>();
			set.Bind(StreetNameTextField).To(vm => vm.StreetName);
			set.Bind(StreetNameLabel).For("Visibility").To(vm => vm.IsExisting).WithConversion("InvertedVisibility");
			set.Bind(StreetNameTextField).For("Visibility").To(vm => vm.IsExisting).WithConversion("InvertedVisibility");
			set.Bind(DescriptionTextView).To(vm => vm.Details.Description);
			set.Bind(RoomsTextField).To(vm => vm.Details.Rooms);
			set.Bind(LivingAreaTextField).To(vm => vm.Details.LivingArea);
			set.Bind(LotSizeTextField).To(vm => vm.Details.LotSize);
			set.Bind(OperatingCostsTextField).To(vm => vm.Details.OperatingCosts);
			set.Bind(rightNavigationButton).For(b => b.Enabled).To(vm => vm.IsValid);
			set.Apply();
		}

		public override void ViewWillAppear(bool animated)
		{
			// Show the navigation bar.
			this.ShowNavigationBar();
			ViewModel.OnResume();
			base.ViewWillAppear(animated);
		}
	}
}


