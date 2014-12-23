using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Wykop.Common.Strings;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Wykop.View
{
    public sealed partial class WykopHeaderUserControl : UserControl
    {
        public WykopHeaderUserControl()
        {
            this.InitializeComponent();
            MirkoLogo.Source = App.ImageApplicationCache.GetImage(ImagesPath.WykopLogoUri);
        }
    }
}
