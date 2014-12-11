using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wykop.ApiProvider.Data.LinkRequest.User
{
    public abstract class UserPagedLinksRequest : UserLinksRequest
    {
        protected UserPagedLinksRequest(string userName) 
            : base(userName)
        {
        }

        public int RequestedPage { get; set; }

        protected override void BuildParameters()
        {
            base.BuildParameters();


        }
    }
}
