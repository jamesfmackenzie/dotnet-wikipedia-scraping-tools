namespace WikipediaScrapingTools.BespokeParsers
{
    public class CommaSeparatedListParser
    {
        public static string GetFirstElementFromCommaSeparatedList(string listText)
        {
            if (listText.Contains(","))
            {
                return listText.Split(',')[0];
            }

            return "";
        }
    }
}