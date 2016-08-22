using OpenCharityAuction.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.UnitTests.Models.Services
{
    
    public class TestUserService : IUserService
    {
        public bool? boolReturn { get; set; } // To Test Different Bool Values

        public bool CheckIfThereAreAnyUsers()
        {
            if (boolReturn.HasValue)
            {
                return boolReturn.Value;
            }
            else
            {
                return true;
            }
        }

        public async Task<int?> GetCurrentUsersActiveEvent()
        {
            return await Task.Run(() => { return 1; });
        }

        public string GetUserId()
        {
            return "testUser";
        }

        public Task UpdateCurrentEventForUser(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
