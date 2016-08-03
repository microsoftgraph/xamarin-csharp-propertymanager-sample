using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using XamarinNativePropertyManager.Models;
using UIKit;

namespace XamarinNativePropertyManager.iOS.Views.Cells
{
	public partial class ConversationsTableLeftViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("ConversationsTableLeftViewCell");
		public static readonly UINib Nib;

		static ConversationsTableLeftViewCell()
		{
			Nib = UINib.FromName("ConversationsTableLeftViewCell", NSBundle.MainBundle);
		}

		protected ConversationsTableLeftViewCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				// Create and apply the binding set.
				var set = this.CreateBindingSet<ConversationsTableLeftViewCell, ConversationModel>();
				set.Bind(MessageLabel).For(t => t.Text).To(vm => vm.Preview);
				set.Bind(SenderLabel).For(t => t.Text).To(vm => vm.UniqueSenders[0]);
				set.Apply();
			});
		}

		public void SetValues(string message, string sender)
		{
			// Set text values.
			MessageLabel.Text = message;
			SenderLabel.Text = sender;

			// Set max width.
			MessageLabel.PreferredMaxLayoutWidth = Bounds.Width - 70 - 15;
		}
	}
}
