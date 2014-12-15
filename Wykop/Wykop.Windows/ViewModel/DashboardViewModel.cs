﻿using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Wykop.Common;
using Wykop.View;
using Wykop.ViewModel.Dashboard;

namespace Wykop.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel(ViewServices viewServices) : base(viewServices)
        {
            NavigateToMikroblog = new RelayCommand(() => Navigation.NavigateTo(NavigationPageKeys.MikroblogPageKey));
        }

        public HomeDashboardViewModel Home { get; set; }
        public HotDashboardViewModel Hot { get; set; }
        public WykopaliskoDashboardViewModel Wykopalisko { get; set; }

        public RelayCommand NavigateToMikroblog { get; private set; }

        public override async Task Load()
        {
            await base.Load();
            await Home.Load();
            await Wykopalisko.Load();
            await Hot.Load();
        }
    }
}