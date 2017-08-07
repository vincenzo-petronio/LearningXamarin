using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCrossForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPageExample : TabbedPage
    {
        public TabbedPageExample()
        {
            InitializeComponent();
            initTab();
        }

        private void initTab()
        {
            Children.Add(new ContentPage() { Title = "TAB 1", BackgroundColor = Color.AliceBlue });
            Children.Add(new ContentPage() { Title = "TAB 2", BackgroundColor = Color.Aqua });
            Children.Add(new ContentPage() { Title = "TAB 3", BackgroundColor = Color.Beige });
            Children.Add(new NavigationPage(new ListViewPage()) { Title = "TAB 4", BackgroundColor = Color.Red });
        }
    }
}