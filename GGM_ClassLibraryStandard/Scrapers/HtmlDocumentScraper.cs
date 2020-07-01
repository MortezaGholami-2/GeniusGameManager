using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace GGM_ClassLibraryStandard.Scrapers
{
    public class HtmlDocumentScraper
    {
        public static HtmlDocument GetHtmlDocumentByDocumentPath(string documentPath)
        {
            HtmlDocument document = new HtmlDocument();
            document.Load(documentPath);
            return document;
        }

        public static HtmlDocument GetHtmlDocumentByWebPageUrl(string webPageUrl)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            try
            {
                HtmlWeb web = new HtmlWeb();
                //web.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.137 Safari/537.36";
                HtmlDocument document = web.Load(webPageUrl);
                return document;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static HtmlDocument GetHtmlDocumentByHtmlString(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            return document;
        }
    }
}
