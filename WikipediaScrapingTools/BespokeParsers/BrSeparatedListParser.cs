using System;

namespace WikipediaScrapingTools.BespokeParsers
{
    public class BrSeparatedListParser
    {
        public static string GetFirstElementFromBrSeparatedList(string listText)
        {
            if (listText.Contains("<br>"))
            {
                return listText.Split(new[] {"<br>"}, StringSplitOptions.None)[0].Trim();
            }

            if (listText.Contains("<br/>"))
            {
                return listText.Split(new[] {"<br/>"}, StringSplitOptions.None)[0].Trim();
            }

            if (listText.Contains("<br />"))
            {
                return listText.Split(new[] {"<br />"}, StringSplitOptions.None)[0].Trim();
            }

            return "";
        }
    }
}