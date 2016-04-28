using System;
using System.Collections.Generic;
using WikipediaScrapingTools.Services;
using WikipediaScrapingTools.WikiTemplateParsers;
using WikipediaScrapingTools.WikiTextParsers;

namespace TestHarness
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string pageId = "100062";
            Console.WriteLine("Fetching url for pageId " + pageId + "...");
            string url = PageIdService.GetWikipediaUrlForPageId(pageId);
            Console.WriteLine("Url is: " + url);

            Console.WriteLine();

            const string testWikipediaUrl = "https://en.wikipedia.org/wiki/Namco_Museum_Volume_1";
            Console.WriteLine("Fetching redirect url for " + testWikipediaUrl + "...");
            string destinationUrl = UrlRedirectService.GetRedirectUrlForWikipediaUrl(testWikipediaUrl);
            Console.WriteLine("Destination url is: " + destinationUrl);

            Console.WriteLine();

            Console.WriteLine("Fetching image urls for " + url + "...");
            List<string> imageUrls = ImageService.GetImageUrlsForWikipediaUrl(url);
            Console.WriteLine("Images found:");
            imageUrls.ForEach(u => Console.WriteLine("  " + u));

            Console.WriteLine();

            Console.WriteLine("Fetching InfoBox test for " + url + "...");
            string infoBoxText = InfoBoxService.GetInfoBoxTextForWikipediaUrl(url);
            Console.WriteLine("InfoBox text: " + infoBoxText);

            Console.WriteLine();

            Console.WriteLine("Getting title for InfoBox text... ");
            Console.WriteLine("Title is " + InfoBoxWikiTextParser.GetTitleForInfoBox(infoBoxText));

            Console.WriteLine();

            Console.WriteLine("Getting genre from InfoBox text... ");
            string genre = InfoBoxWikiTextParser.GetNamedElementFromInfoBox(infoBoxText, "genre");
            Console.WriteLine("Genre is " + genre);

            Console.WriteLine();

            Console.WriteLine("Getting display text for genre...");
            Console.WriteLine(genre + " => " + InternalWikiLinkParser.ExtractDisplayTextFromLink(genre));
        }
    }
}