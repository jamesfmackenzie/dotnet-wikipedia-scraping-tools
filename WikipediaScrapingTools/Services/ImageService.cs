using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using HtmlAgilityPack;

namespace WikipediaScrapingTools.Services
{
    public class ImageService
    {
        public static List<string> GetImageUrlsForWikipediaUrl(string url)
        {
            var wikipediaPageTitle = url.Replace("https://en.wikipedia.org/wiki/", "");

            var apiUrlToFetchImages = GetWikipediaImagesApiUrlForWikipediaPageTitle(wikipediaPageTitle);

            var apiResponse = DownloadUrlAsString(apiUrlToFetchImages);

            if (apiResponse.IndexOf("#REDIRECT", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                wikipediaPageTitle = GetRedirectTargetFromWikipediaXmlResponse(apiResponse);
                apiUrlToFetchImages = GetWikipediaImagesApiUrlForWikipediaPageTitle(wikipediaPageTitle);
                apiResponse = DownloadUrlAsString(apiUrlToFetchImages);
            }

            var imageTitles = GetImageTitlesFromWikipediaXmlResponse(apiResponse);
            var imagesUrls = imageTitles.Select(GetUrlForImageTitle);

            return imagesUrls.ToList();

            // TODO: additionally fetch image from InfoBox (if the page has one)
        }

        // TODO: move these utility methods into separate classes and write unit tests

        private static string GetWikipediaImagesApiUrlForWikipediaPageTitle(string t)
        {
            return string.Format(
                "https://en.wikipedia.org/w/api.php?action=query&titles={0}&prop=images&format=xml",
                t);
        }

        private static string GetWikipediaImageInfoApiUrlForWikipediaImageTitle(string t)
        {
            var encodedImageTitle = HttpUtility.UrlEncode(t);

            return string.Format(
                "https://en.wikipedia.org/w/api.php?action=query&titles={0}&prop=imageinfo&iiprop=url&format=xml",
                encodedImageTitle);
        }

        private static string GetRedirectTargetFromWikipediaXmlResponse(string r)
        {
            return
                r.Substring(r.IndexOf("[[", StringComparison.InvariantCultureIgnoreCase) + 2,
                    r.IndexOf("]]", StringComparison.InvariantCultureIgnoreCase) -
                    r.IndexOf("[[", StringComparison.InvariantCultureIgnoreCase) - 2);
        }

        private static List<string> GetImageTitlesFromWikipediaXmlResponse(string r)
        {
            var imageTitles = new List<string>();

            var xmlDocument = new HtmlDocument();
            xmlDocument.LoadHtml(r);

            var imagesXmlNode = xmlDocument.DocumentNode.Descendants().FirstOrDefault(x => (x.Name == "images"));

            var imageXmlNodeCollection = imagesXmlNode?.Descendants("im").ToList();
            if (imageXmlNodeCollection != null)
            {
                imageTitles.AddRange(
                    imageXmlNodeCollection.Select(imageXmlNode => imageXmlNode.GetAttributeValue("title", null))
                        .Where(
                            imageTitle =>
                                imageTitle != null &&
                                (imageTitle.Contains(".jpg") || imageTitle.Contains(".jpeg") ||
                                 imageTitle.Contains(".png") || imageTitle.Contains(".gif"))));
            }

            return imageTitles;
        }

        private static string GetImageUrlFromWikipediaXmlResponse(string r)
        {
            var xmlDocument = new HtmlDocument();
            xmlDocument.LoadHtml(r);

            var imageInfoContainerXmlNode =
                xmlDocument.DocumentNode.Descendants().FirstOrDefault(x => (x.Name == "imageinfo"));

            var imageInfoXmlNodeCollection = imageInfoContainerXmlNode?.Descendants("ii").ToList();

            if (imageInfoXmlNodeCollection != null && imageInfoXmlNodeCollection.Count >= 1)
            {
                return imageInfoXmlNodeCollection.First().GetAttributeValue("url", null);
            }

            return "";
        }

        private static string DownloadUrlAsString(string s)
        {
            var client = new WebClient {Encoding = Encoding.UTF8};
            return client.DownloadString(s);
        }

        private static string GetUrlForImageTitle(string imageTitle)
        {
            var apiUrlToFetchImageInfo = GetWikipediaImageInfoApiUrlForWikipediaImageTitle(imageTitle);
            var apiResponse = DownloadUrlAsString(apiUrlToFetchImageInfo);
            return GetImageUrlFromWikipediaXmlResponse(apiResponse);
        }
    }
}