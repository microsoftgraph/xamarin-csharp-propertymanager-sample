using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using UIKit;
using XamarinNativePropertyManager.ViewModels;
using XamarinNativePropertyManager.Services;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using MvvmCross.Plugins.Visibility;
using XamarinNativePropertyManager.iOS.Services;

namespace XamarinNativePropertyManager.iOS
{
    public class Setup : MvxIosSetup
    {
		protected override List<Type> ValueConverterHolders
		{
			get
			{
				return new List<Type>
				{
					typeof(MvxVisibilityValueConverter),
					typeof(MvxInvertedVisibilityValueConverter),
					typeof(FileTypeToIconConverter)
				};
			}
		}

        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }
        
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
			// Register platform services.
			Mvx.RegisterSingleton(typeof(IAuthenticationService), new AuthenticationService());
			Mvx.RegisterSingleton(typeof(ILauncherService), new LauncherService());
			Mvx.RegisterSingleton(typeof(IFilePickerService), new FilePickerService());
			Mvx.RegisterSingleton(typeof(IDialogService), new DialogService());
            return new App();
        }
        
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
