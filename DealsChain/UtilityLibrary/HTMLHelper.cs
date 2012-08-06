using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HtmlAgilityPack;

namespace UtilityLibrary
{
    public class HTMLHelper
    {
        public static List<string> GetLinksFromUrl(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);
            List<string> hrefTags = new List<string>();
            if (document != null && document.DocumentNode != null)
            {
                HtmlNodeCollection nodes = document.DocumentNode.SelectNodes(("//a[@href]"));
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (HtmlNode link in nodes)
                    {
                        HtmlAttribute att = link.Attributes["href"];
                        if(!string.IsNullOrWhiteSpace(att.Value))
                            hrefTags.Add(att.Value);
                    }
                }
            }

            return hrefTags;
        }


        public static List<string> GetLinksFromHTML(string htmlContent)
        {
            List<string> hrefTags = new List<string>();
            if (string.IsNullOrWhiteSpace(htmlContent))
                return hrefTags;

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);

            if (document != null && document.DocumentNode != null)
            {
                HtmlNodeCollection nodes = document.DocumentNode.SelectNodes(("//a[@href]"));
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (HtmlNode link in nodes)
                    {
                        HtmlAttribute att = link.Attributes["href"];
                        if (!string.IsNullOrWhiteSpace(att.Value))
                            hrefTags.Add(att.Value);
                    }
                }

            }

            return hrefTags;
        }
    }
}
