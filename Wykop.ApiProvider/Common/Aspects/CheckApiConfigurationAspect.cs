//using PostSharp.Aspects;
//using PostSharp.Serialization;
//using Wykop.ApiProvider.Exceptions;

//namespace Wykop.ApiProvider.Common.Aspects
//{
//    [PSerializable]
//    internal class CheckApiConfigurationAspect : MethodInterceptionAspect
//    {
//        public override void OnInvoke(MethodInterceptionArgs args)
//        {
//            if ( !WykopApiConfiguration.IsConfigured())
//                throw new NotConfiguredApiException();

//            base.OnInvoke(args);
//        }
//    }
//}