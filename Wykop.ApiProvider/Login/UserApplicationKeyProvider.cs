using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Wykop.ApiProvider.Common;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.Data;

namespace Wykop.ApiProvider.Login
{
    internal class UserApplicationKeyProvider
    {
        // TODO: refactor this shit
        private readonly IApiDataContainer _dataContainer;
        private readonly HttpClient _httpClient;

        public UserApplicationKeyProvider(IApiDataContainer dataContainer)
        {
            _dataContainer = dataContainer;
            _httpClient = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.GZip
            });
        }

        public async Task<bool> ConnectToApplication(LoginData loginData)
        {
            if (await HasAlreadySavedUserApplicationKey())
                return true;

            var applicationConnectUrl = "https://a.wykop.pl/user/connect/appkey," + WykopApiConfiguration.ApiKey;
            var requestBodyContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("login[login]", loginData.Username),
                new KeyValuePair<string, string>("login[password]", loginData.Password)
            });

            var postResponse = await _httpClient.PostAsync(applicationConnectUrl, requestBodyContent);
            var responseContent = await postResponse.Content.ReadAsStringAsync();

            if (responseContent.Contains("Niepoprawne dane logowania"))
                return false;

            return responseContent == "[true]";
        }

        public async Task<string> GetConnectedAccountKey()
        {
            if (await HasAlreadySavedUserApplicationKey())
                return await _dataContainer.Retrieve(DataConstants.ApplicationUserKey);

            var applicationSessionsUrl = "http://www.wykop.pl/ustawienia/sesje/";
            var htmlDocumentStream = await _httpClient.GetStreamAsync(applicationSessionsUrl);
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(htmlDocumentStream);

            // ugly html parsing to get application key..
            var trNodeWithApplicationKeyChildren = GetTrNodeWithApplicationKeyChildren(htmlDocument);

            var applicationKey =
                trNodeWithApplicationKeyChildren
                    .Descendants()
                    .Single(x => x.NodeType == HtmlNodeType.Element && x.Name == "input")
                    .Attributes["value"]
                    .Value;

            await _dataContainer.Save(DataConstants.ApplicationUserKey, applicationKey);
            return applicationKey;
        }

        private async Task<bool> HasAlreadySavedUserApplicationKey()
        {
            string applicationUserKey = await _dataContainer.Retrieve(DataConstants.ApplicationUserKey);
            return !string.IsNullOrEmpty(applicationUserKey);
        }

        private HtmlNode GetTrNodeWithApplicationKeyChildren(HtmlDocument htmlDocument)
        {
            var htmlNodes =
                htmlDocument.DocumentNode
                    .Descendants()
                    .Where(
                        x => x.NodeType == HtmlNodeType.Element && x.Name == "div" && x.Attributes.Contains("class") &&
                             x.Attributes["class"].Value == "space")
                    .SelectMany(x => x.Descendants())
                    .Where(
                        x => x.NodeType == HtmlNodeType.Element && x.Name == "tr" && x.Attributes.Contains("class") &&
                             x.Attributes["class"].Value == "lcontrast")
                    .Where(x => x.HasChildNodes && x.ChildNodes.Any(childNode => childNode.Name == "td") &&
                                x.ChildNodes.First(childNode => childNode.Name == "td")
                                    .InnerText.Contains(WykopApiConfiguration.ApplicationName))
                    .ToList();

            if (htmlNodes.Count != 1)
                throw new InvalidOperationException(
                    "Can't parse /ustawienia/sesje/. Contact with author library (no single node)");

            return htmlNodes.Single();
        }
    }
}