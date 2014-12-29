using System.Collections.Generic;
using Windows.UI.Xaml.Documents;
using HtmlAgilityPack;

namespace Wykop.ApiProvider.XamlParser.NodeParser
{
    public class DefaultHtmlNodeParser : IHtmlNodeParser
    {
        private readonly static char[] CharactersToIgnore = new char[] { '@', '#' };

        public IEnumerable<Inline> GetInlineElements(HtmlNode fromHtmlNode)
        {
            string textToDisplay = fromHtmlNode
                .InnerText
                .Trim(CharactersToIgnore)
                .Replace("\n", "") // if html requested wykop api returns both "\n" and <br> - awesome idea!
                .Replace("&quot;", "\"");

            yield return new Run {Text = textToDisplay };
        }
    }
}