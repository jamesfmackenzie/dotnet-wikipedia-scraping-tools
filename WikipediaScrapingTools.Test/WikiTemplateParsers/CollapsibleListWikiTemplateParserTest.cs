using NUnit.Framework;
using WikipediaScrapingTools.WikiTemplateParsers;

namespace WikipediaScrapingTools.Test.WikiTemplateParsers
{
    [TestFixture]
    internal class CollapsibleListWikiTemplateParserTest
    {
        [Test]
        public void GetCollapsibleListDisplayText_missingList_returnsEmptyString()
        {
            var result = CollapsibleListWikiTemplateParser.GetLastElementFromCollapsibleList("hello");

            Assert.AreEqual("", result);
        }

        [Test]
        public void GetCollapsibleListDisplayText_noItems_returnsEmptyString()
        {
            var result = CollapsibleListWikiTemplateParser.GetLastElementFromCollapsibleList("{{Collapsible list}}");

            Assert.AreEqual("", result);
        }

        [Test]
        public void GetCollapsibleListDisplayText_configurationItemsOnly_returnsEmptyString()
        {
            // arrange
            string markupToTest = @"{{Collapsible list
  |titlestyle = font-weight:normal;font-size:12px;background:transparent;text-align:left
  }}";

            var result = CollapsibleListWikiTemplateParser.GetLastElementFromCollapsibleList(markupToTest);

            Assert.AreEqual("", result);
        }

        [Test]
        public void GetCollapsibleListDisplayText_validPublisherAsCollapsibleListWithTitleAsWikiLink_extractsPublisherAsExpected()
        {
            // arrange
            string markupToTest = @"{{Collapsible list
| titlestyle = font-weight:normal;background:transparent;text-align:left;
| {{Video game release|EU=[[Infogrames]]}}
| {{Video game release|EU=[[Mirrorsoft]] {{small|(Home Computers)}}}}
| {{Video game release|[[Europe|EU]]/[[North America|NA]]|[[Nintendo]] {{small|(NES)}}}}
| {{Video game release|[[Europe|EU]]/[[North America|NA]]|[[Philips]]}}
| {{Video game release|NA|AcademySoft {{small|(MS-DOS)}}}}
| {{Video game release|NA|[[Spectrum HoloByte]]}}
| {{Video game release|NA|[[Tandy Computers|Tandy]]}}
| {{Video game release|JP|[[Bullet Proof Software]] {{small|(Home computers)}}}}
| {{Video game release|JP|[[Sega]] {{small|(AC/MD)}}}}
| {{Video game release|JP|[[W!Games]]}}
| {{Video game release|Korea|KR|DR Korea {{small|(AC)}}}}
}}";

            // act
            string extractedPublisher = CollapsibleListWikiTemplateParser.GetLastElementFromCollapsibleList(markupToTest);

            // assert
            Assert.AreEqual("{{Video game release|Korea|KR|DR Korea {{small|(AC)}}}}", extractedPublisher);
        }

        [Test]
        public void GetCollapsibleListDisplayText_validPublisherAsCollapsibleListWithTitleAsPlainText_extractsPublisherAsExpected()
        {
            // arrange
            string markupToTest = @"{{Collapsible list
  |title = Lucasfilm Games
  |titlestyle = font-weight:normal;font-size:12px;background:transparent;text-align:left
  |'''Personal computers'''<br>Lucasfilm Games
  |'''TurboGrafx-CD'''<br>Lucasfilm Games<br>[[NEC]]
  }}";

            // act
            string extractedPublisher = CollapsibleListWikiTemplateParser.GetLastElementFromCollapsibleList(markupToTest);

            // assert
            Assert.AreEqual("Lucasfilm Games", extractedPublisher);
        }

        [Test]
        public void GetCollapsibleListDisplayText_validPublisherAsCollapsibleListWithoutTitle_extractsLastListItemAsResult()
        {
            // arrange
            string markupToTest = @"{{Collapsible list
| titlestyle = font-weight:normal;background:transparent;text-align:left;
| {{Video game release|EU= [[Infogrames]]}}
| {{Video game release|EU=[[Mirrorsoft]] {{small|(Home Computers)}}}}
| {{Video game release|[[Europe|EU]]/[[North America|NA]]|[[Nintendo]] {{small|(NES)}}}}
| expand = foo
}}";

            // act
            string extractedPublisher = CollapsibleListWikiTemplateParser.GetLastElementFromCollapsibleList(markupToTest);

            // assert
            Assert.AreEqual("{{Video game release|[[Europe|EU]]/[[North America|NA]]|[[Nintendo]] {{small|(NES)}}}}", extractedPublisher);
        }
    }
}