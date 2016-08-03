using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using XamarinNativePropertyManager.Models;
using UIKit;

namespace XamarinNativePropertyManager.iOS.Views.Cells
{
	public partial class ConversationsTableRightViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("ConversationsTableRightViewCell");
		public static readonly UINib Nib;

		static ConversationsTableRightViewCell()
		{
			Nib = UINib.FromName("ConversationsTableRightViewCell", NSBundle.MainBundle);
		}

		protected ConversationsTableRightViewCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				// Create and apply the binding set.
				var set = this.CreateBindingSet<ConversationsTableRightViewCell, ConversationModel>();
				set.Bind(MessageLabel).For(t => t.Text).To(vm => vm.Preview);
				set.Bind(SenderLabel).For(t => t.Text).To(vm => vm.UniqueSenders[0]);
				set.Apply();
			});
		}
	}
}
