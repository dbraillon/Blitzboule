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
    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult SignIn(User user)
        {
            /// Check if an user have a match with this login and password, if not redirect
            if ((user = UserRepository.GetByLoginAndPassword(user.Login, user.Password)) == null)
                return RedirectToAction("Index", "Home");

            /// Set the user in Session
            SessionManager.SetUser(user);

            /// Redirect to Team Index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SignUp(FormCollection collection, User user)
        {
            /// Check if the model state is valide and
            /// if both password fields match, if not redirect
            if (!ModelState.IsValid || user.Password != collection["passwordCheck"])
            {
                return RedirectToAction("Index", "Home");
            }

            /// Add role and status to users and insert in database
            user.Role = UserRole.User;
            user.Status = UserStatus.WithoutTeam;
            UserRepository.Insert(user);

            /// Set the user in Session
            SessionManager.SetUser(user);

            /// Inform user that sign up succed
            return RedirectToAction("SignUpSuccess");
        }

        [Authorization(UserRole.User)]
        public ActionResult SignUpSuccess()
        {
            return View();
        }

        [Authorization(UserRole.User)]
        public ActionResult Index()
        {
            /// Get the user in Session
            User user = SessionManager.GetUser();

            /// Get the user team and redirect if there's
            /// no team corresponding to this user
            if ((user.Team = TeamRepository.ReadByUser(user)) == null)
            {
                user.Status = UserStatus.WithoutTeam;

                return RedirectToAction("Create", "Team");
            }

            /// If the user has a team go to the Index view
            return View(user);
        }
    }
}
