using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenCharityAuction.Web.Controllers;
using Xunit;
using OpenCharityAuction.UnitTests.Models.Services;
using Moq;
using Microsoft.AspNetCore.Http;
using Castle.Core.Logging;
using OpenCharityAuction.Web.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OpenCharityAuction.Web.Models.Services;

namespace OpenCharityAuction.UnitTests.Tests
{
    public class AuthenitcationControllerTests
    {
        private IUserService UserService;

        [Fact]
        [Trait("TestType", "Unit")]
        public void Authetication_Test_InitialSetup_Should_Return_InitialSetup_View()
        {
            UserService = new TestUserService();
            ((TestUserService)UserService).boolReturn = false;

            var controller = ControllerFactory.GetAuthenticationController(UserService);
            var result = controller.InitialSetup("PASSED");
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal(castedResult.ViewData["ReturnUrl"], "PASSED");
        }

        [Fact]
        [Trait("TestType", "Unit")]
        public void Authetication_Test_InitialSetup_Should_Return_Login_Redirect()
        {
            UserService = new TestUserService();
            ((TestUserService)UserService).boolReturn = true;

            var controller = ControllerFactory.GetAuthenticationController(UserService);
            var result = controller.InitialSetup("PASSED");
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal(castedResult.ActionName, "Login");
            Assert.Equal(castedResult.ControllerName, "Authentication");
        }
    }
}
