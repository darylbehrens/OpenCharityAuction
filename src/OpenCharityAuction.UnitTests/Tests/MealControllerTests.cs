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
        public void Meal_Index_GET_Should_Return_View()
        {
            var controller = new MealController(new TestAuctionService(), new TestUserService());
            var result = controller.Index();

            Assert.IsType<ViewResult>(result);

            var castedResult = result as ViewResult;
            Assert.Equal("Index", castedResult.ViewName);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public void Meal_AddMeal_GET_Should_Return_View()
        {
            var controller = new MealController(new TestAuctionService(), new TestUserService());
            var result = controller.AddMeal();

            Assert.IsType<ViewResult>(result);

            var castedResult = result as ViewResult;
            Assert.Equal("AddMeal", castedResult.ViewName);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public void Meal_AddMeal_POST_Success_Should_Return_Redirect()
        { }
    }
}
