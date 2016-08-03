using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using XamarinNativePropertyManager.Models;
using UIKit;

namespace XamarinNativePropertyManager.iOS.Views.Cells
{
	public partial class FilesTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("FilesTableViewCell");
		public static readonly UINib Nib;

		static FilesTableViewCell()
		{
			Nib = UINib.FromName("FilesTableViewCell", NSBundle.MainBundle);
		}

		protected FilesTableViewCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				// Create and apply the binding set.
				var set = this.CreateBindingSet<FilesTableViewCell, FileModel>();
				set.Bind(NameLabel).To(vm => vm.DriveItem.Name);
				set.Bind(UrlLabel).To(vm => vm.DriveItem.WebUrl);
				set.Bind(ImageView).To(vm => vm.Type).WithConversion("FileTypeToIcon");
				set.Apply();
			});
		}
	}
}
