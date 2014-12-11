//using PostSharp.Aspects;
//using PostSharp.Serialization;
//using Wykop.ApiProvider.Exceptions;

//namespace Wykop.ApiProvider.Common.Aspects
//{
//    [PSerializable]
//    internal class RetryOnNetworkExceptionAspect : MethodInterceptionAspect
//    {
//        public override void OnInvoke(MethodInterceptionArgs args)
//        {
//            if (!WykopApiConfiguration.IsConnectionRetryEnabled)
//                base.OnInvoke(args);

//            uint maximalMethodExectionCount = WykopApiConfiguration.ConnectionRetryCount + 1;

//            while (true)
//            {
//                try
//                {
//                    base.OnInvoke(args);
//                    return;
//                }
//                catch (NetworkConnectionException)
//                {
//                    maximalMethodExectionCount--;
//                    if (maximalMethodExectionCount == 0)
//                        throw;
//                }
//            }
//        }
//    }
//}