using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace AppAndroidNative
{
    [Activity(Label = "AppAndroidNative", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private const string TAG = "MainActivity";
        private List<string> mListItems = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            System.Console.WriteLine(TAG, "OnCreate");

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            TextView tvTitle = FindViewById<TextView>(Resource.Id.tv_title);
            ListView lvItems = FindViewById<ListView>(Resource.Id.lv_items);

            for (int i = 0; i < 100; i++)
            {
                mListItems.Add("new string with id= " + i);
            }

            lvItems.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mListItems);
            // lvItems.ItemClick += LvItems_ItemClick;
            lvItems.ItemClick += (sender, args) =>
            {
                string itemClicked = mListItems[args.Position];
                Toast.MakeText(this, itemClicked, ToastLength.Short).Show();
            };
        }

        protected override void OnResume()
        {
            System.Console.WriteLine(TAG, "OnResume");
            base.OnResume();
        }

        protected override void OnDestroy()
        {
            System.Console.WriteLine(TAG, "OnDestroy");
            base.OnDestroy();
        }

        private void LvItems_ItemClick(object sender, AdapterView.ItemClickEventArgs args)
        {
            string itemClicked = mListItems[args.Position];
            Toast.MakeText(this, itemClicked, ToastLength.Short).Show();
        }

        public void OnBtnContactsClickListener(View view)
        {
            switch (view.Id)
            {
                case Resource.Id.btnContacts:
                    // TODO
                    break;
            }
        }
    }
}

