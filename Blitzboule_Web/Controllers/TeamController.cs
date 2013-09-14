using Blitzboule_Web.Filters;
using Blitzboule_Web.Models;
using Blitzboule_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blitzboule_Web.Controllers
{
    public class TeamController : Controller
    {
        [Blitzboule(UserRole.User)]
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                RedirectToAction("Index", "Home");
            }

            User user = Session["user"] as User;
            user.Team = TeamRepository.GetByUser(user);

            if (user.Team == null)
            {
                RedirectToAction("Create");
            }

            return View();
        }

        [Blitzboule(UserRole.User)]
        public ActionResult Create()
        {
            return View();
        }
    }
}
