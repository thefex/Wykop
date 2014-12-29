using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HtmlAgilityPack;
using Wykop.ApiProvider.XamlParser.Attributes;
using Wykop.ApiProvider.XamlParser.NodeParser;

namespace Wykop.ApiProvider.XamlParser
{
    /// <summary>
    /// Reflection based provider of IHtmlNodeParser.
    /// If IHtmlNodeParser needs IHtmlNodeProvider to parse HtmlNode
    //  then it should have constructor with one parameter - IHtmlNodeParserProvider. 
    // (DefaultHtmlNodeParserProvider will be passed)
    /// </summary>
    public class DefaultHtmlNodeParserProvider : IHtmlNodeParserProvider
    {
        private readonly IHtmlNodeParser _defaultHtmlNodeParser;
        private readonly IDictionary<string, IHtmlNodeParser> _nodeNameToParserMap;

        public DefaultHtmlNodeParserProvider()
        {
            _nodeNameToParserMap = GetHtmlNodeParsersMap();
            _defaultHtmlNodeParser = new DefaultHtmlNodeParser();
        }

        public IHtmlNodeParser GetParser(HtmlNode forHtmlNode)
        {
            if (_nodeNameToParserMap.ContainsKey(forHtmlNode.Name))
                return _nodeNameToParserMap[forHtmlNode.Name];

            return _defaultHtmlNodeParser;
        }

        private IDictionary<string, IHtmlNodeParser> GetHtmlNodeParsersMap()
        {
            var libraryAssembly = typeof (XamlHtmlParser).GetTypeInfo().Assembly;

            return
                libraryAssembly.DefinedTypes
                    .Where(CanCreateHtmlNodeParserInstanceFromType)
                    .Select(x =>
                    {
                        var htmlNodeParserAttribute = x.GetCustomAttribute<HtmlNodeParserTypeAttribute>();
                        var parserInstance = CreateHtmlNodeParserInstance(htmlNodeParserAttribute.ParserType);

                        return new
                        {
                            HtmlNodeName = htmlNodeParserAttribute.NodeName,
                            Parser = parserInstance
                        };
                    })
                    .ToDictionary(x => x.HtmlNodeName, x => x.Parser);
        }

        private IHtmlNodeParser CreateHtmlNodeParserInstance(Type forType)
        {
            object[] parserConstructor = {};
            var htmlNodeParserProviderTypeInfo = typeof (IHtmlNodeParserProvider).GetTypeInfo();

            var hasHtmlNodeParserProviderConstructor = forType.GetTypeInfo()
                .DeclaredConstructors
                .Any(constructorInfo =>
                {
                    var constructorParameters = constructorInfo.GetParameters();

                    if (constructorParameters.Count() != 1)
                        return false;

                    var parameterTypeInfo = constructorParameters.First().ParameterType.GetTypeInfo();

                    return htmlNodeParserProviderTypeInfo.IsAssignableFrom(parameterTypeInfo);
                });

            if (hasHtmlNodeParserProviderConstructor)
                parserConstructor = new object[] {this};

            return (IHtmlNodeParser) Activator.CreateInstance(
                forType,
                parserConstructor);
        }

        private bool CanCreateHtmlNodeParserInstanceFromType(TypeInfo typeInfo)
        {
            var htmlNodeParserTypeInfo = typeof (IHtmlNodeParser).GetTypeInfo();

            var isParserImplementationType = htmlNodeParserTypeInfo.IsAssignableFrom(typeInfo) &&
                                             !typeInfo.IsInterface && !typeInfo.IsAbstract;
            if (!isParserImplementationType)
                return false;

            return
                typeInfo.CustomAttributes.Any(
                    customAttribute => customAttribute.AttributeType == typeof (HtmlNodeParserTypeAttribute));
        }
    }
}