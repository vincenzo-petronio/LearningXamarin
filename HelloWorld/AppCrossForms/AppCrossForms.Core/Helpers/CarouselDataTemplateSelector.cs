using AppCrossForms.Core.Models;
using AppCrossForms.Core.Views;
using Xamarin.Forms;

namespace AppCrossForms.Core.Helpers
{
    public class CarouselDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EvenTemplate { get; set; }
        public DataTemplate OddTemplate { get; set; }

        public CarouselDataTemplateSelector()
        {
            EvenTemplate = new DataTemplate(typeof(EvenView));
            OddTemplate = new DataTemplate(typeof(OddView));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((User)item).Id % 2 == 0 ? EvenTemplate : OddTemplate;
        }
    }
}
