using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paypal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View("Paypal");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult PostToPaypal(string item, string amount)
        {
            var paypal = new Models.Paypal();
            paypal.cmd = "_xclick";
            paypal.business = ConfigurationManager.AppSettings["BusinessAccountKey"];

            var useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["UseSandBox"]);
            ViewBag.actionUrl = useSandbox ? "https://www.sandbox.paypal.com/cgi-bin/webscr" : "https://www.paypal.com/cgi-bin/webscr";

            paypal.cancel_return = ConfigurationManager.AppSettings["CancelURL"];
            paypal.@return = ConfigurationManager.AppSettings["ReturnURL"];
            paypal.notify_url = ConfigurationManager.AppSettings["NotifyURL"];
            paypal.currency_code = ConfigurationManager.AppSettings["CurrencyCode"];

            paypal.item_name = item;

            paypal.amount = amount;

            return View(paypal);

        }
    }
}
