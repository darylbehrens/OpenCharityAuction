﻿using Microsoft.AspNetCore.Mvc;
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

        [Fact]
        [Trait("TestType", "Unit")]
        public void Event_SelectCurrentEvent_GET_PASS_Should_Return_View()
        {
            // Arrange
            var controller = new EventController(new TestAuctionService(), new TestUserService());

            // Assert
            var result = controller.SelectCurrentEvent();

            // Act
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("SelectCurrentEvent", castedResult.ViewName);
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public async void Event_SelectCurrentEvent_POST_PASS_Should_Return_Redirect()
        {
            // Arrange
            var controller = new EventController(new TestAuctionService(), new TestUserService());

            // Assert
            var result = await controller.SelectCurrentEvent(1);

            // Act
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal("Index", castedResult.ActionName);
            Assert.Equal("Event", castedResult.ControllerName);
            Assert.Equal("Active Event Changed", castedResult.RouteValues["successMessage"]);
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public void Event_SearchEvent_GET_PASS_Should_Return_View()
        {
            // Arrange
            var controller = new EventController(new TestAuctionService(), new TestUserService());

            // Assert
            var result = controller.SearchEvent();

            // Act
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("SearchEvent", castedResult.ViewName);
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public async void Event_Edit_Event_GET_PASS_Should_Return_View()
        {
            // Arrange
            var controller = new EventController(new TestAuctionService(), new TestUserService());

            // Assert
            var result = await controller.EditEvent(1);

            // Act
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("EditEvent", castedResult.ViewName);
            Assert.IsType<EditEventViewModel>(castedResult.Model);
            EditEventViewModel vm = castedResult.Model as EditEventViewModel;
            Assert.Equal(1, vm.Id);
        }


        [Fact]
        [Trait(TestType, Unit)]
        public async void Meal_EditEvent_POST_PASS_Should_Return_Redirect()
        {
            // Arrange
            var controller = new EventController(new TestAuctionService(), new TestUserService());
            EditEventViewModel vm = new EditEventViewModel()
            {
                EventDate = DateTime.UtcNow,
                EventName = "TEST",
                Id = 1
            };

            // Act
            var result = await controller.EditEvent(vm);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal("Index", castedResult.ActionName);
            Assert.Equal("Event", castedResult.ControllerName);
            Assert.Equal("Event Updated", castedResult.RouteValues["successMessage"]);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Meal_EditEvent_POST_FAIL_Bad_ModelState_Should_Return_View()
        {
            // Arrange
            var controller = new EventController(new TestAuctionService(), new TestUserService());
            EditEventViewModel vm = new EditEventViewModel()
            {
                EventDate = DateTime.UtcNow,
                EventName = "TEST",
                Id = 1
            };
            controller.ModelState.AddModelError("ERROR", "ERROR");

            // Act
            var result = await controller.EditEvent(vm);

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("EditEvent", castedResult.ViewName);
            Assert.IsType<EditEventViewModel>(castedResult.Model);
        }
    }


}
