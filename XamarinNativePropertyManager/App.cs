/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
			Mvx.LazyConstructAndRegisterSingleton<IHttpService, HttpService>();
			Mvx.LazyConstructAndRegisterSingleton<IConfigService, ConfigService>();
			Mvx.LazyConstructAndRegisterSingleton<IGraphService, GraphService>();
            RegisterAppStart<ViewModels.LoginViewModel>();
        }
    }
}