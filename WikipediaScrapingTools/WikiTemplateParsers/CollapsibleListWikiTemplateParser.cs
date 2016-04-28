using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WikipediaScrapingTools.WikiTemplateParsers
{
    public class CollapsibleListWikiTemplateParser
    {
        /*
        Parser for "Collapsible List" templates:
        https://en.wikipedia.org/wiki/Template:Collapsible_list
          + aliases:
          https://en.wikipedia.org/wiki/Template:List_collapsed
        */

        public static string GetLastElementFromCollapsibleList(string markup)
        {
            var regex = new Regex(@"{{\s*((C|c)ollapsible\slist|(L|l)ist\scollapsed)[\S\s]*?\n*\s*}}");
            var match = regex.Match(markup);

            if (match.Success)
            {
                // this is a Collapsible list template

                var titleRegex = new Regex(@"[\S\s]*?\|\s*title\s*=\s*(?<publisherdeveloper>[^\r\n<]*)");
                var titleRegexMatch = titleRegex.Match(markup);

                if (titleRegexMatch.Success)
                {
                    if (titleRegexMatch.Groups["publisherdeveloper"].Value.Trim() != "")
                        return titleRegexMatch.Groups["publisherdeveloper"].Value;
                }

                var curlyBracesCount = 0;
                var squareBracketsCount = 0;

                var sections = new List<string>();
                var sectionValue = "";

                foreach (var c in markup)
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

                    if ((curlyBracesCount == 2) && (squareBracketsCount == 0) && (c == '|'))
                    {
                        sections.Add(sectionValue);
                        sectionValue = "";
                    }
                    else if (curlyBracesCount >= 2)
                    {
                        sectionValue += c;
                    }
                }

                sections.Add(sectionValue);

                var listItems = sections.Where(s => !IsConfigurationRow(s)).ToList();

                if (listItems.Count >= 2)
                {
                    return listItems[listItems.Count - 1].Trim();
                }
            }

            return "";
        }

        private static bool IsConfigurationRow(string row)
        {
            var regex = new Regex(@"\s*(title|expand|framestyle|titlestyle|title|liststyle|hlist|bullets)\s*\=");
            var match = regex.Match(row);

            if (match.Success)
            {
                return true;
            }

            return false;
        }
    }
}