using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UtilityLibrary;
using HtmlAgilityPack;

using System.Threading.Tasks;
using Sandworks.Google.Reader;
using System.ServiceModel;
namespace AlvinAshcraftLinks
{
    class AlvinAshcraftLinks
    {
        static void Main2(string[] args)
        {
            string url = "http://www.alvinashcraft.com/";
            int month = 1;
            int maxPageNumber = 10;
            List<string> feedLinks = new List<string>();

            List<string> allPageLinks = new List<string>();
            while (month < 13)
            {
                for (int i = 1; i <= maxPageNumber; i++)
                {
                    string link = string.Format(@"http://www.alvinashcraft.com/2011/{0}/page/{1}", month, i);
                    allPageLinks.Add(link);
                }
                month++;
            }


            Parallel.ForEach(allPageLinks, (link) => {

                Console.WriteLine("Processing link: " + link);

                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(link);

                // Get the Daily Posts
                if (document != null && document.DocumentNode != null)
                {
                    if (!document.DocumentNode.InnerHtml.Contains("404 - Not Found"))
                    {
                        HtmlNodeCollection dailyPost = document.DocumentNode.SelectNodes(("//div[@class='post-entry']"));
                        if (dailyPost != null && dailyPost.Count > 0)
                        {
                            foreach (HtmlNode post in dailyPost)
                            {
                                foreach (string linkUrl in HTMLHelper.GetLinksFromHTML(post.InnerHtml))
                                {
                                    if (!(linkUrl.Contains("del.icio.us") || linkUrl.Contains("amazon.com") || linkUrl.Contains("alvinash")))
                                    {
                                        feedLinks.Add(linkUrl);
                                    }
                                }
                            }
                        }
                    }
                }
            
            });

            //foreach (string link in allPageLinks)
            //{
            //    Console.WriteLine("Processing link: " + link);

            //    HtmlWeb web = new HtmlWeb();
            //    HtmlDocument document = web.Load(link);

            //    // Get the Daily Posts
            //    if (document != null && document.DocumentNode != null)
            //    {
            //        if (document.DocumentNode.InnerHtml.Contains("404 - Not Found"))
            //            continue;

            //        HtmlNodeCollection dailyPost = document.DocumentNode.SelectNodes(("//div[@class='post-entry']"));
            //        if (dailyPost != null && dailyPost.Count > 0)
            //        {
            //            foreach (HtmlNode post in dailyPost)
            //            {
            //                foreach (string linkUrl in HTMLHelper.GetLinksFromHTML(post.InnerHtml))
            //                {
            //                    if (!(linkUrl.Contains("del.icio.us") || linkUrl.Contains("amazon.com") || linkUrl.Contains("alvinash")))
            //                        feedLinks.Add(linkUrl);
            //                }
            //            }
            //        }
            //    }
            //}

            System.IO.File.WriteAllLines(@"C:\Users\sumant\desktop\subscriptions.txt", feedLinks.ToArray());

            
            //HtmlWeb web = new HtmlWeb();
            //HtmlDocument document = web.Load(url);
            //List<string> feedLinks = new List<string>();
            //if (document != null && document.DocumentNode != null)
            //{
            //    HtmlNodeCollection dailyPost = document.DocumentNode.SelectNodes(("//div[@class='post-entry']"));
            //    if (dailyPost != null && dailyPost.Count > 0)
            //    {
            //        foreach (HtmlNode post in dailyPost)
            //        {
            //            foreach (string link in HTMLHelper.GetLinksFromHTML(post.InnerHtml))
            //            {
            //                if (!(link.Contains("del.icio.us") || link.Contains("amazon.com") || link.Contains("alvinash")))
            //                    feedLinks.Add(link);
            //            }
            //        }
            //    }
            //}



            // Subscribe to links now.
            using (ReaderService rdr = new ReaderService("affiliatested", "Sudha123", "Sandworks.Google.App"))
            {
                List<Subscription> s = rdr.GetSubscriptions();
                foreach (string link in feedLinks)
                {
                    try
                    {
                        {
                            //rdr.AddSubscription(link);
                            Console.WriteLine("Subscription Added: " + link);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("************Failed********" + " " + link);
                    }
                }

            }

            Console.Read();
        }


    }
}
