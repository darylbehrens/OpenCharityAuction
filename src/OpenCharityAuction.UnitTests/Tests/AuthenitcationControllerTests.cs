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
using OpenCharityAuction.Web.ViewModels;
using static OpenCharityAuction.UnitTests.Constants;

namespace OpenCharityAuction.UnitTests.Tests
{
    public class AuthenitcationControllerTests
    {
        private IUserService UserService;

        [Fact]
        [Trait(TestType, Unit)]
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
        [Trait(TestType, Unit)]
        public async void Authentication_Test_InitialSetup_POST_Should_Return_Login_View()
        {
            UserService = new TestUserService();
            ((TestUserService)UserService).boolReturn = false;

            var controller = ControllerFactory.GetAuthenticationController(UserService);

            InitialSetupViewModel vm = new InitialSetupViewModel()
            {
                Email = "test@test.com",
                Password = "123rty&*(",
                ConfirmPassword = "123rty&*("
            };
            var result = await controller.InitialSetup(vm);
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal(castedResult.ActionName, "Login");
            Assert.Equal(castedResult.ControllerName, "Authentication");
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Authentication_Test_InitialSetup_POST_Should_Return_View()
        {
            UserService = new TestUserService();
            ((TestUserService)UserService).boolReturn = false;

            var controller = ControllerFactory.GetAuthenticationController(UserService);
            controller.ModelState.AddModelError("ERROR", "ERROR");

            InitialSetupViewModel vm = new InitialSetupViewModel()
            {
                Email = "test@test.com",
                Password = "123rty&*(",
                ConfirmPassword = "123rty&*("
            };
            var result = await controller.InitialSetup(vm);
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal(castedResult.ViewName, "InitialSetup");
            Assert.Equal(castedResult.Model, vm);
        }


        [Fact]
        [Trait(TestType, Unit)]
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

        [Fact]
        [Trait(TestType, Unit)]
        public void Authentication_GET_Login_Should_Return_View()
        {
            // Arrange
            UserService = new TestUserService();
            ((TestUserService)UserService).boolReturn = true;

            var controller = ControllerFactory.GetAuthenticationController(UserService);
            var signInManager = controller.SignInManager as TestSignInManager;
            signInManager.boolResult = false;

            // Act
            var result = controller.Login();

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal(castedResult.ViewName, "Login");
        }

        [Fact]
        [Trait(TestType, Unit)]
        public void Authentication_GET_Login_Should_Return_Redirect()
        {
            // Arrange
            UserService = new TestUserService();
            ((TestUserService)UserService).boolReturn = true;

            var controller = ControllerFactory.GetAuthenticationController(UserService);
            var signInManager = controller.SignInManager as TestSignInManager;
            signInManager.boolResult = true;

            // Act
            var result = controller.Login();

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal(castedResult.ActionName, "Index");
            Assert.Equal(castedResult.ControllerName, "Home");
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Authentication_POST_Login_Fail_Should_Return_View()
        {
            // Arrange
            UserService = new TestUserService();

            var controller = ControllerFactory.GetAuthenticationController(UserService);
            var signInManager = controller.SignInManager as TestSignInManager;
            signInManager.boolResult = false;

            LoginViewModel model = new LoginViewModel()
            {
                Email = "test@test.com",
                Password = "test",
            };

            // Act
            var result = await controller.Login(model);

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal(castedResult.ViewName, "Login");
            Assert.Equal(castedResult.Model, model);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Authentication_POST_Login_Pass_Should_Return_Redirect()
        {
            // Arrange
            UserService = new TestUserService();

            var controller = ControllerFactory.GetAuthenticationController(UserService);
            var signInManager = controller.SignInManager as TestSignInManager;
            signInManager.boolResult = true;

            LoginViewModel model = new LoginViewModel()
            {
                Email = "test@test.com",
                Password = "test",
            };

            // Act
            var result = await controller.Login(model);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal(castedResult.ActionName, "Index");
            Assert.Equal(castedResult.ControllerName, "Home");
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Authentication_POST_Login_Model_Fail_Should_Return_View()
        {
            // Arrange
            UserService = new TestUserService();

            var controller = ControllerFactory.GetAuthenticationController(UserService);
            var signInManager = controller.SignInManager as TestSignInManager;
            signInManager.boolResult = false;
            controller.ModelState.AddModelError("ERROR", "ERROR");

            LoginViewModel model = new LoginViewModel()
            {
                Email = "test@test.com",
                Password = "test",
                RememberMe = true
            };

            // Act
            var result = await controller.Login(model);

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal(castedResult.ViewName, "Login");
            Assert.Equal(castedResult.Model, model);
        }

        [Fact]
        [Trait(TestType, Unit)]
        public async void Authentication_Get_Logoff_Should_Return_Redirect()
        {
            // Arrange
            UserService = new TestUserService();
            var controller = ControllerFactory.GetAuthenticationController(UserService);

            // Act
            var result = await controller.LogOff();

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var castedResult = result as RedirectToActionResult;
            Assert.Equal(castedResult.ActionName, "Login");
            Assert.Equal(castedResult.ControllerName, "Authentication");
        }
    }
}
