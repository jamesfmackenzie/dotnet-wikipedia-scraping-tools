using System.Text.RegularExpressions;

namespace WikipediaScrapingTools.WikiTextParsers
{
    public class ExternalWikiLinkParser
    {
        /* 
        Parse external WikiLinks
        https://en.wikipedia.org/wiki/Wikipedia:External_links
        */

        public static string ExtractDisplayTextFromLink(string markup)
        {
            if (markup == null)
            {
                return "";
            }

            if ((markup.Trim().Length > 0) && (markup[0] != '['))
            {
                return "";
            }

            var toReturn = "";
            var squareBracketsCount = 0;
            bool hasReturnValueBeenPurged = false;

            foreach (var c in markup.Trim())
            {
                if (c == '[')
                {
                    squareBracketsCount++;
                }

                if (c == ']')
                {
                    squareBracketsCount--;
                }

                if ((squareBracketsCount == 1) && (c == ' ') && !hasReturnValueBeenPurged)
                {
                    toReturn = "";
                    hasReturnValueBeenPurged = true;
                }
                else if (squareBracketsCount == 1)
                {
                    toReturn += c;
                }
            }

            return toReturn.Replace("[", "").Trim();
        }

        public static string ExtractExternalWikiLinkFromWikiMarkup(string markup)
        {
            Regex regex = new Regex(@"^\[[^\[\]]*?\]");
            Match match = regex.Match(markup);

            if (match.Success)
            {
                return match.Value.Trim();
            }

            return "";
        }
    }
}