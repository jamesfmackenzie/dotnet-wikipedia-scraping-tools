using NUnit.Framework;
using WikipediaScrapingTools.WikiTemplateParsers;

namespace WikipediaScrapingTools.Test.WikiTemplateParsers
{
    [TestFixture]
    internal class UnbulletedListWikiTemplateParserTest
    {
        [Test]
        public void GetUnbulletedListDisplayText_noUnbulletedList_returnsEmptyString()
        {
            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList("hello");

            Assert.AreEqual("", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_unbulletedListWithNoItems_returnsEmptyString()
        {
            const string markup = @"{{Unbulleted list}}";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markup);

            Assert.AreEqual("", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_unbulletedListWithConfigurationItemsOnly_returnsEmptyString()
        {
            // arrange
            const string markupToTest = @"{{Unbulleted list
|class     = class
|style     = style
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_unbulletedListWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{Unbulleted list
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_unbulletedLowercaseListWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{unbulleted list
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_ublWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{Ubl
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_lowerCaseUblWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{ubl
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_ubListWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{Ublist
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_lowerCaseUbListWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{ublist
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_UbtWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{Ubt
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_lowerCaseUbtWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{ubt
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_unbulletedWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{Unbullet
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_lowerCaseUnbulletedWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{unbullet
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_vunblistWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{Vunblist
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }

        [Test]
        public void GetUnbulletedListDisplayText_lowerCaseVunblistWithItems_returnsLastListItem()
        {
            // arrange
            const string markupToTest = @"{{vunblist
| [[GT Interactive Software]]
| [[MacSoft Games]] {{small|(Mac OS)}}
| [[Sega]] {{small|(SS)}}
| [[Piko Interactive]] {{small|(SG)}}
| [[Virgin Interactive]] {{small|(PS)}}
| [[3D Realms]] {{small|(X360)}}
| [[MachineWorks Northwest]] {{small|(iOS, Android)}}
| [[Devolver Digital]] {{small|(''Megaton Edition'')}}
}}
";

            var result = UnbulletedListWikiTemplateParser.GetLastElementFromUnbulletedList(markupToTest);

            Assert.AreEqual("[[Devolver Digital]] {{small|(''Megaton Edition'')}}", result);
        }
    }
}