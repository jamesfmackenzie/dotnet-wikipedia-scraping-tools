using NUnit.Framework;
using WikipediaScrapingTools.BespokeParsers;

namespace WikipediaScrapingTools.Test.BespokeParsers
{
    [TestFixture]
    class BrSeparatedListParserTest
    {
        [Test]
        public void GetBrSeparatedListDisplayText_validBrSeparatedList_returnsExpectedValue()
        {
            string result = BrSeparatedListParser.GetFirstElementFromBrSeparatedList(
                "Bally Midway <br> [[Atari]] '''(Atari 2600, 7800 and Atatri ST)''' <br> SunSoft '''(NES)''' <br> Others");

            Assert.AreEqual("Bally Midway", result);
        }
    }
}
