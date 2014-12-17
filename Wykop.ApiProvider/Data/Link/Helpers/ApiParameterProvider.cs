using Wykop.ApiProvider.Common;
using Wykop.ApiProvider.Data.Types;

namespace Wykop.ApiProvider.Data.LinkRequest.Helpers
{
    public class ApiParameterProvider
    {
        public static ApiParameter GetUserKeyParameter(string userKeyValue)
        {
            return new ApiParameter
            {
                Name = "userkey",
                Value = userKeyValue
            };
        }

        public static ApiParameter GetApplicationKeyParameter()
        {
            return new ApiParameter
            {
                Name = "appkey",
                Value = WykopApiConfiguration.ApiKey
            };
        }

        public static ApiParameter GetPageParameter(int pageNumber)
        {
            return new ApiParameter
            {
                Name = "page",
                Value = pageNumber.ToString()
            };
        }

        public static ApiParameter GetSortParameter(SortType sortType)
        {
            return new ApiParameter
            {
                Name = "sort",
                Value = sortType.TextValue
            };
        }
    }
}