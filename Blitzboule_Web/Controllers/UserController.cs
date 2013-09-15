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
            return RedirectToAction("Index", "Team");
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
    }
}
