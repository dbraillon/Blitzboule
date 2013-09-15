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
        [Authorization(UserRole.User)]
        public ActionResult Index()
        {
            /// Get the user in Session
            User user = SessionManager.GetUser();

            /// Check user status
            if (user.Status == UserStatus.WithoutTeam)
                return RedirectToAction("Create");
            
            /// Get the user team and redirect if there's
            /// no team corresponding to this user
            if ((user.Team = TeamRepository.GetByUser(user)) == null)
            {
                return RedirectToAction("Create");
            }

            /// If the user has a team go to the Index view
            return View();
        }

        [Authorization(UserRole.User)]
        [Status(UserStatus.WithoutTeam)]
        public ActionResult Create()
        {
            return View();
        }
    }
}
