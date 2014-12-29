using System.Collections.Generic;
using Windows.UI.Xaml.Documents;
using HtmlAgilityPack;
using Wykop.ApiProvider.XamlParser.Attributes;

namespace Wykop.ApiProvider.XamlParser.NodeParser
{
    [HtmlNodeParserType(typeof(LineBreakHtmlNodeParser), NodeName = "br")]
    public class LineBreakHtmlNodeParser : IHtmlNodeParser
    {
        public IEnumerable<Inline> GetInlineElements(HtmlNode fromHtmlNode)
        {
            yield return new LineBreak();
        }
    }
}