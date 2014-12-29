using System.Collections.Generic;
using Windows.UI.Xaml.Documents;
using HtmlAgilityPack;

namespace Wykop.ApiProvider.XamlParser
{
    public class XamlHtmlParser
    {
        private readonly IHtmlNodeParserProvider _htmlNodeParserProvider;

        public XamlHtmlParser(IHtmlNodeParserProvider htmlNodeParserProvider)
        {
            _htmlNodeParserProvider = htmlNodeParserProvider;
        }

        public IEnumerable<Block> GetBlocksFromHtmlString(string htmlString)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlString);
            var currentHtmlNode = htmlDocument.DocumentNode.FirstChild;

            var mainParagraph = new Paragraph();

            while (currentHtmlNode != null)
            {
                var currentElementTypeParser = _htmlNodeParserProvider.GetParser(currentHtmlNode);

                foreach (var inlineNodeElement in currentElementTypeParser.GetInlineElements(currentHtmlNode))
                    mainParagraph.Inlines.Add(inlineNodeElement);

                currentHtmlNode = currentHtmlNode.NextSibling;
            }

            yield return mainParagraph;
        }
    }
}