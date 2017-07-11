using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace AppAndroidNative.ui.adapters
{
    class ContactsAdapter : RecyclerView.Adapter
    {
        public event EventHandler<ContactsAdapterClickEventArgs> ItemClick;
        public event EventHandler<ContactsAdapterClickEventArgs> ItemLongClick;
        string[] items;

        public ContactsAdapter(string[] data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            //var id = Resource.Layout.__YOUR_ITEM_HERE;
            //itemView = LayoutInflater.From(parent.Context).
            //       Inflate(id, parent, false);

            var vh = new ContactsAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as ContactsAdapterViewHolder;
            //holder.TextView.Text = items[position];
        }

        public override int ItemCount => items.Length;

        void OnClick(ContactsAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(ContactsAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class ContactsAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }


        public ContactsAdapterViewHolder(View itemView, Action<ContactsAdapterClickEventArgs> clickListener,
                            Action<ContactsAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
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