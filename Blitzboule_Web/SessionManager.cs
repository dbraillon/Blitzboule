using Blitzboule_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web
{
    public static class SessionManager
    {
        private const string userSession = "user";

        public static User GetUser()
        {
            return (User)HttpContext.Current.Session[userSession];
        }

        public static void SetUser(User user)
        {
            HttpContext.Current.Session[userSession] = user;
        }
    }
}