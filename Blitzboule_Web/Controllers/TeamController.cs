using Blitzboule_Web.Filters;
using Blitzboule_Web.Managers;
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
        [Status(UserStatus.WithoutTeam)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorization(UserRole.User)]
        [Status(UserStatus.WithoutTeam)]
        public ActionResult Create(Team team)
        {
            team.IsHuman = true;

            DivisionManager.FindOrCreate(team, League.BRONZE);

            User user = SessionManager.GetUser();
            user.TeamId = team.Id;
            UserRepository.Update(user);

            return RedirectToAction("Index");
        }
    }
}
