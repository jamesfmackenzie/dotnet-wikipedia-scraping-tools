using NUnit.Framework;
using WikipediaScrapingTools.WikiTextParsers;

namespace WikipediaScrapingTools.Test.WikiTextParsers
{
    [TestFixture]
    internal class InternalWikiLinkParserTest
    {
        [Test]
        public void ExtractDisplayTextFromWikiLink_noWikiLink_returnEmptyString()
        {
            var result = InternalWikiLinkParser.ExtractDisplayTextFromLink("hello");

            Assert.AreEqual("", result);
        }

        [Test]
        public void ExtractDisplayTextFromWikiLink_notAWikiLink_returnEmptyString()
        {
            var result = InternalWikiLinkParser.ExtractDisplayTextFromLink("Bally Midway <br> [[Atari]] '''(Atari 2600, 7800 and Atatri ST)''' <br> SunSoft '''(NES)''' <br> Others");

            Assert.AreEqual("", result);
        }

        [Test]
        public void ExtractDisplayTextFromWikiLink_wikiLinkWithNoDislayValue_returnsExpectedResult()
        {
            const string wikiLink = "[[foo]]";

            var result = InternalWikiLinkParser.ExtractDisplayTextFromLink(wikiLink);

            Assert.AreEqual("foo", result);
        }

        [Test]
        public void ExtractDisplayTextFromWikiLink_wikiLinkWithDislayValue_returnsExpectedResult()
        {
            const string wikiLink = "[[foo|bar]]";

            var result = InternalWikiLinkParser.ExtractDisplayTextFromLink(wikiLink);

            Assert.AreEqual("bar", result);
        }

        [Test]
        public void ExtractDisplayTextFromWikiLink_wikiLinkWithTextImmediateAfter_returnsExpectedResult()
        {
            const string wikiLink =
                @"[[3D Realms|Apogee Software]]{{efn|The game was published by [[Manaccom]] in Austrlia, the 3DO version was published by [[Interplay Entertainment]], the Atari Jaguar version was published by [[Atari Corporation]], the Game Boy Advance version was published by [[BAM! Entertainment]], the Macistosh version was published by [[MacPlay]], the game was also published by [[GT Interactive]] in 1993, Zodttd on iOS and by [[Activision]] on Xbox Live Arcade and PlayStation Network.}}";

            var result = InternalWikiLinkParser.ExtractDisplayTextFromLink(wikiLink);

            Assert.AreEqual("Apogee Software", result);
        }
    }
}