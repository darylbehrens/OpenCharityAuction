using Microsoft.AspNetCore.Http;
using OpenCharityAuction.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.Models.Services
{
    public class UserService : IUserService
    {
        private readonly Data.UserContext UserContext;
        private readonly IHttpContextAccessor HttpContextAccessor;

        public UserService(Data.UserContext userContext, IHttpContextAccessor httpContextAccessor)
        {
            UserContext = userContext;
            HttpContextAccessor = httpContextAccessor;
        }

        public bool CheckIfThereAreAnyUsers()
        {
            bool result = false;
            if (UserContext.Users.Count() > 0)
            {
                result = true;
            }
            return result;
        }

        public string GetUserId()
        {
            return HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
