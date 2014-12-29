using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using HtmlAgilityPack;
using Wykop.ApiProvider.XamlParser.Attributes;

namespace Wykop.ApiProvider.XamlParser.NodeParser
{
    [HtmlNodeParserType(typeof (CodeHtmlNodeParser), NodeName = "code")]
    public class CodeHtmlNodeParser : IHtmlNodeParser
    {
        public IEnumerable<Inline> GetInlineElements(HtmlNode fromHtmlNode)
        {
            var classAttribute = fromHtmlNode.Attributes.Single(x => x.Name == "class");

            if (classAttribute.Value == "dnone")
            {
                yield return new InlineUIContainer()
                {
                    Child = GetSpoilerUIElement(fromHtmlNode.InnerText)
                };
            }
        }

        // todo: decouple it from code html node parser class or at least make it configurable
        private UIElement GetSpoilerUIElement(string textValue)
        {
            var resolveSpoilerButton = new Button {Content = "POKAŻ SPOILER"};
            var spoilerText = new TextBlock {Text = textValue};
            spoilerText.Visibility = Visibility.Collapsed;

            var spoilerElementsContainer = new Grid()
            {
                Children = {resolveSpoilerButton, spoilerText}
            };

            resolveSpoilerButton.Click += (sender, args) =>
            {
                spoilerText.Visibility = Visibility.Visible;
                resolveSpoilerButton.Visibility = Visibility.Collapsed;
            };

            return spoilerElementsContainer;
        }
    }
}