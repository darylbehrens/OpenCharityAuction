using Microsoft.AspNetCore.Mvc;
using OpenCharityAuction.Entities.Models;
using OpenCharityAuction.UnitTests.Models.Services;
using OpenCharityAuction.Web.Controllers;
using OpenCharityAuction.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OpenCharityAuction.UnitTests.Tests
{
    public class EventControllerTests
    {
        [Fact]
        public async void Add_Event_Fails_Validation_Should_Fail_Validation_Return_View()
        {
            var controller = new EventController(new TestAuctionService(), new TestUserService());

            // Did not fill out event info
            AddEventViewModel testEvent = new AddEventViewModel();
            controller.ModelState.AddModelError("", "Error");

            var result = await controller.AddEvent(testEvent);
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal(castedResult.ViewName, "AddEvent");
        }
    }
}
