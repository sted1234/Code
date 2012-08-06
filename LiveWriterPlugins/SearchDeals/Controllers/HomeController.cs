using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sandworks.Google.Reader;
using System.Xml.Linq;
using SearchDeals.Models;
using UtilityLibrary;

namespace SearchDeals.Controllers
{
    public class HomeController : Controller
    {

        IDealsProcessor dealsProcessor = null;

        public HomeController(IDealsProcessor processor)
        {
            dealsProcessor = processor;
        }

        public HomeController()
        {
            dealsProcessor = new DealsProcessor(new DealsRepository());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string query)
        {
            FeedWriter.PublishFeed();
            if (string.IsNullOrWhiteSpace(query))
                return RedirectToAction("Index", "Home");

            IEnumerable<DealItem> deals = dealsProcessor.GetDeals(query);
            return View(deals);
        }

        public ActionResult SearchDeals(string query)
        {
            List<RawDealItem> results = new List<RawDealItem>();
            using (ReaderService rdr = new ReaderService("affiliatested", "Sudha123", "Sandworks.Google.App"))
            {
                var resultsXml = rdr.Search(query, "20");
                XNamespace xmlns = "http://www.w3.org/2005/Atom";
                results = XElement.Parse(resultsXml).Elements(xmlns + "entry").Select(o => new RawDealItem(o, xmlns)).ToList<RawDealItem>();

            }
            return View(results.Distinct<RawDealItem>(new DealItemComparer()).ToList());

        }


    }

}
