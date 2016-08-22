using OpenCharityAuction.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OpenCharityAuction.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Builder;

namespace OpenCharityAuction.IntegrationTests
{
    public class TestStartup : Startup
    {
        public TestStartup(IHostingEnvironment env) : base(env) { }
        
        public override void SetUpDatabase(IServiceCollection services)
        {
            // Adds AuctionContext Connection String
            services.AddDbContext<AuctionContext>(options => options.UseSqlServer(Configuration["data:testconnectionstring"]));

            // Adds UserContext Connection String
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration["data:testconnectionstring"]));

            var conn = Configuration["data:testconnectionstring"];
        }

        public override void EnsureDatabaseCreated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {


                var auctionContext = serviceScope.ServiceProvider.GetService<AuctionContext>();
                auctionContext.Database.Migrate();

                var userContext = serviceScope.ServiceProvider.GetService<UserContext>();
                userContext.Database.Migrate();

                auctionContext.Database.ExecuteSqlCommand("DELETE FROM events");
                auctionContext.Database.ExecuteSqlCommand("DELETE FROM aspnetusers");
            }
        }
    }
}
