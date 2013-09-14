using Blitzboule_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web
{
    public static class Session
    {
        public static User GetUser()
        {
            return (User)HttpContext.Current.Session["user"];
        }
    }
}