using Martec.Infrastructure;
//using Martec.Infrastruture.Migrations;
using Ninject.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Martec
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            NinjectContainer.RegisterAssembly();
            DatabaseMigrator.UpdateDatabase();
           
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
