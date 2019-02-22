using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using DanceMS.DataObjects;
using DanceMS.Models;
using Owin;
using System.Data.Entity.Migrations;

namespace DanceMS
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();
            var mobileConfig = new MobileAppConfiguration();

            mobileConfig
                .AddTablesWithEntityFramework()
                .ApplyTo(httpConfig);


            // Automatic Code First Migrations
            var migrator = new DbMigrator(new DanceMSService.Migrations.Configuration());
            migrator.Update();

            app.UseWebApi(httpConfig);
        }
    }
}

