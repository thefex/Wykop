using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Wykop.ApiProvider.Model;

namespace Wykop.View.TemplateSelector
{
    public class HomeDashboardDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WithPreview { get; set; }
        public DataTemplate WithoutPreview { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var linkItem = item as Link;

            return linkItem.PreviewImage == null ? WithoutPreview : WithPreview;
        }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var linkItem = item as Link;

            return linkItem.PreviewImage == null ? WithoutPreview : WithPreview;
        }
    }
}