/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.Visibility;
using UIKit;
using XamarinNativePropertyManager.iOS.Converters;
using XamarinNativePropertyManager.iOS.Services;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.iOS
{
    public class Setup : MvxIosSetup
    {
		protected override List<Type> ValueConverterHolders => new List<Type>
		{
		    typeof(MvxVisibilityValueConverter),
		    typeof(MvxInvertedVisibilityValueConverter),
		    typeof(FileTypeToIconConverter)
		};

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
