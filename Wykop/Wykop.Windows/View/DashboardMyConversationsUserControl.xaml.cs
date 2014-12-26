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
using Wykop.ApiProvider.Model.MessagesRelated;
using Wykop.ViewModel;
using Wykop.ViewModel.Dashboard;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Wykop.View
{
    public sealed partial class DashboardMyConversationsUserControl : UserControl
    {
        public DashboardMyConversationsUserControl()
        {
            this.InitializeComponent();
        }

        private void ConversationListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            // to be honest it shouldn't exists and behavior should be used
            // but: i had problems with "null" item passed by ItemClickEventArgs in past (in other apps)
            // so i decided to keep it in codebehind with null check

            var conversationList = e.ClickedItem as ConversationList;

            if (conversationList == null)
                return;

            GetViewModel().GoToConversationCommand.Execute(conversationList);
        }

        private MyConversationsViewModel GetViewModel()
        {
            return this.DataContext as MyConversationsViewModel;
        }
    }
}
