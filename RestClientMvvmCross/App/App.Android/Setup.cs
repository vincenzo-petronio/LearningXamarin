using Acr.UserDialogs;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace App.Droid
{
    class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void InitializeFirstChance()
        {
            UserDialogs.Init(() => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
            //Mvx.RegisterType<IDialogService, DialogService>();
            base.InitializeFirstChance();
        }
    }
}