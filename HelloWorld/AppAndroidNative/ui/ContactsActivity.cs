
using Acr.UserDialogs;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Widget;

namespace AppAndroidNative.ui
{
    [Activity(Label = "ContactsActivity")]
    public class ContactsActivity : FragmentActivity
    {
        private const string TAG = "ContactsActivity";
        private FrameLayout flContainer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            System.Console.WriteLine(TAG, "OnCreate");
            base.OnCreate(savedInstanceState);

            UserDialogs.Init(this);

            SetContentView(Resource.Layout.layout_contacts);

            flContainer = (FrameLayout)FindViewById(Resource.Id.fl_container);

            var contactsListFragment = new ContactsListFragment();
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Add(Resource.Id.fl_container, contactsListFragment);
            ft.Commit();
        }
    }
}