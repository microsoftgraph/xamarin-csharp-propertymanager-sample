using MvvmCross.iOS.Views;
using XamarinNativePropertyManager.ViewModels;
using MvvmCross.Binding.BindingContext;
using XamarinNativePropertyManager.iOS.Extensions;

namespace XamarinNativePropertyManager.iOS.Views
{
	public partial class LoginView : MvxViewController<LoginViewModel>
	{
		public LoginView() : base("LoginView", null)
		{
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Set navigation bar style.
			this.SetNavigationBarStyle();

			// Hide the navigation bar.
			this.HideNavigationBar();

			// Create and apply the binding set.
			var set = this.CreateBindingSet<LoginView, LoginViewModel>();
			set.Bind(SignInButton).To(vm => vm.LoginCommand);
			set.Bind(SignInButton).For("Visibility").To(vm => vm.IsLoading).WithConversion("InvertedVisibility");
			set.Bind(ActivityIndicator).For("Visibility").To(vm => vm.IsLoading).WithConversion("Visibility");
			set.Apply();
		}

		public override void ViewWillAppear(bool animated)
		{
			// Hide the navigation bar.
			this.HideNavigationBar(true);
			ViewModel.OnResume();
			base.ViewWillAppear(animated);
		}
	}
}


