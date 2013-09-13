using Blitzboule_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blitzboule_Web.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult SignIn(User user)
        {
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult SignUp(FormCollection collection, User user)
        {
            try
            {
                if(user.Password != collection["passwordCheck"])
                    return RedirectToAction("Index", "Home");

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
