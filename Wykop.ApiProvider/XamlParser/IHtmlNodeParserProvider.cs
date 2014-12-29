using HtmlAgilityPack;
using Wykop.ApiProvider.XamlParser.NodeParser;

namespace Wykop.ApiProvider.XamlParser
{
    public interface IHtmlNodeParserProvider
    {
        IHtmlNodeParser GetParser(HtmlNode forHtmlNode);
    }
}