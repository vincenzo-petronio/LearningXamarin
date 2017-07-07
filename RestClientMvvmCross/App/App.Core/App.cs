using Acr.UserDialogs;
using App.Core.Services;
using App.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace App.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.LazyConstructAndRegisterSingleton<IApiService, ApiService>();
            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            RegisterAppStart<HomeViewModel>();
        }
    }
}
