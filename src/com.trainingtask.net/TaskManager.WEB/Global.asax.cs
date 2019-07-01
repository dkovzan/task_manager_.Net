﻿using log4net;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TaskManager.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            _logger.Info("Starting application...");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            _logger.Error(Server.GetLastError());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var newCulture = (CultureInfo) Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            newCulture.DateTimeFormat.DateSeparator = "-";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }

    }
}
