using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Documents;
using HtmlAgilityPack;
using Wykop.ApiProvider.XamlParser.Attributes;

namespace Wykop.ApiProvider.XamlParser.NodeParser
{
    [HtmlNodeParserType(typeof(HyperlinkHtmlNodeParser), NodeName = "a")]
    public class HyperlinkHtmlNodeParser : IHtmlNodeParser
    {
        public IEnumerable<Block> GetBlocks(HtmlNode fromHtmlNode)
        {
           // fromHtmlNode.Attributes
            return new List<Block>();
        }

        public IEnumerable<Inline> GetInlineElements(HtmlNode fromHtmlNode)
        {
            var hyperLink = new Hyperlink();
            var hrefAttribute = fromHtmlNode.Attributes.Single(x => x.Name == "href");
            hyperLink.Inlines.Add(new Run() { Text = hrefAttribute.Value});

            yield return hyperLink;
        }
    }
}