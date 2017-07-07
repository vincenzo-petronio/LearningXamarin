
using Android.App;
using App.Core.Services;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace App.Droid.Services
{
    class DialogService : IDialogService
    {
        public void ShowDialog(string title, string message)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            var alertDialog = new AlertDialog.Builder(act);
            alertDialog.SetTitle(title);
            alertDialog.SetMessage(message);
            alertDialog.Create().Show();
        }
    }
}