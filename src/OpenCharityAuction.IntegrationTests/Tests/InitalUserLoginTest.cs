using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenCharityAuction.Entities.Models;
using OpenCharityAuction.Web;
using OpenCharityAuction.Web.Controllers;
using OpenCharityAuction.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
            //  // Get Anti Forgery Token
            //  client.BaseAddress = new Uri("http://localhost:8888");
            //  var getResponse = await client.GetAsync("/Event/AddEvent");
            //  var som = getResponse.Headers;
            //  string token = await Helpers.ExtractAntiForgeryToken(getResponse);

            //AddEventViewModel newEvent = new AddEventViewModel()
            //  {
            //      EventDate = DateTime.Now,
            //      EventName = "TEST;"
            //  };

            //  var content = JsonConvert.SerializeObject(newEvent);
            //  var array = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            //  array.Add("__RequestVerificationToken", token);
            //  var newContent = JsonConvert.SerializeObject(array);

            //  var finalContent = new StringContent(newContent, Encoding.UTF8, "application/json");
            //  var sometihing = Helpers.CreateWithCookiesFromResponse("/Authentication/InitialSetup", finalContent, getResponse);
            //  var response = await client.SendAsync(sometihing);
            //  var result = response.ReasonPhrase + response.RequestMessage;

            var response = await client.GetAsync("/Authentication/InitialSetup");
        }
    }
}
