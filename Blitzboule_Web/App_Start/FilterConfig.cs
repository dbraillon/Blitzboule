﻿using Blitzboule_Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace Blitzboule_Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}