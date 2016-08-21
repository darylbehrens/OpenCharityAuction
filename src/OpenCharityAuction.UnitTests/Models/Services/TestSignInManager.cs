using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using OpenCharityAuction.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace OpenCharityAuction.UnitTests.Models.Services
{
    public class TestSignInManager : SignInManager<User>
    {
        public bool? boolResult { get; set; }

        public TestSignInManager(IHttpContextAccessor contextAccessor)
            : base(new TestUserManager(),
                  contextAccessor,
                  new Mock<IUserClaimsPrincipalFactory<User>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<ILogger<SignInManager<User>>>().Object)
        {
        }

        public override Task SignInAsync(User user, bool isPersistent, string authenticationMethod = null)
        {
            return Task.FromResult(0);
        }

        public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            SignInResult result = SignInResult.Failed;
            if (boolResult.HasValue)
            {
                if (boolResult.Value)
                {
                    result = SignInResult.Success;
                }
                else
                {
                    result = SignInResult.Failed;
                }
            }
            return Task.FromResult(result);
        }

        public override Task SignOutAsync()
        {
            return Task.FromResult(0);
        }

        public override bool IsSignedIn(ClaimsPrincipal principal)
        {
            bool result = false;
            if (boolResult.HasValue)
            {
                result = boolResult.Value;
            }

            return result;

        }
    }
}
