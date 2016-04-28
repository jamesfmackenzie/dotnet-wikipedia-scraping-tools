using System;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace WikipediaScrapingTools.Services
{
    public class PageIdService
    {
        public static string GetWikipediaUrlForPageId(string pageId)
        {
            var apiUrl =
                String.Format(
                    "https://en.wikipedia.org/w/api.php?action=query&prop=info&pageids={0}&inprop=url&format=xml",
                    pageId);

            var client = new WebClient();
            client.Encoding = Encoding.UTF8;

            var source = client.DownloadString(apiUrl);

            var resultat = new HtmlDocument();
            resultat.LoadHtml(source);

            var toftitle = resultat.DocumentNode.Descendants().Where
                (x => (x.Name == "pages")).FirstOrDefault();

            var hrefs = toftitle.Descendants("page").ToList();
            foreach (var item in hrefs)
            {
                var fullUrl = item.GetAttributeValue("fullurl", null);

                if (fullUrl != null && fullUrl.Contains("/wiki/"))
                {
                    return fullUrl;
                }
            }

            return "";
        }
    }
}