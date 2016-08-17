using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using OpenCharityAuction.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OpenCharityAuction.IntegrationTests.Tests
{
    public class InitalUserLoginTest
    {
        public TestServer server { get; }
        public HttpClient client { get; }

        public InitalUserLoginTest()
        {
            var builder = new WebHostBuilder().UseStartup<TestStartup>();
            server = new TestServer(builder);
            client = server.CreateClient();
        }

        [Fact]
        public async void TestInitialSetup()
        {
            var response = await client.GetAsync("/Home/Index");
            response.EnsureSuccessStatusCode();
        }
    }
}
