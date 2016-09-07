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

namespace OpenCharityAuction.UnitTests.Tests
{
    public class EventControllerTests
    {
        [Fact]
        [Trait("TestType", "Unit")]
        public async void Event_AddEvent_POST_FAIL_Validation_Return_View()
        {
            var controller = new EventController(new TestAuctionService(), new TestUserService());

            // Did not fill out event info
            AddEventViewModel testEvent = new AddEventViewModel();
            controller.ModelState.AddModelError("", "Error");

            var result = await controller.AddEvent(testEvent);
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("AddEvent", castedResult.ViewName);
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public async void Event_AddEvent_POST_PASS_Return_Redirect()
        {
            var controller = new EventController(new TestAuctionService(), new TestUserService());

            // Did not fill out event info
            AddEventViewModel testEvent = new AddEventViewModel()
            {
                EventDate = DateTime.Now,
                EventName = "Test"
            };

            var result = await controller.AddEvent(testEvent);
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal("Index", castedResult.ActionName);
            Assert.Equal("Event", castedResult.ControllerName);
            Assert.Equal("Event Added", castedResult.RouteValues["successMessage"]);
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public void Event_AddEvent_POST_FAIL_No_Event_Name()
        {
            AddEventViewModel vm = new AddEventViewModel()
            {
                EventDate = DateTime.Now
            };

            var context = new ValidationContext(vm, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(vm, context, result, true);
            Assert.False(valid);
            var failure = Assert.Single(result, x => x.ErrorMessage == "The Event Name field is required.");
            Assert.Single(failure.MemberNames, x => x == "EventName");
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public void Event_AddEvent_POST_FAIL_No_Event_Date()
        {
            AddEventViewModel vm = new AddEventViewModel()
            {
                EventName = "TEST"
            };

            var context = new ValidationContext(vm, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(vm, context, result, true);
            Assert.False(valid);
            var failure = Assert.Single(result, x => x.ErrorMessage == "The Event Date field is required.");
            Assert.Single(failure.MemberNames, x => x == "EventDate");
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public void Event_Index_GET_PASS_Should_Return_View()
        {
            var controller = new EventController(new TestAuctionService(), new TestUserService());
            var result = controller.Index();

            Assert.IsType<ViewResult>(result);

            var castedResult = result as ViewResult;
            Assert.Equal("Index", castedResult.ViewName);
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public void Event_AddEvent_GET_PASS_Should_Return_View()
        {
            var controller = new EventController(new TestAuctionService(), new TestUserService());
            var result = controller.AddEvent();

            Assert.IsType<ViewResult>(result);

            var castedResult = result as ViewResult;
            Assert.Equal("AddEvent", castedResult.ViewName);
        }

        //[Fact]
        //[Trait("TestType", "Unit")]
        //public async void Event_SelectCurrentEvent_GET_PASS_Should_Return_View()
        //{
        //    // Arrange
        //    var controller = new EventController(new TestAuctionService(), new TestUserService());

        //    // Assert
        //    var result = await controller.SelectCurrentEvent();

        //    // Act
        //    Assert.IsType<ViewResult>(result);
        //    var castedResult = result as ViewResult;
        //    Assert.Equal("SelectCurrentEvent", castedResult.ViewName);
        //    Assert.IsType<SelectCurrentEventViewModel>(castedResult.Model);
        //    Assert.Null(castedResult.ViewData["Error"]);
        //}

        //[Fact]
        //[Trait("TestType", "Unit")]
        //public async void Event_SelectCurrentEvent_POST_FAIL_Invalid_EventId_Return_View()
        //{
        //    // Arrange
        //    var controller = new EventController(new TestAuctionService(), new TestUserService());

        //    var vm = new SelectCurrentEventViewModel();

        //    // Assert
        //    var result = await controller.SelectCurrentEvent("cat", vm);

        //    // Act
        //    Assert.IsType<RedirectToActionResult>(result);
        //    var castedResult = result as RedirectToActionResult;
        //    Assert.Equal("SelectCurrentEvent", castedResult.ActionName);
        //    Assert.Equal("Please make a valid selection.", castedResult.RouteValues["errorMessage"]);
        //}

        //[Fact]
        //[Trait("TestType", "Unit")]
        //public async void Event_SelectCurrentEvent_POST_PASS_Should_Return_Redirect()
        //{
        //    // Arrange
        //    var controller = new EventController(new TestAuctionService(), new TestUserService());

        //    var vm = new SelectCurrentEventViewModel();

        //    // Assert
        //    var result = await controller.SelectCurrentEvent("1", vm);

        //    // Act
        //    Assert.IsType<RedirectToActionResult>(result);
        //    var castedResult = result as RedirectToActionResult;
        //    Assert.Equal("Index", castedResult.ActionName);
        //    Assert.Equal("Event", castedResult.ControllerName);
        //    Assert.Equal("Active Event Changed", castedResult.RouteValues["successMessage"]);
        //}
    }
}
