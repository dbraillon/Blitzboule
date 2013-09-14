using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blitzboule_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string error = "")
        {
            ViewBag.Error = error;

            return View();
        }
    }
}
