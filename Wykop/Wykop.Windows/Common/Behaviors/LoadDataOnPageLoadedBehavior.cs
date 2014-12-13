using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;
using Wykop.Common.Interfaces;

namespace Wykop.Common.Behaviors
{
    public class LoadDataOnPageLoadedBehavior : DependencyObject, IBehavior
    {
        public void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;
            var page = AssociatedObject as Page;

            if (page == null)
                throw new InvalidOperationException("Behavior could be attached only to Page");

            page.Loaded += OnPageLoaded;
        }

        public void Detach()
        {
            (AssociatedObject as Page).Loaded -= OnPageLoaded;
            AssociatedObject = null;
        }

        public DependencyObject AssociatedObject { get; private set; }

        private async void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            var loadableDataContext = ((AssociatedObject as Page).DataContext as ILoadable);

            if (loadableDataContext != null)
                await loadableDataContext.Load();
        }
    }
}