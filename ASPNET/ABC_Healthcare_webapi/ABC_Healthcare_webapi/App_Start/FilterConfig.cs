﻿using System.Web;
using System.Web.Mvc;

namespace ABC_Healthcare_webapi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
