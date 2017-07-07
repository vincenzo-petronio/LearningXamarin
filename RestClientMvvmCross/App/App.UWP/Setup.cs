using MvvmCross.Core.ViewModels;
using MvvmCross.Uwp.Platform;
using Windows.UI.Xaml.Controls;

namespace App.UWP
{
    /// <summary>
    /// MvvmCross Bootstrap
    /// </summary>
    class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void InitializeFirstChance()
        {
            //Mvx.RegisterType<IDialogService, DialogService>();
            base.InitializeFirstChance();
        }
    }
}
