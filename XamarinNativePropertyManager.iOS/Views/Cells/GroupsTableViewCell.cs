/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using XamarinNativePropertyManager.Models;
using UIKit;

namespace XamarinNativePropertyManager.iOS.Views.Cells
{
	public partial class GroupsTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("GroupsTableViewCell");
		public static readonly UINib Nib;

		static GroupsTableViewCell()
		{
			Nib = UINib.FromName("GroupsTableViewCell", NSBundle.MainBundle);
		}

		protected GroupsTableViewCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() => 
			{
				// Create and apply the binding set.
				var set = this.CreateBindingSet<GroupsTableViewCell, GroupModel>();
				set.Bind(NameLabel).To(vm => vm.DisplayName);
				set.Bind(MailLabel).To(vm => vm.Mail);
				set.Apply();
			});
		}
	}
}
