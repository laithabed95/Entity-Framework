using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Order.Models;


namespace Order
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // el set initithlizor bbl3' el code first y3ne b7alt tm 3ml t3'yer lal model e3ml drop lal db w swe wa7de jdedeh
           //Database.SetInitializer<OrderingContext>(new DropCreateDatabaseIfModelChanges<OrderingContext>());

            //bswe database mn awl w jdeed w ra7 y7u6le data fe el database 
            //Database.SetInitializer<OrderingContext>(new Orderinginitilaizor());

            // hay 3shan aswe update bdun ma a5sr el date ele 3ndi 
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
            <Order.Models.OrderingContext, Order.Migrations.Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
