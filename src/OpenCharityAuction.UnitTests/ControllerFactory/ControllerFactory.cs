using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenCharityAuction.UnitTests.Models.Services;
using OpenCharityAuction.Web.Controllers;
using OpenCharityAuction.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace OpenCharityAuction.UnitTests
{
    public static class ControllerFactory
    {
        public static AuthenticationController GetAuthenticationController(IUserService UserService)
        {
            var context = new Mock<HttpContext>();

            var contextAccessor = new Mock<IHttpContextAccessor>();
            contextAccessor.Setup(x => x.HttpContext).Returns(context.Object);
            var controller = new AuthenticationController(new TestUserManager(), new TestSignInManager(contextAccessor.Object), new TestLoggerFactory(), UserService);
            return controller;
        }

        public static MealController GetMealController(IUserService userService, IAuctionService auctionService, int? userId = null)
        {
            TestUserService castedUserService = new TestUserService();
            castedUserService = userService as TestUserService;
            if (userId != null)
            {
                castedUserService.intReturn = 3; // To Allow To Pass must have active event
            }

            return new MealController(auctionService, castedUserService);
        }
    }
}
