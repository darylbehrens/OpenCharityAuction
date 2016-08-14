using OpenCharityAuction.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.Models.Services
{
    public class UserService : IUserService
    {
        private readonly Data.UserContext Context;

        public UserService(Data.UserContext context)
        {
            Context = context;
        }

        public bool CheckIfThereAreAnyUsers()
        {
            bool result = false;
            if (Context.Users.Count() > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
