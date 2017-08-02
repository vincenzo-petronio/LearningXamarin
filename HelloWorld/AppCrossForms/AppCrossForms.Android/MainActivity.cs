using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using Xamarin.Forms.Platform.Android;
using CarouselView.FormsPlugin.Abstractions;

namespace AppCrossForms.Droid
{
    [Activity(Label = "AppCrossForms", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            // INIT
            global::Xamarin.Forms.Forms.Init(this, bundle);
            CarouselViewRenderer.Init();

            LoadApplication(new App());
        }
    }
}

