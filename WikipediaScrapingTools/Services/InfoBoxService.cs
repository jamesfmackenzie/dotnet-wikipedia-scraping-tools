using System;
using System.Net;
using System.Text;

namespace WikipediaScrapingTools.Services
{
    public class InfoBoxService
    {
        public static string GetInfoBoxTextForWikipediaUrl(string url)
        {
            var relativeUrl = url.Replace("https://en.wikipedia.org/wiki/", "");

            var apiUrl =
                String.Format(
                    "https://en.wikipedia.org/w/api.php?action=query&prop=revisions&rvprop=content&format=xml&titles={0}&rvsection=0",
                    relativeUrl);

            var client = new WebClient();
            client.Encoding = Encoding.UTF8;

            var source = client.DownloadString(apiUrl);

            if (source.IndexOf("#REDIRECT", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var redirectTarget = source.Substring(source.IndexOf("[[") + 2,
                    source.IndexOf("]]") - source.IndexOf("[[") - 2);
                var newApiUrl =
                    String.Format(
                        "https://en.wikipedia.org/w/api.php?action=query&prop=revisions&rvprop=content&format=xml&titles={0}&rvsection=0",
                        redirectTarget);
                source = client.DownloadString(newApiUrl);
            }

            return WebUtility.HtmlDecode(WebUtility.HtmlDecode(source));
        }
    }
}
