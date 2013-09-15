using Blitzboule_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blitzboule_Web.Filters
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        private const string redirectUnauthorized = "/";
        private readonly UserRole[] acceptedRoles;
        
        public AuthorizationAttribute(params UserRole[] acceptedRoles)
        {
            this.acceptedRoles = acceptedRoles;
        }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            User user = SessionManager.GetUser();

            if (user == null)
            {
                httpContext.Response.Redirect(redirectUnauthorized);
                return false;
            }

            if (acceptedRoles.Contains(user.Role))
            {
                return true;
            }

            httpContext.Response.Redirect(redirectUnauthorized);
            return false;
        }
    }
}