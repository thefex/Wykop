using System.Collections.Generic;
using Windows.UI.Xaml.Documents;
using HtmlAgilityPack;

namespace Wykop.ApiProvider.XamlParser.NodeParser
{
    public interface IHtmlNodeParser
    {
        IEnumerable<Inline> GetInlineElements(HtmlNode fromHtmlNode);
    }
}