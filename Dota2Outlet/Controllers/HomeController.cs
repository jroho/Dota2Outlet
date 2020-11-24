using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dota2Outlet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Response.AppendHeader(
                "X-XRDS-Location",
                new Uri(Request.Url, Response.ApplyAppPathModifier("~/home/xrds")).AbsoluteUri);
            return View("index");
        }

        public ActionResult Xrds()
        {
            return View("xrds");
        }
    }
}
