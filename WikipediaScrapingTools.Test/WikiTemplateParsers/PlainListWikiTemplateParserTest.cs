using NUnit.Framework;
using WikipediaScrapingTools.WikiTemplateParsers;

namespace WikipediaScrapingTools.Test.WikiTemplateParsers
{
    [TestFixture]
    class PlainListWikiTemplateParserTest
    {
        [Test]
        public void ExtractNameFromWikiText_plainListWithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{Plainlist|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_plainListLowerCaseWithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{plainlist|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_plainListRedirect1WithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{Bulletless list|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_plainListRedirect1LowerCaseWithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{bulletless list|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_plainListRedirect2WithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{PL|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_plainListRedirect2PartialLowerCaseWithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{Pl|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_plainListRedirect2LowerCaseWithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{pl|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_plainListRedirect3WithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{Plain list|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_plainListRedirect3LowerCaseWithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{plain list|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_plainListRedirect4WithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{Startplainlist|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_plainListRedirect4LowerCaseWithItems_returnsFirstItem()
        {
            // arrange
            const string markupToTest = @"{{startplainlist|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[Atari]] ([[Atari Lynx]])", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_noPlainList_returnsEmptyString()
        {
            // arrange

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList("hello");

            // assert
            Assert.AreEqual("", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_noEntriesInPlainList_returnsEmptyString()
        {
            // arrange
            const string markupToTest = @"{{Plainlist|
}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("", extractedPublisher);
        }

        [Test]
        public void ExtractNameFromWikiText_alternativePlainListSyntax_returnsFirstListItem()
        {
            // arrange
            const string markupToTest = @"{{plainlist}}
* [[cat]]
* [[dog]]
* [[horse]]
* [[cow]]
* [[sheep]]
* [[pig]]
{{endplainlist}}";

            // act
            var extractedPublisher = PlainListWikiTemplateParser.GetFirstElementFromPlainList(markupToTest);

            // assert
            Assert.AreEqual("[[cat]]", extractedPublisher);
        }
    }
}
