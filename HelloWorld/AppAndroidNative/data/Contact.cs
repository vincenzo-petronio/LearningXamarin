using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppAndroidNative.data
{
    class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Id { get; set; }
        public string PhotoId { get; set; }
    }
}