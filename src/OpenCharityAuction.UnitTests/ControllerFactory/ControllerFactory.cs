using Microsoft.AspNetCore.Http;
using Moq;
using OpenCharityAuction.UnitTests.Models.Services;
using OpenCharityAuction.Web.Controllers;
using OpenCharityAuction.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.UnitTests
{
    public static class ControllerFactory
    {
        public static AuthenticationController GetAuthenticationController(IUserService UserService )
        {
            var context = new Mock<HttpContext>();
            var contextAccessor = new Mock<IHttpContextAccessor>();
            contextAccessor.Setup(x => x.HttpContext).Returns(context.Object);
            var controller = new AuthenticationController(new TestUserManager(), new TestSignInManager(contextAccessor.Object), new TestLoggerFactory(), UserService);
            return controller;
        }
    }
}
