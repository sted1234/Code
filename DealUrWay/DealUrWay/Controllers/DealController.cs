using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealUrWay.BusinessObjects;
using DealUrWay.DealManager;

using DD = DealUrWay.DealManager;
using System.Web.Routing;

namespace DealUrWay.Controllers
{
    public class DealController : Controller
    {
        //
        // GET: /Deal/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowDealProviders()
        {
            IEnumerable<string> dealProviders = DD.DealManager.GetDealProviders();
            return View(dealProviders);
        }

        public ActionResult GetDeals(string dealProvider)
        {
            DealRequest request = new DealRequest { Name = dealProvider };
            IDealResponse response = DD.DealManager.GetDeals(request);
            return View(response.DealItems);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(DealItem item)
        {
            return View("thanks", item);
        }


   }

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString HtmlLink(this HtmlHelper html, string url, string text, object htmlAttributes)
        {
            TagBuilder tb = new TagBuilder("a");
            tb.InnerHtml = text;
            //tb.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tb.MergeAttribute("href", url);
            return MvcHtmlString.Create(tb.ToString(TagRenderMode.Normal));
        }
    }


}
