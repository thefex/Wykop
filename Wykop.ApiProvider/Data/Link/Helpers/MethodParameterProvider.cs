using System;
using RestSharp.Portable;

namespace Wykop.ApiProvider.Data.LinkRequest.Helpers
{
    internal class MethodParameterProvider
    {
        public static Parameter GetUsernameParameter(string username)
        {
            return new Parameter()
            {
                Name = "param1",
                Value = username,
                Type = ParameterType.QueryString
            };
        }

        public static Parameter GetYearParameter(string parameterName, DateTime dateTime)
        {
            return new Parameter()
            {
                Name = parameterName,
                Value = dateTime.Year,
                Type = ParameterType.QueryString
            };
        }

        public static Parameter GetMonthParameter(string parameterName, DateTime dateTime)
        {
            return new Parameter()
            {
                Name = parameterName,
                Value = dateTime.Month,
                Type = ParameterType.QueryString
            };
        }
    }
}
