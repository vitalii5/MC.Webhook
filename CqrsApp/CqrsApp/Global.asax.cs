using CqrsApp.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CqrsApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static SampleCQRSRuntime Runtime { get; set; }
        protected void Application_Start()
        {

            Runtime = new SampleCQRSRuntime();
            Runtime.Start();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            Runtime.Shutdown();
        }
    }
}
