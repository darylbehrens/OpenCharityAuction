using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using OpenCharityAuction.Entities.Models;
using OpenCharityAuction.Web;
using OpenCharityAuction.Web.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
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
            var path = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory());
            var setDir = Path.GetFullPath(Path.Combine(path, "OpenCharityAuction.Web/"));

            var builder = new WebHostBuilder().UseContentRoot(setDir).UseStartup<TestStartup>();
            
            server = new TestServer(builder);
            client = server.CreateClient();
        }

        [Fact]
        public async void TestInitialSetup()
        {
            Event newEvent = new Event()
            {
                EventDate = DateTime.Now,
                EventName = "TEST;"
            };


            var content = JsonConvert.SerializeObject(newEvent).ToString();
            var response = await client.PostAsync("/Event/AddEvent", new StringContent(content, System.Text.Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }
}
