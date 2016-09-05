using Microsoft.AspNetCore.Mvc;
using OpenCharityAuction.Entities.Models;
using OpenCharityAuction.UnitTests.Models.Services;
using OpenCharityAuction.Web.Controllers;
using OpenCharityAuction.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static OpenCharityAuction.UnitTests.Constants;

namespace OpenCharityAuction.UnitTests.Tests
{
    public class AdmissionTicketContollerTests
    {
        [Fact]
        [Trait(TestType, Unit)]
        public void AdmissionTicket_GET_Index()
        {
            // Arrange
            var controller = new AdmissionTicketController(new TestUserService(), new TestAuctionService());

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("Index", castedResult.ViewName);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public void AdmissionTicket_GET_AddAdmissionTicket_Should_Return_View()
        {
            // Arrange
            var controller = new AdmissionTicketController(new TestUserService(), new TestAuctionService());

            // Act
            var result = controller.AddAdmissionTicket();

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("AddAdmissionTicket", castedResult.ViewName);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void AdmissionTicket_POST_AddAdmissionTicket_No_Event_Should_Return_Redirect()
        {
            // Arrange
            var controller = new AdmissionTicketController(new TestUserService(), new TestAuctionService());
            var vm = new AddAdmissionTicketViewModel()
            {
                Cost = 10M,
                Name = "TEST",

            };

            // Act
            var result = await controller.AddAdmissionTicket(vm);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal("AddAdmissionTicket", castedResult.ActionName);
            Assert.Equal("You must have an active event before you can add tickets", castedResult.RouteValues["errorMessage"]);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void AdmissionTicket_POST_AddAdmissionTicket_Bad_ModelState_Should_Return_View()
        {
            // Arrange
            var controller = new AdmissionTicketController(new TestUserService(), new TestAuctionService());
            var vm = new AddAdmissionTicketViewModel()
            {
                Name = "TEST",
            };
            controller.ModelState.AddModelError("ERROR", "ERROR");

            // Act
            var result = await controller.AddAdmissionTicket(vm);

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("AddAdmissionTicket", castedResult.ViewName);
            Assert.IsType<AddAdmissionTicketViewModel>(castedResult.Model);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void AdmissionTicket_POST_AddAdmissionTicket_Pass_Should_Return_Redirect()
        {
            // Arrange
            var testUserService = new TestUserService();
            testUserService.intReturn = 3; // To Allow To Pass
            var controller = new AdmissionTicketController(testUserService, new TestAuctionService());
            var vm = new AddAdmissionTicketViewModel()
            {
                Cost = 10M,
                Name = "TEST",
            };

            // Act
            var result = await controller.AddAdmissionTicket(vm);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal("Index", castedResult.ActionName);
            Assert.Equal("AdmissionTicket", castedResult.ControllerName);
        }
    }
}
