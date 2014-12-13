using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wykop.ApiProvider.Model
{
    public class UsersIdList : IEnumerable<int>
    {
        private readonly IList<int> _userIds;

        internal UsersIdList(IEnumerable<int> userIds)
        {
            _userIds = userIds.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _userIds.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
