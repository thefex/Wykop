using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wykop.View;

namespace Wykop.ViewModel.Dashboard
{
    public class UserProfileViewModel : BaseViewModel
    {
        public UserProfileViewModel(ViewServices viewServices) : base(viewServices)
        {
        }

        public override Task Load()
        {
            return base.Load();
        }
    }
}
