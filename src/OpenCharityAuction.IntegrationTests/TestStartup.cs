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

namespace OpenCharityAuction.IntegrationTests
{
    public class TestStartup : Startup
    {
        public TestStartup(IHostingEnvironment env) : base(env) { }
        
        public override void SetUpDatabase(IServiceCollection services)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            services.AddEntityFrameworkSqlite()
                .AddDbContext<AuctionContext>(
                options => options.UseSqlite(connection));
        }
    }
}
