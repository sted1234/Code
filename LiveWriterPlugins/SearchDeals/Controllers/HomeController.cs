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
            if (string.IsNullOrWhiteSpace(query))
                return RedirectToAction("Index", "Home");

            IEnumerable<DealItem> deals = dealsProcessor.GetDeals(query);
            return View(deals);
        }


    }

}
