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