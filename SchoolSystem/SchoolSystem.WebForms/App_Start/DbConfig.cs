using SchoolSystem.Data;
using SchoolSystem.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolSystemDbContext, Configuration>());
            SchoolSystemDbContext.Create().Database.Initialize(true);
        }
    }
}