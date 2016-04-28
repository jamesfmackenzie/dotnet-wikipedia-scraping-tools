using NUnit.Framework;
using WikipediaScrapingTools.WikiTextParsers;

namespace WikipediaScrapingTools.Test.WikiTextParsers
{
    [TestFixture]
    internal class ExternalWikiLinkParserTest
    {
        [Test]
        public void ExtractDisplayTextFromLink_noLink_returnsEmptyString()
        {
            string result = ExternalWikiLinkParser.ExtractDisplayTextFromLink("hello");

            Assert.AreEqual("", result);
        }

        [Test]
        public void ExtractDisplayTextFromLink_notAWikiLink_returnEmptyString()
        {
            var result = ExternalWikiLinkParser.ExtractDisplayTextFromLink("Bally Midway <br> [[Atari]] '''(Atari 2600");

            Assert.AreEqual("", result);
        }

        [Test]
        public void ExtractDisplayTextFromLink_noDisplayText_returnsExpectedResult()
        {
            string result = ExternalWikiLinkParser.ExtractDisplayTextFromLink("[http://www.google.com]");

            Assert.AreEqual("http://www.google.com", result);
        }

        [Test]
        public void ExtractDisplayTextFromLink_linkHasDisplayText_returnsExpectedResult()
        {
            string result = ExternalWikiLinkParser.ExtractDisplayTextFromLink("[http://wl.widelands.org/wiki/DevelopersPage/ The Widelands Development Team]");

            Assert.AreEqual("The Widelands Development Team", result);
        }

        [Test]
        public void ExtractDisplayTextFromLink_linkHasDisplayTextWithSpaces_returnsExpectedResult()
        {
            string result = ExternalWikiLinkParser.ExtractDisplayTextFromLink("[http://www.google.com Google Company Co]");

            Assert.AreEqual("Google Company Co", result);
        }
    }
}