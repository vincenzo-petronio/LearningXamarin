using Acr.UserDialogs;
using Android;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using AppAndroidNative.ui.adapters;
using System;
using System.Collections.Generic;

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
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                {
                    initUI();
                }
                else
                {
                    // TODO permission denied, boo! Disable the
                    // functionality that depends on this permission.
                }
            }
        }

        private void initUI()
        {
            Log.Debug(TAG, "initUI");
            ContactsAdapter contactsAdapter = new ContactsAdapter(this.Activity, getContacts());
            rvContacts.SetAdapter(contactsAdapter);
            rvContacts.SetLayoutManager(new LinearLayoutManager(this.Activity));
        }

        private List<data.Contact> getContacts()
        {
            var contactsList = new List<data.Contact>();

            var uri = ContactsContract.Contacts.ContentUri;

            string[] projection = {
                ContactsContract.Contacts.InterfaceConsts.Id,
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.Contacts.InterfaceConsts.PhotoThumbnailUri,
            };

            //var cursor = this.Activity.ManagedQuery(uri, projection, null, null, null);
            var cursor = this.Activity.ContentResolver.Query(uri, projection, null, null, null);
            if (cursor.MoveToFirst())
            {
                do
                {
                    contactsList.Add(new data.Contact
                    {
                        Id = cursor.GetLong(cursor.GetColumnIndex(projection[0])),
                        Name = cursor.GetString(cursor.GetColumnIndex(projection[1])),
                        PhotoId = cursor.GetString(cursor.GetColumnIndex(projection[2]))
                    });
                } while (cursor.MoveToNext());
            }

            return contactsList;
        }

        private void ShowReadContactsPermission()
        {
            if (ActivityCompat.CheckSelfPermission(Activity, Manifest.Permission.ReadContacts) != Permission.Granted)
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

        private async void RequestReadContactsPermission()
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(this.Activity, Android.Manifest.Permission.ReadContacts))
            {
                // TODO
                var result = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
                {
                    Message = "Contact access is required!",
                    OkText = "Ok",
                    CancelText = "No",
                    //OnAction = ,
                    Title = "Request permission"
                });
                if (result)
                {
                    ActivityCompat.RequestPermissions(this.Activity, new string[] { Manifest.Permission.ReadContacts }, REQUEST_CONTACTS);
                }
            }
            else
            {
                ActivityCompat.RequestPermissions(this.Activity, new string[] { Manifest.Permission.ReadContacts }, REQUEST_CONTACTS);
            }
        }
    }
}