using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Util;
using Com.Bumptech.Glide;
using Android.Content;

namespace AppAndroidNative.ui.adapters
{
    class ContactsAdapter : RecyclerView.Adapter
    {
        public event EventHandler<ContactsAdapterClickEventArgs> ItemClick;
        public event EventHandler<ContactsAdapterClickEventArgs> ItemLongClick;
        private List<data.Contact> items;
        private Context context;

        public ContactsAdapter(Context ctx, List<data.Contact> contacts)
        {
            this.context = ctx;
            items = contacts;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.row_contact;
            itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            var vh = new ContactsAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as ContactsAdapterViewHolder;
            holder.FullName.Text = items[position].Name + items[position].Surname;
            holder.Id.Text = items[position].Id.ToString();
            Glide.With(context).Load(items[position].PhotoId).Error(Resource.Drawable.ic_contacts_black_48dp)
                 .Placeholder(Resource.Drawable.ic_contacts_black_48dp)
                 .Into(holder.Photo);
        }

        public override int ItemCount => items.Count;

        void OnClick(ContactsAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(ContactsAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class ContactsAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView FullName { get; set; }
        public ImageView Photo { get; set; }
        public TextView Id { get; set; }

        public ContactsAdapterViewHolder(View itemView, Action<ContactsAdapterClickEventArgs> clickListener,
                            Action<ContactsAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            FullName = itemView.FindViewById<TextView>(Resource.Id.tv_fullname);
            Photo = itemView.FindViewById<ImageView>(Resource.Id.iv_photo);
            Id = itemView.FindViewById<TextView>(Resource.Id.tv_id);

            itemView.Click += (sender, e) => clickListener(new ContactsAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new ContactsAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class ContactsAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}