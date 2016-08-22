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
        public async void AddEvent_Fail_Validation_Return_View()
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

        [Fact]
        [Trait("TestType", "Unit")]
        public async void AddEvent_Passes_Validation_Return_Redirect()
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
            Assert.Equal(castedResult.ActionName, "Index");
            Assert.Equal(castedResult.ControllerName, "Event");
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public void AddEventViewModel_Test_No_Event_Name_Fail()
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
        public void AddEventViewModel_Test_No_Event_Date_Fail()
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
        public void AddEventViewModel_Get_Index_Should_Return_View()
        {
            var controller = new EventController(new TestAuctionService(), new TestUserService());
            var result = controller.Index();

            Assert.IsType<ViewResult>(result);

            var castedResult = result as ViewResult;
            Assert.Equal(castedResult.ViewName, "Index");
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public void AddEventViewModel_Get_AddEvent_Should_Return_View()
        {
            var controller = new EventController(new TestAuctionService(), new TestUserService());
            var result = controller.AddEvent();

            Assert.IsType<ViewResult>(result);

            var castedResult = result as ViewResult;
            Assert.Equal(castedResult.ViewName, "AddEvent");
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public async void AddEventViewModel_Select_Current_Event_Should_Return_View()
        {
            // Arrange
            var controller = new EventController(new TestAuctionService(), new TestUserService());

            // Assert
            var result = await controller.SelectCurrentEvent();

            // Act
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal(castedResult.ViewName, "SelectCurrentEvent");
            Assert.IsType<SelectCurrentEventViewModel>(castedResult.Model);
            var castedVm = castedResult.Model as SelectCurrentEventViewModel;
        }
    }
}
