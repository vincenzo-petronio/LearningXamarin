using AppCrossForms.Core;
using AppCrossForms.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCrossForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListViewPage() { });
        }

        private async void OnBtnCarouselClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExploreUIPage());
        }
    }
}
