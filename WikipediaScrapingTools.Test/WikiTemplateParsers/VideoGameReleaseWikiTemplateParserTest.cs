using NUnit.Framework;
using WikipediaScrapingTools.WikiTemplateParsers;

namespace WikipediaScrapingTools.Test.WikiTemplateParsers
{
    [TestFixture]
    internal class VideoGameReleaseWikiTemplateParserTest
    {
        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseStandardSyntaxStandardCase_extractsExpectedValue()
        {
            // arrange
            const string markupToTest =
                @"{{Video game release|NA=[[Accolade (game company)|Accolade]]|EU=[[U.S. Gold]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[U.S. Gold]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseStandardSyntaxLowerCase_extractsExpectedValue()
        {
            // arrange
            const string markupToTest =
                @"{{video game release|NA=[[Accolade (game company)|Accolade]]|EU=[[U.S. Gold]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[U.S. Gold]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseStandardSyntaxStandardCaseRedirect1_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{Vgrelease|NA=[[Accolade (game company)|Accolade]]|EU=[[U.S. Gold]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[U.S. Gold]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseStandardSyntaxLowerCaseRedirect1_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{vgrelease|NA=[[Accolade (game company)|Accolade]]|EU=[[U.S. Gold]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[U.S. Gold]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseStandardSyntaxStandardCaseRedirect2_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{Vg release|NA=[[Accolade (game company)|Accolade]]|EU=[[U.S. Gold]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[U.S. Gold]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseStandardSyntaxLowerCaseRedirect2_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{vg release|NA=[[Accolade (game company)|Accolade]]|EU=[[U.S. Gold]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[U.S. Gold]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseTwoParamSyntaxStandardCase_extractsExpectedValue()
        {
            // arrange
            const string markupToTest = @"{{Video game release|[[Japan|JPN]]|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseTwoParamSyntaxLowerCase_extractsExpectedValue()
        {
            // arrange
            const string markupToTest = @"{{video game release|[[Japan|JPN]]|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseTwoParamSyntaxStandardCaseRedirect1_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{Vgrelease|[[Japan|JPN]]|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseTwoParamSyntaxLowerCaseRedirect1_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{vgrelease|[[Japan|JPN]]|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseTwoParamSyntaxStandardCaseRedirect2_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{Vg release|[[Japan|JPN]]|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseTwoParamSyntaxLowerCaseRedirect2_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{vg release|[[Japan|JPN]]|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseThreeParamSyntaxStandardCase_extractsExpectedValue()
        {
            // arrange
            const string markupToTest = @"{{Video game release|Japan|JPN|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseThreeParamSyntaxLowerCase_extractsExpectedValue()
        {
            // arrange
            const string markupToTest = @"{{video game release|Japan|JPN| [[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseThreeParamSyntaxStandardCaseRedirect1_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{Vgrelease|Japan|JPN|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseThreeParamSyntaxLowerCaseRedirect1_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{vgrelease|Japan|JPN|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseThreeParamSyntaxStandardCaseRedirect2_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{Vg release|Japan|JPN|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseThreeParamSyntaxLowerCaseRedirect2_extractsExpectedValue
            ()
        {
            // arrange
            const string markupToTest = @"{{vg release|Japan|JPN|[[Accolade (game company)|Accolade]]}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("[[Accolade (game company)|Accolade]]", extractedPublisher);
        }

        [Test]
        public void ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseNewStandardCase_extractsExpectedValue()
        {
            // arrange
            const string markupToTest = @"{{Video game release new|JPN|foo|NA|bar }}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("bar", extractedPublisher);
        }

        [Test]
        public void ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseNewLowerCase_extractsExpectedValue()
        {
            // arrange
            const string markupToTest = @"{{video game release new|JPN|foo|NA|bar}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("bar", extractedPublisher);
        }

        [Test]
        public void
            ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseNewStandardCaseRedirect1_extractsExpectedValue()
        {
            // arrange
            const string markupToTest = @"{{Vgrelease new|JPN|foo|NA|bar}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("bar", extractedPublisher);
        }

        [Test]
        public void ExtractVideoGameReleaseDisplayText_ValidVideoGameReleaseNewLowerCaseRedirect1_extractsExpectedValue()
        {
            // arrange
            const string markupToTest = @"{{vgrelease new|JPN|foo|NA|bar}}";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("bar", extractedPublisher);
        }

        [Test]
        public void ExtractVideoGameReleaseDisplayText_noVideoGameReleaseTemplate_returnsEmptyString()
        {
            // arrange
            const string markupToTest = @"Acclaim";

            // act
            var extractedPublisher = VideoGameReleaseWikiTemplateParser.GetVideoGameReleaseDisplayText(markupToTest);

            // assert
            Assert.AreEqual("", extractedPublisher);
        }
    }
}