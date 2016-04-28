using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace WikipediaScrapingTools.PageScrapers
{
    public class LinkScraper
    {
        public static List<Link> GetLinksForWikipediaUrl(string url)
        {
            var urlList = new List<Link>();

            var client = new WebClient();
            client.Encoding = Encoding.UTF8;

            var source = client.DownloadString(url);

            var resultat = new HtmlDocument();
            resultat.LoadHtml(source);

            var toftitle = resultat.DocumentNode.Descendants().Where
                (x => (x.Name == "div" && x.Attributes["id"] != null &&
                       x.Attributes["id"].Value.Contains("mw-content-text"))).FirstOrDefault();

            var hrefs = toftitle.Descendants("a").ToList();
            foreach (var item in hrefs)
            {
                var href = item.GetAttributeValue("href", null);
                var title = item.GetAttributeValue("title", null);

                if (href != null && title != null && href.Contains("/wiki/"))
                {
                    urlList.Add(new Link {Title = title, Url = url});
                }
            }

            return urlList;
        }

        public class Link
        {
            public string Title { get; set; }
            public string Url { get; set; }
        }
    }
}
