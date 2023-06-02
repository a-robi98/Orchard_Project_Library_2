using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Orchard_Project_Library_2.BookModule.Drivers;
//using Orchard_Project_Library_2.BookModule.Filters;
using Orchard_Project_Library_2.BookModule.Migrations;
using Orchard_Project_Library_2.BookModule.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard_Project_Library_2.BookModule
{
    public class Startup
    {
        public  void ConfigureServices(IServiceCollection services)
        {
            services
                .AddContentPart<BookPart>()
                .UseDisplayDriver<BookPartDisplayDriver>();
            //    .AddHandler<PersonPartHandler>();
            services.AddScoped<IDataMigration, BookMigrations>();
            //services.AddSingleton<IIndexProvider, PersonPartIndexProvider>();

            //services.Configure<MvcOptions>(options => options.Filters.Add(typeof(ShapeInjectingFilter)));

            //services.AddScoped<ILoginFormEvent, LoginGreeting>();

            //services.AddScoped<IPermissionProvider, PersonPagePermissions>();

            //services.AddSingleton<IBackgroundTask, DemoBackgroundTask>();

            //services.AddScoped<INavigationProvider, AdminMenu>();

        }
        public  void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "Orchard_Project_Library_2.BookModule",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
