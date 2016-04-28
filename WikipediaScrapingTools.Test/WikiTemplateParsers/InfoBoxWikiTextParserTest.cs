using NUnit.Framework;
using WikipediaScrapingTools.WikiTemplateParsers;

namespace WikipediaScrapingTools.Test.WikiTemplateParsers
{
    [TestFixture]
    class InfoBoxWikiTextParserTest
    {
        private string sampleWikiText = @"<?xml version=""1.0"" ?><api batchcomplete="""" ><query><normalized><n from=""Steel_Empire"" to=""Steel Empire"" /></normalized><pages><page _idx=""1471723"" pageid=""1471723"" ns=""0"" title=""Steel Empire"" ><revisions><rev contentformat=""text/x-wiki"" contentmodel=""wikitext"" xml:space=""preserve"" >{{For|the strategy/action game by Silicon Knights|Cyber Empires}}
{{unreliable sources|date=January 2016}}
{{Infobox video game
| image        = 
| caption      = ''Steel Empire'' Genesis box art
| developer    = [[HOT・B]]<br />Mebius(3DS)
| publisher    = 
; Mega Drive: {{vgrelease|JP=[[HOT・B]]|NA=[[Flying Edge]]|EU=[[Flying Edge]] <small>(as ''Empire of Steel'')</small>}} 
; Game Boy Advance: {{vgrelease|JP=[[Starfish(company)|Starfish]]|EU=[[Zushi Games|Zoo Digital Publishing]]}}
; Nintendo 3DS: {{vgrelease|JP=Starfish SD|NA=[[Teyon]]}}
| distributor = {{Collapsible list
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
}} 
| designer     = {{plainlist|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}
| composer     = [[Noriyuki Iwadare]]<br />Yoshiaki Kubotera<br />Isao Mizoguchi
| engine       = Proprietary
| released = {{vgrelease|JP=March 13, 1992|NA=1992|PAL=1992}}
| genre        = [[Shoot 'em up|Horizontal scrolling shooter]]
| modes        = [[Single-player video game|Single-player]]
| platforms    = [[Sega Genesis|Sega Genesis/Mega Drive]], [[Game Boy Advance]], [[Nintendo 3DS]]
}}

'''''Steel Empire''''' (originally released as {{nihongo|'''Koutetsu Teikoku'''|鋼鉄帝国}} in Japan, and otherwise known in various English materials as '''The Steel Empire''' or '''Empire of Steel''') is a[[side - scrolling]] [[shoot 'em up]] [[video game]] released on the [[Sega]] [[Sega Genesis|Genesis / Mega Drive]] [[home console]]s in [[1992 in video gaming|1992]], and was later [[porting|ported]] to the [[Nintendo]] [[Game Boy Advance]] in [[2004 in video gaming|2004]] and to the [[Nintendo 3DS]] in [[2014 in video gaming|2014]].
''Steel Empire'' is notable amongst shoot 'em up games for its unique aesthetic designs. Mostly low-tech in nature, with its being set in the late-19th century of an alternate world, the game's aircraft, weaponry, powerups, environments, enemies and bosses are heavily stylized adding strong [[steampunk]] elements to the style, themes and visuals of the game. [[Steam power]], [[propeller|propeller-based]] aircraft, [[biplane]]s, [[dirigible]]s and heavily armored[[steam train]]s with giant[[cannon]]s play large roles in the game's protagonists and opponents.
The original leaked Japanese[[arcade game|arcade beta version]] (now rare and the source code of which is believed lost), the popular Mega Drive version and the GBA[[Video game remake|remake]] were all critically well received.As of 2012, a modern, ""gritty""[[sequel]], ''Burning Steel'', is planned by original[[HOT・B]] lead game designer Yoshinori Satake for a[[History of video game consoles(seventh generation) | 7th generation]] and possibly an[[History of video game consoles(eighth generation) | 8th generation console]].<ref name=""shmups.system11.org"" >{{cite web|url=http://shmups.system11.org/viewtopic.php?t=41905|title=shmups.system11.org|publisher=Shmups.system11.org|accessdate=11 December 2014}}</ref></rev></revisions></page></pages></query></api>";

        [Test]
        public void ExtractValueForInfoBoxKey_singleLineWithNoTemplate_extractsExpectedValue()
        {
            string extractedValue = InfoBoxWikiTextParser.GetNamedElementFromInfoBox(sampleWikiText, "caption");

            Assert.AreEqual("''Steel Empire'' Genesis box art", extractedValue);
        }

        [Test]
        public void ExtractValueForInfoBoxKey_singleLineWithTemplate_extractsExpectedValue()
        {
            string extractedValue = InfoBoxWikiTextParser.GetNamedElementFromInfoBox(sampleWikiText, "released");

            Assert.AreEqual("{{vgrelease|JP=March 13, 1992|NA=1992|PAL=1992}}", extractedValue);
        }

        [Test]
        public void ExtractValueForInfoBoxKey_singleLineWithWikiLink_extractsExpectedValue()
        {
            string extractedValue = InfoBoxWikiTextParser.GetNamedElementFromInfoBox(sampleWikiText, "developer");

            Assert.AreEqual("[[HOT・B]]<br />Mebius(3DS)", extractedValue);
        }

        [Test]
        public void ExtractValueForInfoBoxKey_multiLineWithTemplates_extractsExpectedValue()
        {
            string extractedValue = InfoBoxWikiTextParser.GetNamedElementFromInfoBox(sampleWikiText, "publisher");

            const string expectedValue = @"; Mega Drive: {{vgrelease|JP=[[HOT・B]]|NA=[[Flying Edge]]|EU=[[Flying Edge]] <small>(as ''Empire of Steel'')</small>}} 
; Game Boy Advance: {{vgrelease|JP=[[Starfish(company)|Starfish]]|EU=[[Zushi Games|Zoo Digital Publishing]]}}
; Nintendo 3DS: {{vgrelease|JP=Starfish SD|NA=[[Teyon]]}}";

            Assert.AreEqual(expectedValue, extractedValue);
        }

        [Test]
        public void ExtractValueForInfoBoxKey_multiLineWithTemplates2_extractsExpectedValue()
        {
            const string expectedValue = @"{{Collapsible list
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

            string extractedValue = InfoBoxWikiTextParser.GetNamedElementFromInfoBox(sampleWikiText, "distributor");

            Assert.AreEqual(expectedValue, extractedValue);
        }

        [Test]
        public void ExtractValueForInfoBoxKey_multiLineWithPlainListTemplate_extractsExpectedValue()
        {
            string extractedValue = InfoBoxWikiTextParser.GetNamedElementFromInfoBox(sampleWikiText, "designer");

            const string expectedValue = @"{{plainlist|
* [[Atari]] ([[Atari Lynx]])
* [[U.S. Gold]] ([[Atari ST]], [[Amiga]], [[ZX Spectrum]])
* [[Epyx]] ([[MS-DOS]])
* [[Microsoft Home]] ([[Microsoft Windows|Windows]])
}}";

            Assert.AreEqual(expectedValue, extractedValue);
        }

        [Test]
        public void ExtractValueForInfoBoxKey_missingKey_returnsEmptyString()
        {
            string extractedValue = InfoBoxWikiTextParser.GetNamedElementFromInfoBox(sampleWikiText, "foo");

            Assert.AreEqual("", extractedValue);
        }

        [Test]
        public void ExtractValueForInfoBoxKey_keyHasNoValue_returnsEmptyString()
        {
            string extractedValue = InfoBoxWikiTextParser.GetNamedElementFromInfoBox(sampleWikiText, "image");

            Assert.AreEqual("", extractedValue);
        }
    }
}
