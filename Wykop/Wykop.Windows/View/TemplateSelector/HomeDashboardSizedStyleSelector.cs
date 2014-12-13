using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Wykop.ApiProvider.Model;

namespace Wykop.View.TemplateSelector
{
    public class HomeDashboardSizedStyleSelector : StyleSelector
    {
        public Style WithoutPreviewStyle { get; set; }
        public Style WithPreviewStyle { get; set; }


        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            Link linkItem = item as Link;

            return linkItem.PreviewImage == null ? WithoutPreviewStyle : WithPreviewStyle;
        }
    }
}