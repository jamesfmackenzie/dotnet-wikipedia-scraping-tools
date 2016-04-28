using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WikipediaScrapingTools.WikiTemplateParsers
{
    public class UnbulletedListWikiTemplateParser
    {
        /*
        Parser for "Video game release" and "Video game release new" templates:
        https://en.wikipedia.org/wiki/Template:Unbulleted_list
          + aliases:
          https://en.wikipedia.org/wiki/Template:Ubl
          https://en.wikipedia.org/wiki/Template:Ublist
          https://en.wikipedia.org/wiki/Template:Ubt
          https://en.wikipedia.org/wiki/Template:Unbullet
          https://en.wikipedia.org/wiki/Template:Vunblist
        */

        public static string GetLastElementFromUnbulletedList(string markup)
        {
            var regex = new Regex(@"{{\s*((U|u)nbulleted list|(U|u)bl|(U|u)blist|(U|u)bt|(U|u)nbullet|(V|v)unblist)[\S\s]*?\n*\s*}}");
            var match = regex.Match(markup);

            if (match.Success)
            {
                // this is an Unbulleted list template

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
            var regex = new Regex(@"\s*(class|style|list_style|item_style|item\d*_style)\s*\=");
            var match = regex.Match(row);

            if (match.Success)
            {
                return true;
            }

            return false;
        }
    }
}
