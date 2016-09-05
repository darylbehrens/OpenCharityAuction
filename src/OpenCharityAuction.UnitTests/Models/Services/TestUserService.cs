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
        public int? intReturn { get; set; } // To Test Ints

        public bool CheckIfThereAreAnyUsers()
        {
            if (boolReturn.HasValue)
            {
                return boolReturn.Value;
            }
            throw new Exception("boolReturn not setup in TestUserService");
        }

        public async Task<int?> GetCurrentUsersActiveEvent()
        {
            return await Task.Run(() => { return intReturn; });
        }

        public string GetUserId()
        {
            return "testUser";
        }

        public async Task UpdateCurrentEventForUser(int eventId)
        {
            await Task.Run(() => { });
        }
    }
}
