using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wykop.ApiProvider.Exceptions
{
    public class InternalLibraryException : InvalidOperationException
    {
        public InternalLibraryException(string reason)
            : base(reason)
        {
            
        }
    }
}
