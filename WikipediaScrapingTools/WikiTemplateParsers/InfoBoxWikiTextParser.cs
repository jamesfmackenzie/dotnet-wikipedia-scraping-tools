using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace WikipediaScrapingTools.WikiTemplateParsers
{
    public class InfoBoxWikiTextParser
    {
        public static string GetTitleForInfoBox(string markup)
        {
            HtmlDocument remoteDocument = new HtmlDocument();
            remoteDocument.LoadHtml(markup);

            HtmlNode pagesNode = remoteDocument.DocumentNode.Descendants().FirstOrDefault(x => (x.Name == "pages"));

            if (pagesNode != null)
            {
                var hrefs = pagesNode.Descendants("page").ToList();

                if (hrefs != null)
                {
                    foreach (var item in hrefs)
                    {
                        return item.GetAttributeValue("title", null);
                    }
                }
            }

            return "";
        }

        public static string GetNamedElementFromInfoBox(string markup, string key)
        {
            var regex = new Regex(@"\n\s*\|\s*" + key + @"\s*=");
            var match = regex.Match(markup);

            if (match.Success)
            {
                var markupToCrawl =
                    markup.Substring(match.Index, markup.Length - match.Index).Replace(match.Value, "").Trim();

                var curlyBracesCount = 0;
                var squareBracketsCount = 0;

                var returnValue = "";

                foreach (var c in markupToCrawl)
                {
                    if (c == '{')
                    {
                        curlyBracesCount++;
                    }

                    if (c == '}')
                    {
                        curlyBracesCount--;
                    }

                    if (c == '[')
                    {
                        squareBracketsCount++;
                    }

                    if (c == ']')
                    {
                        squareBracketsCount--;
                    } 

                    if ((curlyBracesCount == 0) && (squareBracketsCount == 0) && (c == '|'))
                    {
                        break;
                    }

                    returnValue += c;
                }

                return returnValue.Trim();
            }

            return "";
        }
    }
}