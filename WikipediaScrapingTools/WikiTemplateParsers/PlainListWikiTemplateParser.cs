using System.Text.RegularExpressions;

namespace WikipediaScrapingTools.WikiTemplateParsers
{
    public class PlainListWikiTemplateParser
    {
        /*
        Parser for "plain list" templates:
        https://en.wikipedia.org/wiki/Template:Plainlist
          + aliases:
          https://en.wikipedia.org/wiki/Template:Bulletless_list
          https://en.wikipedia.org/wiki/Template:PL
          https://en.wikipedia.org/wiki/Template:Plain_list
          https://en.wikipedia.org/wiki/Template:Startplainlist
        */

        public static string GetFirstElementFromPlainList(string markup)
        {
            var regex =
                new Regex(
                    @"{{\s*((P|p)lainlist|(B|b)ulletless\slist|(P|p)(L|l)|(P|p)lain\slist|(S|s)tartplainlist)[\S\s]*?\n*\s*}}");
            var match = regex.Match(markup);

            if (match.Success)
            {
                var firstListItemRegex = new Regex(@"\*\s*(?<publisherdeveloper>[^\r\n<,]*)");
                var firstListItemMatch = firstListItemRegex.Match(markup);

                if (firstListItemMatch.Success)
                {
                    if (firstListItemMatch.Groups["publisherdeveloper"].Value.Trim() != "")
                        return firstListItemMatch.Groups["publisherdeveloper"].Value.Trim();
                }
            }

            return "";
        }
    }
}