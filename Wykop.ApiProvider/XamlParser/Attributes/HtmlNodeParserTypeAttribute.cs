using System;

namespace Wykop.ApiProvider.XamlParser.Attributes
{
    public class HtmlNodeParserTypeAttribute : Attribute
    {
        public HtmlNodeParserTypeAttribute(Type parserType)
        {
            ParserType = parserType;
        }

        public string NodeName { get; set; }
        public Type ParserType { get; private set; }
    }
}