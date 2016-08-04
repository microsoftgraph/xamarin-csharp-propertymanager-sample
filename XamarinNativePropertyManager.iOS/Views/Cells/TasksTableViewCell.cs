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
	public partial class TasksTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("TasksTableViewCell");
		public static readonly UINib Nib;

		static TasksTableViewCell()
		{
			Nib = UINib.FromName("TasksTableViewCell", NSBundle.MainBundle);
		}

		protected TasksTableViewCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				// Create and apply the binding set.
				var set = this.CreateBindingSet<TasksTableViewCell, TaskModel>();
				set.Bind(TitleLabel).To(vm => vm.Title);
				set.Apply();
			});
		}
	}
}
