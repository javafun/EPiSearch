using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer;
using EPiServer.Core;
using HtmlAgilityPack;
using Perks;

namespace EPiSearch
{
    internal static class ContentExtensions
    {
        public static bool IsPublished(this PageData item)
        {
            return item.CheckPublishedStatus(PagePublishedStatus.Published);
        }

        public static string GetFriendlyUrl(this IContent item)
        {
            if (item is PageData)
            {
                return ToFriendlyUrl(((PageData) item).LinkURL, item.ContentLink);
            }

            return null;
        }

        public static string ToFriendlyUrl(this string url, ContentReference contentLink = null)
        {
            var friendlyUrl = new UrlBuilder(url);
            EPiServer.Global.UrlRewriteProvider.ConvertToExternal(friendlyUrl, contentLink, Encoding.UTF8);
            return friendlyUrl.ToString();
        }

        public static string TrimHtml(this string html)
        {
            if (html.IsNullOrEmpty())
            {
                return html;
            }

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return doc.DocumentNode.InnerText.HtmlDecode();
        }
    }
}
