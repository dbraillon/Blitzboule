using Blitzboule_Web.Models;
using Blitzboule_Web.Repositories;
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
                user = UserRepository.GetByLoginAndPassword(user.Login, user.Password);

                if (user == null)
                {
                    return RedirectToAction("Index", "Home", new { error = "Incorrect identification" });
                }

                Session["user"] = user;

                return RedirectToAction("Index", "Team");
            }
            catch
            {
                return RedirectToAction("Index", "Home", new { error = "An error occured" });
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
