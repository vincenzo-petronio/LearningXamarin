using Acr.UserDialogs;
using Android;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using System;

namespace AppAndroidNative.ui
{
    public class ContactsListFragment : Fragment
    {
        private const string TAG = "ContactsListFragment";
        private static readonly int REQUEST_CONTACTS = 100;
        private RecyclerView rvContacts;

        public override void OnAttach(Context context)
        {
            Console.WriteLine(TAG, "OnAttach");
            base.OnAttach(context);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            Console.WriteLine(TAG, "OnCreate");
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Console.WriteLine(TAG, "OnCreateView");
            // Use this to return your custom view for this Fragment
            //return base.OnCreateView(inflater, container, savedInstanceState);

            View view = inflater.Inflate(Resource.Layout.fragment_contacts, container, false);
            rvContacts = view.FindViewById<RecyclerView>(Resource.Id.rv_contacts);

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            Console.WriteLine(TAG, "OnViewCreated");
            base.OnViewCreated(view, savedInstanceState);

            ShowReadContactsPermission();
        }

        public override void OnResume()
        {
            Console.WriteLine(TAG, "OnResume");
            base.OnResume();
        }

        public override void OnDestroyView()
        {
            Console.WriteLine(TAG, "OnDestroyView");
            base.OnDestroyView();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == REQUEST_CONTACTS)
            {
                if (grantResults.Length == 1 && grantResults[0] == Permission.Granted)
                {
                    initUI();
                }
                else
                {
                    // TODO
                }
            }
        }


        private void initUI()
        {
            //ContactsAdapter contactsAdapter = new ContactsAdapter();
            //rvContacts.SetAdapter();
            Log.Debug(TAG, "initUI");
        }

        private void ShowReadContactsPermission()
        {
            if (ActivityCompat.CheckSelfPermission(Activity, Manifest.Permission.ReadContacts) != (int)Permission.Granted)
            {
                Log.Info(TAG, "Contact permissions has NOT been granted. Requesting permissions.");
                RequestReadContactsPermission();
            }
            else
            {
                Log.Info(TAG, "Contact permissions have already been granted. Displaying contact details.");
                initUI();
            }
        }

        private void RequestReadContactsPermission()
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(this.Activity, Android.Manifest.Permission.ReadContacts))
            {
                // TODO
                UserDialogs.Instance.ConfirmAsync("message request permission", "Request", "ok", "no");
                
            }
            else
            {
                ActivityCompat.RequestPermissions(this.Activity, new string[] { Manifest.Permission.ReadContacts }, REQUEST_CONTACTS);
            }
        }
    }
}