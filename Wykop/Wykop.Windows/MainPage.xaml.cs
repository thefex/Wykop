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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Wykop.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Wykop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MirkoLogoImage_OnImageOpened(object sender, RoutedEventArgs e)
        {
            const double wykopHeaderMarginLeft = 45;
            const double wykopHeaderMarginTop = 15;

            var imageSender = sender as Image;
            Storyboard leaveAnimationStoryboard = Resources["OnPageLeaveStoryboard"] as Storyboard;
            var renderTransformAnimations = leaveAnimationStoryboard.Children
                .Where(x => x is DoubleAnimation)
                .Cast<DoubleAnimation>()
                .ToList();

            Point imagePosition = imageSender.TransformToVisual(this).TransformPoint(new Point(0, 0));
            Rect windowBounds = Window.Current.Bounds;

            renderTransformAnimations[0].To = -imagePosition.X+wykopHeaderMarginLeft;
            renderTransformAnimations[1].To = -imagePosition.Y+wykopHeaderMarginTop;
        }

        private void OnPageLeaveStoryboard_OnCompleted(object sender, object e)
        {
            (this.DataContext as LoginPageViewModel).TransferToDashboardCommand.Execute(null);
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            acceptFlyout.Hide();
        }
    }
}
