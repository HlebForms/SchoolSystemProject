using SchoolSystem.Data;
using SchoolSystem.Data.Migrations;
using SchoolSystem.WebForms.App_Start;
using System;
using System.Data.Entity;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace SchoolSystem.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolSystemDbContext, Configuration>());
            //var database = new SchoolSystemDbContext();
            //database.Database.CreateIfNotExists();
            DbConfig.Initialize();
            // Ninject
            BindingsConfig.BindPresenterFactory();
        }
    }
}