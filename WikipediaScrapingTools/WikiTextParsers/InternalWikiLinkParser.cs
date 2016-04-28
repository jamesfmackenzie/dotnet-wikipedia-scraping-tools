using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WikipediaScrapingTools.WikiTextParsers
{
    public class InternalWikiLinkParser
    {
        /* 
        Parse internal WikiLinks
        https://en.wikipedia.org/wiki/Help:Link
        */

        public static string ExtractDisplayTextFromLink(string markup)
        {
            var sectionValue = "";

            var squareBracketsCount = 0;
            var sections = new List<string>();

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

                if ((squareBracketsCount == 2) && (c == '|'))
                {
                    sections.Add(sectionValue);
                    sectionValue = "";
                }
                else if (squareBracketsCount == 2)
                {
                    sectionValue += c;
                }

                if (squareBracketsCount == 0)
                {
                    break;
                }
            }

            sections.Add(sectionValue);

            if (sections.Count >= 1)
            {
                return sections[sections.Count - 1].Replace("[", "").Trim();
            }

            return "";
        }

        public static string ExtractInternalWikiLinkFromWikiMarkup(string markup)
        {
            Regex regex = new Regex(@"\[\[[\S\s]*?\]\]");
            Match match = regex.Match(markup);

            if (match.Success)
            {
                return match.Value.Trim();
            }

            return "";
        }
    }
}