using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using ZMWA.Models;

namespace ZMWA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("WP")
            //{
            //    ContextCondition = (context => context.GetOverriddenUserAgent().
            //        IndexOf("Windows Phone OS", StringComparison.OrdinalIgnoreCase) >= 0)
            //});

            //DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("iPhone")
            //{
            //    ContextCondition = (context => context.GetOverriddenUserAgent().
            //        IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            //});

            //DisplayModeProvider.Instance.Modes.Insert(2, new DefaultDisplayMode("Android")
            //{
            //    ContextCondition = (context => context.GetOverriddenUserAgent().
            //        IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0)
            //});

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<ContactDBContext>(null);
        }
    }
}
