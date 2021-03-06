﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MF.Theater.Context;
using MF.Theater.UI.Authentication;
using System.Net.Http;

namespace MF.Theater.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new AuthenticationDbInitializer());
            using (var db = new ApplicationDbContext())
            {
                db.Database.Initialize(true);
            }

            Database.SetInitializer(new TheaterContextInitializer());
            using (var db = new TheaterContext())
            {
                db.Database.Initialize(true);
            }

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            

            UnityConfiguration.RegisterComponents();

            GlobalConfiguration.Configuration.EnsureInitialized(); 
        }
    }
}
