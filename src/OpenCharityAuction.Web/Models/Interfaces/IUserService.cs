using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.Models.Interfaces
{
    public interface IUserService
    {
        bool CheckIfThereAreAnyUsers();

        string GetUserId();

        Task<int?> GetCurrentUsersActiveEvent();

        Task UpdateCurrentEventForUser(int eventId);
        
    }
}
