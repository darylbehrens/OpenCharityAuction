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
            var controller = ControllerFactory.GetMealController(new TestUserService(), new TestAuctionService(), 3);
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
            var controller = ControllerFactory.GetMealController(new TestUserService(), new TestAuctionService(), 3);
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
            Assert.Equal("Index", castedResult.ActionName);
            Assert.Equal("Meal", castedResult.ControllerName);
            Assert.Equal("New Meal Added", castedResult.RouteValues["successMessage"]);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Meal_AddMeal_POST_FAIL_No_Event_Should_Return_Redirect()
        {
            // Arrange
            var controller = ControllerFactory.GetMealController(new TestUserService(), new TestAuctionService());
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
            var controller = ControllerFactory.GetMealController(new TestUserService(), new TestAuctionService(), 3);
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

        [Fact]
        [Trait(TestType, Unit)]
        public void Meal_SearchMeal_GET_PASS_Should_Return_View()
        {
            var controller = ControllerFactory.GetMealController(new TestUserService(), new TestAuctionService(), 3);
            var result = controller.SearchMeal();

            Assert.IsType<ViewResult>(result);

            var castedResult = result as ViewResult;
            Assert.Equal("SearchMeal", castedResult.ViewName);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Meal_EditMeal_GET_PASS_Should_Return_View()
        {
            // Arrange
            var controller = ControllerFactory.GetMealController(new TestUserService(), new TestAuctionService(), 3);

            // Act
            var result = await controller.EditMeal(1);

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("EditMeal", castedResult.ViewName);
            Assert.IsType<EditMealViewModel>(castedResult.Model);
            EditMealViewModel vm = castedResult.Model as EditMealViewModel;
            Assert.Equal(1, vm.Id);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Meal_EditMeal_POST_PASS_Should_Return_Redirect()
        {
            // Arrange
            var controller = ControllerFactory.GetMealController(new TestUserService(), new TestAuctionService(), 3);
            EditMealViewModel vm = new EditMealViewModel()
            {
                Id = 1,
                Name = "Turkey",
                Description = "Delicious Turkey with Butter Cream Frosting"
            };

            // Act
            var result = await controller.EditMeal(vm);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal("Index", castedResult.ActionName);
            Assert.Equal("Meal", castedResult.ControllerName);
            Assert.Equal("Meal Updated", castedResult.RouteValues["successMessage"]);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Meal_EditMeal_POST_FAIL_No_Event_Should_Return_Redirect()
        {
            // Arrange
            var controller = ControllerFactory.GetMealController(new TestUserService(), new TestAuctionService());
            EditMealViewModel vm = new EditMealViewModel()
            {
                Id = 1,
                Name = "Turkey",
                Description = "Delicious Turkey with Butter Cream Frosting"
            };

            // Act
            var result = await controller.EditMeal(vm);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal("EditMeal", castedResult.ActionName);
            Assert.Equal("You must have an active event before you can edit meals", castedResult.RouteValues["errorMessage"]);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Meal_EditMeal_POST_FAIL_Bad_ModelState_Should_Return_View()
        {
            // Arrange
            var controller = ControllerFactory.GetMealController(new TestUserService(), new TestAuctionService(), 3);
            var vm = new EditMealViewModel()
            {
                Name = "TEST",
            };
            controller.ModelState.AddModelError("ERROR", "ERROR");

            // Act
            var result = await controller.EditMeal(vm);

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal("EditMeal", castedResult.ViewName);
            Assert.IsType<EditMealViewModel>(castedResult.Model);
        }
    }
}
