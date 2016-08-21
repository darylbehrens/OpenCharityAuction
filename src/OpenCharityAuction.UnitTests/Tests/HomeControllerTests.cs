using Microsoft.AspNetCore.Mvc;
using OpenCharityAuction.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static OpenCharityAuction.UnitTests.Constants;

namespace OpenCharityAuction.UnitTests.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        [Trait(TestType, Unit)]
        public void Home_Controller_Get_Index_Should_Return_View()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
            var castedResult = result as ViewResult;
            Assert.Equal(castedResult.ViewName, "Index");
            

        }
    }
}
