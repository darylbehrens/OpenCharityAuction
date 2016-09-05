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
    public class MealControllerTests
    {
        [Fact]
        [Trait(TestType, Unit)]
        public void Meal_Index_GET_PASS_Should_Return_View()
        {
            var controller = new MealController(new TestAuctionService(), new TestUserService());
            var result = controller.Index();

            Assert.IsType<ViewResult>(result);

            var castedResult = result as ViewResult;
            Assert.Equal("Index", castedResult.ViewName);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public void Meal_AddMeal_GET_PASS_Should_Return_View()
        {
            var controller = new MealController(new TestAuctionService(), new TestUserService());
            var result = controller.AddMeal();

            Assert.IsType<ViewResult>(result);

            var castedResult = result as ViewResult;
            Assert.Equal("AddMeal", castedResult.ViewName);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Meal_AddMeal_POST_PASS_Should_Return_Redirect()
        {
            // Arrange
            AddMealViewModel vm = new AddMealViewModel()
            {
                Name = "Turkey",
                Description = "Delicious Turkey with Butter Cream Frosting"
            };

            var testUserService = new TestUserService();
            testUserService.intReturn = 3; // To Allow To Pass must have active event

            var controller = new MealController(new TestAuctionService(), testUserService);

            // Act
            var result = await controller.AddMeal(vm);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal("Index", castedResult.ActionName);
            Assert.Equal("Meal", castedResult.ControllerName);
            Assert.Equal("New Meal Added", castedResult.RouteValues["successMessage"]);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Meal_AddMeal_POST_FAIL_No_Event_Should_Return_Redirect()
        {
            // Arrange
            var controller = new MealController(new TestAuctionService(), new TestUserService());
            AddMealViewModel vm = new AddMealViewModel()
            {
                Name = "Turkey",
                Description = "Delicious Turkey with Butter Cream Frosting"
            };

            // Act
            var result = await controller.AddMeal(vm);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal("AddMeal", castedResult.ActionName);
            Assert.Equal("You must have an active event before you can add meals", castedResult.RouteValues["errorMessage"]);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Meal_AddMeal_POST_FAIL_Bad_ModelState_Should_Return_View()
        {
            // Arrange
            var controller = new MealController(new TestAuctionService(), new TestUserService());
            var vm = new AddMealViewModel()
            {
                Name = "TEST",
            };
            controller.ModelState.AddModelError("ERROR", "ERROR");

            // Act
            var result = await controller.AddMeal(vm);

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("AddMeal", castedResult.ViewName);
            Assert.IsType<AddMealViewModel>(castedResult.Model);
        }
    }
}
