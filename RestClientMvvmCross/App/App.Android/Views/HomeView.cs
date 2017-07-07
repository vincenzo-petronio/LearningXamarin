
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace App.Droid.Views
{
    [Activity(Label = "HomeView", MainLauncher = true, NoHistory = true)]
    public class HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_homeview);
        }
    }
}