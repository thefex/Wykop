using Wykop.ApiProvider.Data.LinkRequest.Helpers;
using Wykop.ApiProvider.Model;

namespace Wykop.ApiProvider.Data.MyWykop
{
    public abstract class MyWykopRequest : WykopRequestBase
    {
        private readonly string _userKey;

        protected MyWykopRequest(LoggedUser loggedUser)
            : this(loggedUser.UserKey)
        {
        }

        protected MyWykopRequest(string userKey)
        {
            _userKey = userKey;
        }

        internal override string GetResourceTypeName()
        {
            return "MyWykop";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            var userKeyParameter = ApiParameterProvider.GetUserKeyParameter(_userKey);
            var applicationKeyParameter = ApiParameterProvider.GetApplicationKeyParameter();
    
            AddApiParameterToRequest(userKeyParameter);
            AddApiParameterToRequest(applicationKeyParameter);
        }
    }
}