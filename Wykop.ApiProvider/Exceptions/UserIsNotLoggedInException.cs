using System;

namespace Wykop.ApiProvider.Exceptions
{
    public class UserIsNotLoggedInException : InvalidOperationException
    {
        public UserIsNotLoggedInException()
            : base("User is not logged in to perform this operation..")
        {
        }
    }
}