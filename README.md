# dotnet-wikipedia-scraping-tools
A .NET library for parsing / scraping data from Wikipedia. Some examples:

###Get Wikipedia url for a given PageId:
```
string url = PageIdService.GetWikipediaUrlForPageId(pageId);
```

###Follow Wikipedia redirects:
```
string destinationUrl = UrlRedirectService.GetRedirectUrlForWikipediaUrl(url);
```

###Fetches images for a given Wikipedia url:
```
List<string> imageUrls = ImageService.GetImageUrlsForWikipediaUrl(url);
```

###Fetch InfoBox Text for a given Wikipedia url, then parse out useful details:
```
string infoBoxText = InfoBoxService.GetInfoBoxTextForWikipediaUrl(url);
string title = InfoBoxWikiTextParser.GetTitleForInfoBox(infoBoxText);
string genre = InfoBoxWikiTextParser.GetNamedElementFromInfoBox(infoBoxText, "genre");
```

###Parse out useful info from InfoBox text:
```
string plainTextGenre = InternalWikiLinkParser.ExtractDisplayTextFromLink(genre));
```
