using System;

namespace WikipediaScrapingTools.BespokeParsers
{
    class LineFeedSeparatedListParser
    {
        public static string GetFirstElementFromLineFeedSeparatedList(string listText)
        {
            if (listText.Contains("\n"))
            {
                return listText.Split(new[] { "\n" }, StringSplitOptions.None)[0].Trim();
            }

            return "";
        }
    }
}
