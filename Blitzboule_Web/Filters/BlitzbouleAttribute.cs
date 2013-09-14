using Blitzboule_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blitzboule_Web.Filters
{
    public class BlitzbouleAttribute : AuthorizeAttribute
    {
        private readonly UserRole[] acceptedRoles;

        public BlitzbouleAttribute(params UserRole[] acceptedRoles)
        {
            this.acceptedRoles = acceptedRoles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            User user = Session.GetUser();

            if (user == null)
            {
                return false;
            }

            foreach (UserRole role in acceptedRoles)
            {
                if (role == user.Role)
                {
                    return true;
                }
            }

            return false;
        }
    }
}