using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OpenCharityAuction.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            // Sets the config info from config.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json", true);

            Configuration = builder.Build();
        }
            
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup Redirect If Not Logged In
            services.Configure<IdentityOptions>(options =>
            {
                options.Cookies.ApplicationCookie.LoginPath = new PathString("/Authentication/InitialSetup");
            });

            // Adds Config To Dependency Injection System
            services.AddSingleton(new Models.Configuration(Configuration["app:appName"]));

            // User Data Service For Injection
            services.AddTransient<Models.Interfaces.IUserService, Models.Services.UserService>();

            // Auction Data Service For Injection
            services.AddTransient<Models.Interfaces.IAuctionService, Models.Services.AuctionService>();

            SetUpDatabase(services);

            

            // Adds ASP Identity Roles
            services.AddIdentity<Models.User, IdentityRole>()
                .AddEntityFrameworkStores<Data.UserContext>()
                .AddDefaultTokenProviders();

            // Adds MVC
            services.AddMvc();

        }

        public virtual void SetUpDatabase(IServiceCollection services)
        {
            // Adds AuctionContext Connection String
            services.AddDbContext<Data.AuctionContext>(options => options.UseSqlServer(Configuration["data:connectionstring"]));

            // Adds UserContext Connection String
            services.AddDbContext<Data.UserContext>(options => options.UseSqlServer(Configuration["data:connectionstring"]));
        }

        public virtual void EnsureDatabaseCreated(IApplicationBuilder app)
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // I Dont Know what this is for
            loggerFactory.AddConsole();

            // I dont know what this is for yet
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Allows access to static files in wwwroot
            app.UseStaticFiles();

            // Uses Identity For Tokens
            app.UseIdentity();

            // For setting up integration test database
            EnsureDatabaseCreated(app);

            // Use MVC, route user to main page depending on status of install
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Authentication}/{action=InitialSetup}/{id?}");
            });
        }
    }
}
