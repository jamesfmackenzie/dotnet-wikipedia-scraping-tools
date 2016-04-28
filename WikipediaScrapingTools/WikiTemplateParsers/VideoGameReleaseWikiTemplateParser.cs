using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WikipediaScrapingTools.WikiTemplateParsers
{
    public class VideoGameReleaseWikiTemplateParser
    {
        /*
        Parser for "Video game release" and "Video game release new" templates:
        https://en.wikipedia.org/wiki/Template:Video_game_release
          + aliases:
          https://en.wikipedia.org/wiki/Template:Vgrelease
          https://en.wikipedia.org/wiki/Template:Vg_release

        https://en.wikipedia.org/wiki/Template:Video_game_release_new
          + aliases:
          https://en.wikipedia.org/wiki/Template:Vgrelease_new
        */
        public static string GetVideoGameReleaseDisplayText(string markup)
        {
            Regex regex = new Regex(@"{{\s*((V|v)ideo\sgame\srelease|(V|v)grelease|(V|v)g\srelease)[\S\s]*}}");
            Match match = regex.Match(markup);

            if (match.Success)
            {
                // this is a Video game release template
                int curlyBracesCount = 0;
                int squareBracketsCount = 0;

                List<string> sections = new List<string>();
                string sectionValue = "";

                foreach (char c in match.Value)
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

                if (sections.Count >= 2)
                {
                    string sectionToReturn = sections[sections.Count - 1];
                    return sectionToReturn.Contains("=") ? sectionToReturn.Split('=')[1].Trim() : sectionToReturn.Trim();
                }
            }

            return "";
        }
    }
}
