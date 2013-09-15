using Blitzboule_Web.Controllers;
using Blitzboule_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blitzboule_Web.Filters
{
    public class StatusAttribute : AuthorizeAttribute
    {
        private const string redirectUnauthorized = "/Team/";
        private readonly UserStatus[] acceptedStatus;

        public StatusAttribute(params UserStatus[] acceptedStatus)
        {
            this.acceptedStatus = acceptedStatus;
        }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            User user = SessionManager.GetUser();

            if (user == null)
            {
                httpContext.Response.Redirect(redirectUnauthorized);
                return false;
            }

            if (acceptedStatus.Contains(user.Status))
            {
                return true;
            }

            httpContext.Response.Redirect(redirectUnauthorized);
            return false;
        }
    }
}