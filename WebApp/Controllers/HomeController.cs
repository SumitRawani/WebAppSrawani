using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var s = new HttpClient();
            await s.GetAsync("http://google.com");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Oops" + CauseAnError();
            return View(); 
        }

        public ActionResult Contact()
        {
            var client = new TelemetryClient();
            client.TrackEvent("Contact Information Was Requested");
            ViewBag.Message = "Your contact page.";
            return View();
        }

        private int CauseAnError()
        {
            // Force an unhandled exception
            System.Diagnostics.Trace.TraceWarning("Something bad is about to happen.");
            var numerator = 0;
            var denominator = 0;
            return numerator / denominator;
        }
    }
}