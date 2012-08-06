using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UtilityLibrary;
using HtmlAgilityPack;

using System.Threading.Tasks;

namespace AlvinAshcraftLinks
{
    class GetAllLinksFromDealsAllTop
    {
        static void Main2(string[] args)
        {

            string url = "http://deals.alltop.com/";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);
            List<string> dealLinks = new List<string>();
            if (document != null && document.DocumentNode != null)
            {
                HtmlNodeCollection dealSites = document.DocumentNode.SelectNodes(("//a[@class='snap_shots']"));
                if (dealSites != null && dealSites.Count > 0)
                {
                    foreach (HtmlNode site in dealSites)
                    {
                        dealLinks.Add(site.Attributes["href"].Value);

                    }
                }
            }

            
            System.IO.File.WriteAllLines(@"C:\Users\sumant\desktop\deallinks.txt", dealLinks.ToArray());



            Console.Read();
        }


    }
}
