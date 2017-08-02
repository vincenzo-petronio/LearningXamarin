using AppCrossForms.Core.Models;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCrossForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExploreUIPage : ContentPage
    {
        #region PROPERTIES
        private List<User> items;
        //public List<User> Items
        //{
        //    get { return items; }
        //    set { items = value; }
        //}

        #endregion

        #region CONSTRUCTOR
        public ExploreUIPage()
        {
            InitializeComponent();

            items = new List<User>
            {
                new User() { Name = "John", Id = 1 },
                new User() { Name = "Aaron", Id = 2 },
                new User() { Name = "Gerard", Id = 3 }
            };
            this.carousel.ItemsSource = items;
        }

        #endregion
    }
}