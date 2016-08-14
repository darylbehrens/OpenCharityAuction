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

namespace OpenCharityAuction.UnitTests.Tests
{
    public class AuthenitcationControllerTests
    {
         IUserService UserService = new TestUserService();

        [Fact]
        public void Authetication_Test_InitialSetup_Should_Return_InitialSetup_View()
        {
            var context = new Mock<HttpContext>();
            var contextAccessor = new Mock<IHttpContextAccessor>();
            contextAccessor.Setup(x => x.HttpContext).Returns(context.Object);


            var controller = new AuthenticationController(new TestUserManager(), new TestSignInManager(contextAccessor.Object), new TestLoggerFactory(), UserService);
            var result = controller.InitialSetup();
        }
    }
}
